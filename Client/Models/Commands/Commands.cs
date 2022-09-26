using System;
using System.Collections.Generic;
using System.Linq;

using CitizenFX.Core;
using CitizenFX.Core.Native;
using Client.Utility;
using static CitizenFX.Core.Native.API;
using Blip = Client.Models.Objects.Blip;

namespace Client.Extensions
{
    public class Commands : BaseScript
    {
        public Commands()
        {
            EventHandlers["dFRP:SpawnModel"] += new Action<List<object>>(SpawnModel);
            EventHandlers["dFRP:GiveWeapon"] += new Action<List<object>>(GiveWeapon);
            EventHandlers["dFRP:setModel"] += new Action<List<object>>(SetModel);
            EventHandlers["dFRP:CreateBlip"] += new Action<List<object>>(CreateBlip);
            EventHandlers["dFRP:CreateVehicle"] += new Action<List<object>>(CreateVehicle);
            EventHandlers["dFRP:TeleportPlayer"] += new Action<List<object>>(TeleportPlayer);

            API.RegisterCommand("help", new Action(HelpMenu), false);
            API.RegisterCommand("deletecar", new Action<int, List<object>, string>(RemoveVehicle), false);
            API.RegisterCommand("getPosition", new Action<int, List<object>, string>(getPosition), false);
            //API.RegisterCommand("showui", new Action(showUI), false);

        }

        /*public void showUI()
        {
            bool active = true;
            if (active == false)
            {
                API.SendNuiMessage("{ type = \"enableUI\" }");
            }
            else
            {
                API.SendNuiMessage("{ type = \"disableUI\" }");
            }
        }*/

        public void getPosition(int source, List<object> args, string raw)
        {
            if (args == null || args.Count != 1)
            {
                CommFuncs.DisplayMessage("ERROR", "[SYNTAX: /getposition [position-name]", 255, 255, 255);
                return;
            }
            
            string positionName = args[0].ToString();
            TriggerServerEvent("dFRP:getPosition", positionName);
        }

        public async void SpawnModel(List<object> arguments)
        {
            try
            {
                var model = "adder";
                if (arguments.Count > 0)
                {
                    model = arguments[0].ToString();
                }

                var hash = (uint)GetHashKey(model);
                if (!IsModelInCdimage(hash) || !IsModelAVehicle(hash))
                {
                    CommFuncs.DisplayMessage("SERVER", "ERROR: Please enter a valid model for the vehicle to spawn", 255, 255, 255);
                    return;
                }

                bool ColorParse = Enum.TryParse(arguments[1].ToString(), out VehicleColor CarColor);
                
                if(!ColorParse)
                {
                    CommFuncs.DisplaySubTitle($"~w~ERROR: Please enter a valid ~b~Cololor~w~!", 2500);
                }



                var vehicle = await World.CreateVehicle(model, Game.PlayerPed.Position, Game.PlayerPed.Heading);
                vehicle.Mods.PrimaryColor = CarColor;
                Game.PlayerPed.SetIntoVehicle(vehicle, VehicleSeat.Driver);

                CommFuncs.DisplayNotify($"~w~Vehicle : ~b~{model}~w~ - Color: ~b~{CarColor}");
                CommFuncs.DisplaySubTitle($"SERVER: Vehicle {model} has been spawned.", 2500);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("ERROR: Invalid object state used in the command - [/tempcar]");
            }

        }

