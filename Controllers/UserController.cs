using Server;
using CitizenFX.Core;
using System;
using DBAcesss;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using CitizenFX.Core.Native;
using Server.Utility;
using Server.Models;
using Newtonsoft.Json;

namespace Server.Controllers
{
    public class UserController : BaseScript
    {
        public static bool firstConnection { get; set; } = true;


        public UserController() // constructor
        {
            EventHandlers["dFRP:NeedLicense"] += new Action<Player>(OnRequestedLicense); // License requested from the client upon joining [STEP 1]
            EventHandlers["dFRP:validatePlayer"] += new Action<Player>(validateUser); // client requests user validation upon recieving license [STEP 2]
            EventHandlers["dFRP:registerationComplete"] += new Action<Player, string>(onRegisterationComplete); //  clients sends the password to the server upon registeration complete [STEP 3]
            EventHandlers["dFRP:loginRequest"] += new Action<Player, string>(onLoginRequest); // clients send the password to the server upon login complete [STEP 3]
            EventHandlers["dFRP:dropPlayer"] += new Action<Player, string>(onDropPlayer); // event triggered when dropping a player.
            EventHandlers["onResourceStop"] += new Action<string>(onResourceStop); // event triggered when the resource starts.
            EventHandlers["onResourceStart"] += new Action<string>(onResourceStart); // event triggered when the resource stops.
            EventHandlers["playerConnecting"] += new Action<Player, string, dynamic, dynamic>(onPlayerConnecting); // event triggered when the player connects.
        }

        public void onPlayerConnecting([FromSource] Player source, string playerName, dynamic setKickReason, dynamic deferrals)
        {
            Debug.WriteLine($"onPlayerConnecting: {playerName} is connecting to the server.");
        }
        public static void OnRequestedLicense([FromSource] Player source) // Provide the client with the source license & player handle.
        {
            string licenseId = source.Handle;
            TriggerClientEvent(source, "dFRP:returnlicense", licenseId);
        }
        public static async void validateUser([FromSource] Player source)
        {
            string license = source.Identifiers["license"]; // player license - used as primary key for login/register
            string playerName = API.GetPlayerName(source.Handle);


            List<User> userList = await DB_User.Load_Users(); // load the list of user from the DB into userList
            if (userList.Contains(userList.FirstOrDefault(o => o.name == playerName)))
            {
                LoginUser(source);
            }
            else // if false - register the user
            {
                RegisterUser(source);
            }
        }

        public static void RegisterUser([FromSource] Player source)
        {
            string license = source.Identifiers["license"];
            TriggerClientEvent(source, "dFRP:registerUser", license); // trigger client event to show the registeration menu
        }

        public static void LoginUser([FromSource] Player source)
        {
            string license = source.Identifiers["license"];
            TriggerClientEvent(source, "dFRP:loginUser", license); // trigger client event to show the login menu
        }

        public static async void onRegisterationComplete([FromSource] Player source, string playerPassword)
        {

            string licenseID = source.Handle;
            string playerName = API.GetPlayerName(licenseID);

            User playerUser = new User // create new user object.
            {
                name = playerName,
                password = playerPassword
            };

            CharacterController.createCharacter(source, playerUser.Id);
            await DB_User.Insert_User(playerUser);
        }

        public static void onLoginRequest([FromSource] Player source, string playerPassword)
        {
            string licenseID = source.Handle;
            string playerName = API.GetPlayerName(licenseID);
            loginUser(source, playerPassword, licenseID, playerName);
        }

        private static async void loginUser(Player source, string playerPassword, string licenseID, string playerName)
        {
            List<User> userList = await DB_User.Load_Users();
            User playerUser = userList.FirstOrDefault(x => x.name == source.Name);
            if (playerUser != null)
            {
                if (playerUser.password == playerPassword)
                {
                    var userID = JsonConvert.SerializeObject(playerUser.Id);
                    TriggerClientEvent(source, "dFRP:loginSuccess", licenseID, userID);

                    if (firstConnection) // check if the the player is the first to connect - if so, spawnm the intro vehicles near the spawn points [TO BE REWORKED]
                    {
                        firstConnection = false;
                        TriggerClientEvent(source, "dFRP:LoadStaticVehicles");
                    }
                }
                else
                {
                    TriggerClientEvent(source, "dFRP:loginFail", licenseID);
                }
            }
            else
            {
                TriggerClientEvent(source, "dFRP:registerUser", licenseID);
            }
        }

        public static void onDropPlayer([FromSource] Player source, string dropReason) // Drop the player from server.
        {
            Debug.Write($"triggered:DropPlayer onto: {source.Name}");
            API.DropPlayer(source.Handle, dropReason);
            CommFuncs.DisplayMessage(source, "Kicked", dropReason, 140, 144, 149);
        }

        public static void onResourceStop(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName) return;
            TriggerEvent("dFRP:UnloadStaticVehicles"); // delete all the static-vehicles when the resource is being stopped/restarted to avoid double spawn
        }

        public static void onResourceStart(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName) return;
            firstConnection = true; // allows for the firstConnection flag to be triggered again if the resource is restarted via console.
        }


        public Player GetPlayerFromHandle(int playerId)
        {
            try
            {
                foreach (Player p in Players)
                {
                    if (int.Parse(p.Handle) == playerId)
                    {
                        return p;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.Write($"EXCEPTION THROWN - PlayerID: {ex}");
                return null;
            }
        }

    }
}
