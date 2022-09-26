using System;
using System.Drawing;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using ScaleformUI;
using Client.Controllers;

namespace Client.Models.Menus
{
    public class cVehicleFactory : BaseScript
    {
        private UIMenu _vehicleMenu;

        private string vModel;

        public void vehicleMenu()
        {

            PointF screenCenter = new PointF(150, 150);
            _vehicleMenu = new UIMenu("Vehicle Menu", "Select a vehicle:", screenCenter, false);
            MenuController.AddMenu(_vehicleMenu);


            var GTR50 = new UIMenuItem("Nissan GTR 50");
            var AudiRS6 = new UIMenuItem("Audi RS6");
            var TFortySX = new UIMenuItem("Nissan 240 SX");
            var DChargeSRT = new UIMenuItem("Dodge Charger SRT");
            var MazdaRX = new UIMenuItem("Mazda RX");
            var HondaCivicTypeR = new UIMenuItem("Honda Civic Type R");
            var LamboGallardo = new UIMenuItem("Lamborghini Gallardo");
            var Audi9F = new UIMenuItem("Audi 9F");
            var BMWM6 = new UIMenuItem("BMW M6");
            var viper = new UIMenuItem("Dodge Viper SRT");
            var BMWM3 = new UIMenuItem("BMW M3");
            var BMWM5 = new UIMenuItem("BMW M5");
            var AudiS5 = new UIMenuItem("Audi S5");
            var AudiRS6X = new UIMenuItem("Audi RS6-X");
            var GTR = new UIMenuItem("Nissan GTR");
            var ToyotaSupra = new UIMenuItem("Toyota Supra JZA80");
            var BentleyCont = new UIMenuItem("Bentley Contenental GT");
            var BMWM2 = new UIMenuItem("BMW M2");
            var MitsuEVo9 = new UIMenuItem("Mitsubishi Evo 9");
            var PorscheCayenne = new UIMenuItem("Porsche Cayenne Turbo S");
            var MercG65 = new UIMenuItem("Mercedes G65");
            var MercSLS = new UIMenuItem("Mercedes SLS");
            var NissanSilvia = new UIMenuItem("Nissan Silvia");
            var MazdaRX7 = new UIMenuItem("Mazda RX7");
            var AudiRS6Prismo = new UIMenuItem("Audi RS6 Prismo");
            var Jesko = new UIMenuItem("Koenigsegg Jesko");
            var MercE63 = new UIMenuItem("Mercedes E63 AMG");
            var FerarriF40 = new UIMenuItem("Ferarri F40");
            var CamaraoZL1 = new UIMenuItem("Chevy Camaro ZL1");
            var RangeRover = new UIMenuItem("Range Rover");
            var BMWMH5 = new UIMenuItem("BMW Manhart MH5");
            var T800 = new UIMenuItem("Kenworth T800");
            var FordShelby = new UIMenuItem("Ford Mustang Shelby 500");
            var DodgeChallenger = new UIMenuItem("Dodge Challenger");
            var AstonMartin = new UIMenuItem("Aston Martin Vantage Zagato");
            var ToyotaLC = new UIMenuItem("Toyota Land Cruiser");
            var FerrariF12 = new UIMenuItem("Ferarri F12");
            var BuggatiDivo = new UIMenuItem("Bugatti Divo");
            var MercS63 = new UIMenuItem("Mercedes S63");
            var BMWG20 = new UIMenuItem("BMW G20");
            var MercG500 = new UIMenuItem("Mercedes G500");
            var RRDawnWald = new UIMenuItem("Rolls Royce Dawn Wald");
            var MercG900 = new UIMenuItem("Mercedes G900");
            var McLaren720 = new UIMenuItem("McLaren 720s");


            //BMW
            _vehicleMenu.AddItem(BMWM2);
            _vehicleMenu.AddItem(BMWM3);
            _vehicleMenu.AddItem(BMWM5);
            _vehicleMenu.AddItem(BMWM6);
            _vehicleMenu.AddItem(BMWMH5);
            _vehicleMenu.AddItem(BMWG20);
            //AUDI
            _vehicleMenu.AddItem(AudiS5);
            _vehicleMenu.AddItem(AudiRS6);
            _vehicleMenu.AddItem(AudiRS6X);
            _vehicleMenu.AddItem(AudiRS6Prismo);
            _vehicleMenu.AddItem(Audi9F);
            //Mercedes
            _vehicleMenu.AddItem(MercG65);
            _vehicleMenu.AddItem(MercE63);
            _vehicleMenu.AddItem(MercSLS);
            _vehicleMenu.AddItem(MercS63);
            _vehicleMenu.AddItem(MercG500);
            _vehicleMenu.AddItem(MercG900);
            //Nissan
            _vehicleMenu.AddItem(GTR);
            _vehicleMenu.AddItem(GTR50);
            _vehicleMenu.AddItem(NissanSilvia);
            _vehicleMenu.AddItem(TFortySX);
            //Dodge
            _vehicleMenu.AddItem(DChargeSRT);
            _vehicleMenu.AddItem(viper);
            _vehicleMenu.AddItem(DodgeChallenger);
            //Mazda
            _vehicleMenu.AddItem(MazdaRX);
            _vehicleMenu.AddItem(MazdaRX7);
            //Lamborghini
            _vehicleMenu.AddItem(LamboGallardo);
            //Toyoya
            _vehicleMenu.AddItem(ToyotaSupra);
            _vehicleMenu.AddItem(ToyotaLC);
            //Bentley
            _vehicleMenu.AddItem(BentleyCont);
            //Mitsubishi
            _vehicleMenu.AddItem(MitsuEVo9);
            //Porsche
            _vehicleMenu.AddItem(PorscheCayenne);
            //Honda
            _vehicleMenu.AddItem(HondaCivicTypeR);
            //Ferarri
            _vehicleMenu.AddItem(FerarriF40);
            _vehicleMenu.AddItem(FerrariF12);
            //Range Rover
            _vehicleMenu.AddItem(RangeRover);
            // Ford
            _vehicleMenu.AddItem(FordShelby);
            // Aston Martin
            _vehicleMenu.AddItem(AstonMartin);
            // Buggati
            _vehicleMenu.AddItem(BuggatiDivo);
            // Rolls Royce
            _vehicleMenu.AddItem(RRDawnWald);
            // McLaren 720s
            _vehicleMenu.AddItem(McLaren720);
            // GENERIC
            _vehicleMenu.AddItem(Jesko);
            _vehicleMenu.AddItem(T800);

            _vehicleMenu.OnItemSelect += async (sender, item, index) =>
            {
                if (Game.PlayerPed.IsInVehicle())
                {
                    int vehID = Game.PlayerPed.CurrentVehicle.Handle;
                    API.SetEntityAsMissionEntity(vehID, true, true);
                    API.DeleteVehicle(ref vehID);
                }
                if (item == McLaren720)
                {
                    MenuController.CloseAllMenus();
                    vModel = "m720";
                }
                if (item == MercG900)
                {
                    MenuController.CloseAllMenus();
                    vModel = "2020g900"; 
                }
                if(item == MercG900)
                {
                    MenuController.CloseAllMenus();
                    vModel = "2020g900";
                }
                if(item == MercG500)
                {
                    MenuController.CloseAllMenus();
                    vModel = "brabus500";
                }
                if(item == BMWG20)
                {
                    MenuController.CloseAllMenus();
                    vModel = "bmwg20";
                }
                if(item == MercS63)
                {
                    MenuController.CloseAllMenus();
                    vModel = "2018s63";
                }
                if (item == BuggatiDivo)
                {
                    MenuController.CloseAllMenus();
                    vModel = "bdivo";
                }
                if (item == FerrariF12)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmodf12tdf";
                }
                if (item == GTR50)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmodgtr50";
                }
                if (item == AudiRS6)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmodrs6";
                }
                if (item == TFortySX)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmod240sx"; 
                }
                if (item == DChargeSRT)
                {
                    MenuController.CloseAllMenus();
                    vModel = "nqsrt";
                }
                if (item == MazdaRX)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rx7veilside";
                }
                if (item == HondaCivicTypeR)
                {
                    MenuController.CloseAllMenus();
                    vModel = "EK9";
                }
                if (item == LamboGallardo)
                {
                    MenuController.CloseAllMenus();
                    vModel = "2013LP560";
                }
                if(item == Audi9F)
                {
                    MenuController.CloseAllMenus();
                    vModel = "ninef";
                }
                if (item == BMWM6)
                {
                    MenuController.CloseAllMenus();
                    vModel = "m6f13";
                }
                if (item == viper)
                {
                    MenuController.CloseAllMenus();
                    vModel = "Viper";
                }
                if (item == BMWM3)
                {
                    MenuController.CloseAllMenus();
                    vModel = "bmwm3e92";   
                }
                if (item == BMWM5)
                {
                    MenuController.CloseAllMenus();
                    vModel = "bmci";
                }
                if (item == AudiS5)
                {
                    MenuController.CloseAllMenus();
                    vModel = "auds5";
                }
                if (item == AudiRS6X)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rs666";
                }
                if (item == GTR)
                {
                    MenuController.CloseAllMenus();
                    vModel = "gtr";
                }
                if (item == ToyotaSupra)
                {
                    MenuController.CloseAllMenus();
                    vModel = "jza80";
                }
                if (item == BentleyCont)
                {
                    MenuController.CloseAllMenus();
                    vModel = "contgt13";
                }
                if (item == BMWM2)
                {
                    MenuController.CloseAllMenus();
                    vModel = "m2";
                }
                if (item == MitsuEVo9)
                {
                    MenuController.CloseAllMenus();
                    vModel = "evo9";
                }
                if (item == PorscheCayenne)
                {
                    MenuController.CloseAllMenus();
                    vModel = "cayenne";
                }
                if (item == MercG65)
                {
                    MenuController.CloseAllMenus();
                    vModel = "g65";
                }
                if (item == MercSLS)
                {
                    MenuController.CloseAllMenus();
                    vModel = "sls";
                }
                if (item == NissanSilvia)
                {
                    MenuController.CloseAllMenus();
                    vModel = "s15";
                }
                if (item == MazdaRX7)
                {
                    MenuController.CloseAllMenus();
                    vModel = "fd3s";
                }
                if (item == AudiRS6Prismo)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rs666";
                }
                if (item == Jesko)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmodjesko";
                }
                if (item == MercE63)
                {
                    MenuController.CloseAllMenus();
                    vModel = "e63amg";
                }
                if (item == FerarriF40)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmodf40";
                }
                if (item == CamaraoZL1)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmodzl1";
                }
                if (item == RangeRover)
                {
                    MenuController.CloseAllMenus();
                    vModel = "rmodrover";
                }
                if (item == BMWMH5)
                {
                    MenuController.CloseAllMenus();
                    vModel = "18mh5";
                }
                if (item == T800)
                {
                    MenuController.CloseAllMenus();
                    vModel = "bcsm";
                }
                if (item == FordShelby)
                {
                    MenuController.CloseAllMenus();
                    vModel = "foxshelby";
                }
                if (item == DodgeChallenger)
                {
                    MenuController.CloseAllMenus();
                    vModel = "16challenger";
                }
                if (item == AstonMartin)
                {
                    MenuController.CloseAllMenus();
                    vModel = "ASTZAG12";
                }
                if (item == RRDawnWald)
                {
                    MenuController.CloseAllMenus();
                    vModel = "bbdawn";
                }
                if (item == ToyotaLC)
                {
                    MenuController.CloseAllMenus();
                    vModel = "toyotasj";
                }

                var vehicle = await World.CreateVehicle(vModel, Game.PlayerPed.Position, Game.PlayerPed.Heading);
                Game.PlayerPed.SetIntoVehicle(vehicle, VehicleSeat.Driver);
                API.SetVehicleColours(vehicle.Handle, 112, 0);
                MenuController.CloseAllMenus();
                vModel = null;

            }; 

            _vehicleMenu.Visible = true;
        }

        public cVehicleFactory()
        {
            EventHandlers["dFRP:VehicleSpawnMenu"] += new Action(async () => 
                { 
                    vehicleMenu();
                    MenuController.CloseAllMenus();
                    await Delay(250);
                    vehicleMenu();
                });
        }
    }
}