        public void GiveWeapon(List<object> arguments)
        {
            if (arguments.Count > 2)
            {
                CommFuncs.DisplaySubTitle("SNYTAX: /giveweapon [playerid] [weapon name]", 5000);
                return;
            }

            try
            {
                var argList = arguments.Select(o => o.ToString()).ToList(); // Create an arg list & search for the arguments and then convert it to string
                if (argList.Count == 1)
                {
                    if (argList.Any() && Enum.TryParse(argList[0], true, out WeaponHash weapon)) // Try to parse what it's in the args with the waepon hash enum.
                    {
                        Game.PlayerPed.Weapons.Give(weapon, 250, true, true);
                        CommFuncs.DisplayNotify($"~w~You have recieved a ~b~{weapon}~w~!");
                    }
                }
                else if (argList.Count == 2)
                {
                    if (argList.Any() && Enum.TryParse(argList[0] + argList[1], true, out WeaponHash weapon)) // Try to parse what it's in the args with the waepon hash enum.
                    {
                        Game.PlayerPed.Weapons.Give(weapon, 250, true, true);
                        CommFuncs.DisplayNotify($"~w~You have recieved a ~b~{weapon}~w~!");
                    }
                }
            }

            catch (Exception)
            {
                throw new InvalidOperationException("ERROR: Invalid object state used in the command - [/giveweapon]");
            }
        }
        public async void SetModel(List<object> arguments)
        {
            if (arguments.Count != 1)
            {
                CommFuncs.DisplaySubTitle("SNYTAX: /setmodel [playerid] [model name]", 5000);
                return;
            }

            try
            {
                //var playerID = new PlayerList()[source];
                var argList = arguments.Select(o => o.ToString()).ToList();
                bool ModelParse = Enum.TryParse(argList[0], true, out PedHash model);

                if (ModelParse)
                {
                    RequestModel((uint)model);
                    while (!API.HasModelLoaded((uint)model))
                    {
                        await BaseScript.Delay(100);
                    }

                    SetPlayerModel(PlayerId(), (uint)model);
                    SetPedDefaultComponentVariation(PlayerPedId());
                    CommFuncs.DisplayNotify($"~w~Your ped model has been set to ~b~{model}~w~!");
                }
                else
                {
                    CommFuncs.DisplayNotify("ERROR: Failed to convert to ped hash model.");
                }
            }

            catch (Exception)
            {
                throw new InvalidOperationException("ERROR: Invalid object state used in the command - [/setmodel]");
            }
        }
        public void CreateBlip(List<object> arguments)
        {
            if (arguments.Count != 5)
            {
                CommFuncs.DisplaySubTitle("SNYTAX: /createblip [Sprite ID] [Category ID] [Color ID] [Display ID] [TITLE]", 5000);
                return;
            }
            try
            {
                Ped playerChar = Game.Player.Character;

                bool spriteParse = Enum.TryParse(arguments[0].ToString(), out BlipSprite spriteID);

                if (spriteParse)
                {
                    var blip = new Blip()
                    {
                        BlipSpriteID = spriteID,
                        BlipCategory = (int)arguments[1],
                        BlipColor = (int)arguments[2],
                        BlipDisplay = (int)arguments[3],
                        BlipX = (float)playerChar.Position.X,
                        BlipY = (float)playerChar.Position.Y,
                        BlipZ = (float)playerChar.Position.Z,
                        BlipTitle = arguments[4].ToString()
                    };

                    blip.CreateBlipObject();



                }
            }

            catch (Exception)
            {
                throw new InvalidOperationException("ERROR: Invalid object state used in the command - [/createblip]");
            }
        }


