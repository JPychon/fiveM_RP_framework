using CitizenFX.Core;
using Client.Models.Objects;
using System;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;

namespace Client.Controllers
{
    public class VehicleController : BaseScript
    {
        public VehicleController()
        {
            Tick += IsPlayerInVehicle;
        }

        public async Task IsPlayerInVehicle()
        {
            if (IsPedInAnyVehicle(PlayerPedId(), false))
            {
                var vSpeed = (GetEntitySpeed(GetVehiclePedIsIn(GetPlayerPed(-1), false)) * 2.2369);
                DisplaySpeedo((int)vSpeed);
            }

            await Task.FromResult(0);
        }

        public void DisplaySpeedo(int speed)
        {

            string sValue = speed.ToString();

            SetTextFont(1);
            SetTextScale(1.9F, 1.9F);
            SetTextEntry("STRING");
            AddTextComponentString(sValue);
            DrawText(0.18F, 0.9F);
        }
    }
}
