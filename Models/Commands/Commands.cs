using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;
using Server.Utility;


namespace Server.Commands
{
    public class Commands : BaseScript
    {
        public Commands()
        {
            API.RegisterCommand("tempcar", new Action<int, List<object>, string>(SummonCar), false);
            API.RegisterCommand("giveweapon", new Action<int, List<object>, string>(GiveWeapon), false);
            API.RegisterCommand("setmodel", new Action<int, List<object>, string>(SetModel), false);
            API.RegisterCommand("createblip", new Action<int, List<object>, string>(CreateBlip), false);
            API.RegisterCommand("createvehicle", new Action<int, List<object>, string>(CreateVehicle), false);
            API.RegisterCommand("goto", new Action<int, List<object>, string>(TeleportPlayer), false);
            API.RegisterCommand("revive", new Action<int, List<object>, string>(RevivePlayer), false);
            API.RegisterCommand("spawnmodel", new Action<int, List<object>, string>(SummonModel), false);
            API.RegisterCommand("getplayer", new Action<int, List<object>, string>(getPlayer), false);

            EventHandlers["dFRP:getPosition"] += new Action<Player, string>(getPosition);
        }

        public void getPlayer(int source, List<object> args, string raw)
        {
            Player sourceID = GetPlayerFromHandle(source);
            string licenseID = sourceID.Handle;
            string playerName = API.GetPlayerName(licenseID);

            if (args == null || args.Count != 1 || !args.Any())
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /getplayer target-id]" }

                });
                return;
            }

            int playerHandle = int.Parse(args[0].ToString());

            Player _playerTarget = GetPlayerFromHandle(playerHandle);
            string targetLicenseID = _playerTarget.Handle;
            string targetName = API.GetPlayerName(targetLicenseID);

            if (GetPlayerFromHandle(playerHandle) == null)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SERVER ERROR", "Invalid target ID to perform the command on." }
                });

                return;

            }

            Vector3 sourceCoords = sourceID.Character.Position;
            API.SetEntityCoords(playerHandle, sourceCoords.X, sourceCoords.Y+1.5f, sourceCoords.Z, true, false, false, false);


        }

        public static async void getPosition([FromSource] Player source, string positionName)
        {
            Vector3 playerPosition = GetEntityCoords(source.Character.Handle);
            string playerLocation = playerPosition.ToString();

            var fullString = String.Concat(playerLocation, " ", positionName);
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "PlayerCoords.txt";

            await CommFuncs.WriteFileAsync(dirPath, fileName, fullString);
        }

        public void RevivePlayer(int source, List<object> args, string raw)
        {
            Player sourceID = GetPlayerFromHandle(source);
            string licenseID = sourceID.Handle;
            string playerName = API.GetPlayerName(licenseID);

            if (args == null || !args.Any() || args.Count != 1)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /reviveplayer target-id]" }

                });
                return;
            }

            int playerHandle = int.Parse(args[0].ToString());

            Player _playerTarget = GetPlayerFromHandle(playerHandle);
            string targetLicenseID = _playerTarget.Handle;
            string targetName = API.GetPlayerName(targetLicenseID);

            if (GetPlayerFromHandle(playerHandle) == null)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SERVER ERROR", "Invalid target ID to perform the command on." }
                });

                return;

            }


            _playerTarget.TriggerEvent("dFRP:revivePlayer", playerName);
            sourceID.TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                multiline = true,
                args = new[] { "SUCCESS!", $"You have revived {targetName}" }
            });


        }
        public void SummonCar(int source, List<object> args, string raw)
        {
            Player sourceID = GetPlayerFromHandle(source);
            TriggerClientEvent(sourceID, "dFRP:VehicleSpawnMenu");
        }

        public void SummonModel(int source, List<object> args, string raw)
        {

            Player sourceID = GetPlayerFromHandle(source);



            if (args == null || !args.Any() || args.Count != 3)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /tempcar target-id vehicle-name color]" }

                });
                return;
            }

            int playerHandle = int.Parse(args[0].ToString());
            
            Player _playerTarget = GetPlayerFromHandle(playerHandle);

            if (GetPlayerFromHandle(playerHandle) == null)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SERVER ERROR", "Invalid target ID to perform the command on. [ /tempcar target-id vehicle-model ]" }
                });
                return;

            }

            bool ColorParse = int.TryParse(args[2].ToString(), out int VehicleColor);

            if (ColorParse)
            {
                args.RemoveAt(0);
                TriggerClientEvent(_playerTarget, "dFRP:SpawnModel", args);
            }
            else
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /tempcar target-id vehicle-name color]" }

                });
                return;
            }
        }



        public void GiveWeapon(int source, List<object> args, string raw)
        {

            Player sourceID = GetPlayerFromHandle(source);

            if (args == null || !args.Any() || args.Count > 3)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /giveweapon target-id weapon-name ]" }
                });

                return;

            }

            int playerHandle = int.Parse(args[0].ToString());
            Player _playerTarget = GetPlayerFromHandle(playerHandle);


            if (GetPlayerFromHandle(playerHandle) == null)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SERVER ERROR", "Invalid target ID to perform the command on. [ /giveweapon target-id weapon-name ]" }
                });

                return;
            }

            args.RemoveAt(0);
            TriggerClientEvent(_playerTarget, "dFRP:GiveWeapon", args);

        }
        public void SetModel(int source, List<object> args, string raw)
        {

            Player sourceID = GetPlayerFromHandle(source);

            if (args == null || !args.Any() || args.Count != 2)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /setmodel target-id model-name ]" }
                });

                return;

            }

            int playerHandle = int.Parse(args[0].ToString());
            Player _playerTarget = GetPlayerFromHandle(playerHandle);


            if (GetPlayerFromHandle(playerHandle) == null)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SERVER ERROR", "Invalid target ID to perform the command on. [/setmodel target-id model-name]" }
                });


                return;
            }



            args.RemoveAt(0);
            TriggerClientEvent(_playerTarget, "dFRP:setModel", args);

        }


        public void CreateBlip(int source, List<object> args, string raw)
        {
            try
            {
                Player sourceID = GetPlayerFromHandle(source);
                var sourcePed = sourceID.Character.Handle;
            

                    

                if (args == null || !args.Any() || args.Count != 5)
                {
                    sourceID.TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        multiline = true,
                        args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /createblip sprite-id category-id color-id display-id legend-name ]" }
                    });

                    return;

                }


                bool spriteParse = int.TryParse(args[0].ToString(), out int spriteID);
                bool CategoryParse = int.TryParse(args[1].ToString(), out int CategoryID);
                bool ColorParse = int.TryParse(args[2].ToString(), out int ColorID);
                bool DisplayParse = int.TryParse(args[3].ToString(), out int DisplayID);

                string TitleParse = args[4].ToString();

                if (spriteParse && CategoryParse && ColorParse && DisplayParse)
                {
                    TriggerClientEvent(sourceID, "dFRP:CreateBlip", new List<object> { spriteID, CategoryID, ColorID, DisplayID, TitleParse });
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException("ERROR: Invalid object state used in the command - [/createblip]");
            }

        }

        public void CreateVehicle(int source, List<object> args, string raw)
        {
            Player sourceID = GetPlayerFromHandle(source);

            if (args == null || !args.Any() || args.Count != 3)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "SNYTAX ERROR", "Invalid Syntax - [ /createvehicle vehicle-name primary-color lock-status (true/false) ]" }
                });

                return;
            }

            var model = args[0].ToString();

            TriggerClientEvent(sourceID, "dFRP:CreateVehicle", new List<object> { model, args[1], args[2] });
        }

        /*public void RemoveVehicle(int source, List<object> args, string raw)
        {
            var sourceID = GetPlayerFromHandle(source);
            var sourcePedID = sourceID.Character.Handle;

            var currentVehicle = GetVehiclePedIsIn(sourcePedID, false);
            var vehicleString = currentVehicle.ToString();
            TriggerClientEvent(sourceID, "dFRP:DeleteVehicle", new List<object> { vehicleString }) ;
        }*/
        public void TeleportPlayer(int source, List<object> args, string raw)
        {
            string[] tpLocations = new string[] { "LSC", "Bennys" };
            Player sourceID = GetPlayerFromHandle(source);
            if(args == null || !args.Any() || args.Count != 1)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "@SNYTAX ERROR", "Invalid Syntax - [ /goto [location-name]\nVALID LOCATIONS: LSC - Bennys" }
                });

                return;
            }

            var locationTP = args[0].ToString();
            var isContained = tpLocations.Any(x => locationTP.Contains(x));
            if(!isContained)
            {
                sourceID.TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    multiline = true,
                    args = new[] { "LOCATION ERROR", "Invalid location - [ /goto [location-name]\nVALID LOCATIONS: LSC - Bennys" }
                });

                return;
            }

            TriggerClientEvent(sourceID, "dFRP:TeleportPlayer", new List<object> { args[0] });
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
