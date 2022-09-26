using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using DBAcesss;


namespace Server
{
    public class Server : BaseScript
    {
        private static volatile Server instance; // server instance [singelton]

        private static object syncRoot = new object(); // instance used to lock on to avoid deadlocks.

        public static bool firstTick = false; // firstTick for the server upon initilization. 

     
        public Server()
        {
            Tick += OnTick; // Tick Register
            DB_Connection.InitalizeDB();


            EventHandlers["dFRP:UpdateBlipData"] += new Action(UpdateBlipData); // Upadte blip list for all players.
        }

        public static Server Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Server();
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
            }


            // API Calls & Events

            await Delay(1000);
        }

   
        public void UpdateBlipData()
        {
            TriggerClientEvent("dFRP:ReloadBlips");
        }

    }
}