        public void CreateVehicle(List<object> arguments) // args: vebicle name - vehicle , color , lock status
        {

            if (arguments.Count != 3)
            {

                CommFuncs.DisplaySubTitle("SYNTAX: /createvehicle [model-name] [primary-color] [lock status]", 5000);

            }

            try
            {
                var model = arguments[0].ToString();
                var hash = (uint)GetHashKey(model);
                if (!IsModelInCdimage(hash) || !IsModelAVehicle(hash))
                {
                    CommFuncs.DisplayNotify("ERROR: Please enter a valid model for the vehicle to spawn [vehicle-name]");
                    return;
                }

                // var argList = arguments.Select(o => o.ToString()).ToList();

                bool ParseColor = Enum.TryParse(arguments[1].ToString(), out VehicleColor PrimaryColor);

                if (!ParseColor)
                {
                    CommFuncs.DisplayNotify("ERROR: Please enter a valid color for the vehicle to spawn [color-id]");
                    return;
                }


                bool LockStatus = bool.TryParse(arguments[2].ToString(), out bool vehLockStatus);

                if (!LockStatus)
                {
                    CommFuncs.DisplayNotify("ERROR: Please enter a valid lock-status for the vehicle to spawn [TRUE: Locked - FALSE: Unlocked]");
                    return;
                }


                /*var veh = new StaticVehicles()
                {
                    VehicleModel = model,
                    VehiclePosition = Game.PlayerPed.Position,
                    VehicleHeading = Game.PlayerPed.Heading,
                    VehicleLock = vehLockStatus,
                    VehColor = PrimaryColor,

                };


                veh.SpawnStaticVehicles();*/

                CommFuncs.DisplayNotify($"~r~SERVER: ~w~You have spawned a permanent vehicle. Model Name: ~b~{model}~w~, Color: ~b~{PrimaryColor}, Lock Status: {vehLockStatus}!");





            }

            catch (Exception)
            {

                throw new InvalidOperationException("ERROR: Invalid object state used in the command - [/createvehicle]");
            }

        }

        public void RemoveVehicle(int source, List<object> arguments, string raw)
        {
            var playerID = GetPlayerFromServerId(source);
            var playerPed = GetPlayerPed(playerID);

            var vehicleID = GetVehiclePedIsIn(playerPed, false);
            if (vehicleID == 0)
            {
                CommFuncs.DisplayNotify("ERROR: Invalid vehicle ID");

            }
            else
            { 
                SetEntityAsMissionEntity(vehicleID, true, true);
                DeleteVehicle(ref vehicleID);
                CommFuncs.DisplayNotify("SERVER: Successfully removed vehicle");
            }
        }

        public void TeleportPlayer(List<object> arguments)
        {
            var playerID = GetPlayerFromServerId(GetPlayerIndex());
            var playerPed = GetPlayerPed(playerID);
            var tpLocation = arguments[0].ToString();
            if(tpLocation == "LSC")
            {
                    SetPedCoordsKeepVehicle(playerPed, -360.91F, -129.46F, 38.70F);
                    CommFuncs.DisplayNotify("SERVER: Succesfully teleported to Los Santos Customs");
            }
            else if(tpLocation == "Bennys")
            {
                    SetPedCoordsKeepVehicle(playerPed, -205.73F, -1303.71F, 31.24F);
                    CommFuncs.DisplayNotify("SERVER: Succesfully teleported to Benny's Body Shop");
            }
        }

        public void HelpMenu()
        {
            CommFuncs.DisplayMessage("/help", "- Shows a list of available commands to use.", 255, 150, 0);
            CommFuncs.DisplayMessage("/giveweapon", "Gives your player a weapon of choice.", 255, 0, 0);
            CommFuncs.DisplayMessage("/setmodel", "Set your player model ID.", 255, 150, 0);
            CommFuncs.DisplayMessage("/createblip", "Creates a permanent blip at the player location.", 255, 0, 0);
            CommFuncs.DisplayMessage("/createvehicle", "Creates a permanent vehicle at the player location.", 255, 150, 0);
            CommFuncs.DisplayMessage("/tempcar", "Spawns a temporary vehicle", 255, 0, 0);
            CommFuncs.DisplayMessage("/getvehicleID", "Displays the closest vehicle ID", 255, 150, 0);
            CommFuncs.DisplayMessage("/carpos", "Displays the vehicle's location coordinates.", 255, 0, 0);
            CommFuncs.DisplayMessage("/deletecar", "Deletes current vehicle", 255, 150, 0);
            CommFuncs.DisplayMessage("/goto", "Teleports ped & player to location - Available TP locations: [LSC - Bennys]", 255, 0, 0);
            CommFuncs.DisplayMessage("/revive", "Revives te specified player ID.", 255, 0, 0);
            CommFuncs.DisplayMessage("/spawnmodel", "Spawns a custom-vehicle model.", 255, 0, 0);
            CommFuncs.DisplayMessage("/getplayer", "Teleports the player to your location.", 255, 0, 0);
        }

    }
}
