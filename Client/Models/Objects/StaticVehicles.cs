using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using static CitizenFX.Core.Native.API;

namespace Client.Models.Objects
{
    public class StaticVehicles : BaseScript
    {
        public Model VehicleModel { get; set; }
        public Vector3 VehiclePosition { get; set; }
        public float VehicleHeading { get; set; }
        public VehicleColor VehColor { get; set; }
        public bool VehicleLock { get; set; }
        public int ServerVehicleID { get; set; }


        public static List<StaticVehicles> StaticVehiclesData = new List<StaticVehicles>();

        public static List<StaticVehicles> IntroVehiclesData = new List<StaticVehicles>()
        {
             new StaticVehicles() { VehiclePosition = new Vector3 { X = 96.06F, Y = -1745.82F, Z= 28.71F }, VehicleHeading = 321.22F, VehicleLock = true, VehColor = VehicleColor.Blue, VehicleModel = VehicleHash.Tailgater },
             new StaticVehicles() { VehiclePosition = new Vector3 { X = 99.82F, Y = -1749.57F, Z= 28.72F }, VehicleHeading = 320.15F, VehicleLock = true, VehColor = VehicleColor.MatteRed, VehicleModel = VehicleHash.Stanier },
             new StaticVehicles() { VehiclePosition = new Vector3 { X = 103.39F, Y = -1752.55F, Z= 28.72F }, VehicleHeading = 318.37F, VehicleLock = true, VehColor = VehicleColor.WornTaxiYellow, VehicleModel = VehicleHash.Primo },
             new StaticVehicles() { VehiclePosition = new Vector3 { X = 120.11F, Y = -1768.5F, Z= 28.73F }, VehicleHeading = 33.52F, VehicleLock = true, VehColor = VehicleColor.UtilDarkBlue, VehicleModel = VehicleHash.Warrener },
             new StaticVehicles() { VehiclePosition = new Vector3 { X = 114.39F, Y = -1760.91F, Z= 28.73F }, VehicleHeading = 226.59F, VehicleLock = true, VehColor = VehicleColor.EpsilonBlue, VehicleModel = VehicleHash.Seminole },
             new StaticVehicles() { VehiclePosition = new Vector3 { X = 114.05F, Y = -1755.0F, Z= 28.72f }, VehicleHeading = 49.45F, VehicleLock = true, VehColor = VehicleColor.MetallicCandyRed, VehicleModel = VehicleHash.Washington }
        };


        public StaticVehicles()
        {
            EventHandlers["dFRP:LoadStaticVehicles"] += new Action(LoadStaticVehicles);
            EventHandlers["dFRP:UnloadStaticVehicles"] += new Action(UnloadStaticVehicles);
        }


        public async void SpawnStaticVehicles()
        {
            int ped = PlayerPedId();
            Vector3 currentPos = GetEntityCoords(ped, false);
            var veh = await World.CreateVehicle(VehicleModel, VehiclePosition, VehicleHeading);
            veh.Mods.PrimaryColor = VehColor;
            API.SetVehicleDoorsLockedForAllPlayers(veh.Handle, VehicleLock);
            Game.PlayerPed.SetIntoVehicle(veh, VehicleSeat.Driver);
            ServerVehicleID = veh.Handle;
            StaticVehiclesData.Add(this);
        }

        public static int CollectStaticVehicleID()
        {
            Ped Player = Game.Player.Character;
            var veh = GetClosestVehicle(Player.Position.X, Player.Position.Y, Player.Position.Z, 50, 0, 70);
            return veh;
        }

        public async void LoadStaticVehicles()
        {
            foreach(var car in IntroVehiclesData)
            {
                StaticVehiclesData.Add(car);
            }

            foreach (var car in StaticVehiclesData)
            {
                if (StaticVehiclesData != null)
                {
                    var sVehicle = await World.CreateVehicle(car.VehicleModel, car.VehiclePosition, car.VehicleHeading);
                    sVehicle.Mods.PrimaryColor = car.VehColor;
                    if(car.VehicleLock == true)
                    {
                        API.SetVehicleDoorsLocked(sVehicle.Handle, 3);
                    }

                    API.SetVehicleDoorsLockedForAllPlayers(sVehicle.Handle, car.VehicleLock);
                }
            }
        }

        public void UnloadStaticVehicles()
        {
            foreach(var car in StaticVehiclesData)
            {
                int vID = car.ServerVehicleID;
                SetEntityAsMissionEntity(vID, true, true);
                API.DeleteVehicle(ref vID);
            }
        }

    }
}