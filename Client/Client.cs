using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;

namespace Client
{
    public class Client : BaseScript
    {

        private static volatile Client instance; // client instance [singelton]

        private static object syncRoot = new object(); // instance used to lock on to avoid deadlocks.

        public static readonly float DensityMultiplier = 1.0F;

        private bool firstTick = false;

        public Client()
        {
            Tick += OnTick; 
        }

        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Client();
                    }
                }
                return instance;
            }
        }

        public async Task OnTick()
        {
            if (!firstTick)
            {
                firstTick = true;
                API.SetCanAttackFriendly(API.GetPlayerPed(-1), true, false); // allows PVP
                API.NetworkSetFriendlyFireOption(true);
            }

            API.HideHudComponentThisFrame(6);
            API.HideHudComponentThisFrame(7);
            API.HideHudComponentThisFrame(8);
            API.HideHudComponentThisFrame(9);
            await Delay(0);
 
        }

    }
}
