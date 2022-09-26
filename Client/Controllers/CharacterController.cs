using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using Client.Models.Player;
using Client.Utility;

namespace Client.Controllers
{
    public class CharacterController : BaseScript
    {

        public Character pChar { get; protected set; } // Client Character Object

        public static bool HasPlayerSpawned { get; set; } = false; // Flag to start saving the player data after spawn.
        public CharacterController()
        {
            Tick += savePlayerCharacter;

            EventHandlers["dFRP:createCharacter"] += new Action<string>(createCharacter);
            EventHandlers["dFRP:spawnPlayerCharacter"] += new Action<string>(spawnPlayerCharacter);
            EventHandlers["dFRP:revivePlayer"] += new Action<string>(revivePlayer);
        }

        public void createCharacter(string playerChar)
        {
            TriggerEvent("dFRP:startCreator", playerChar); // Triggers the character creator menu-sequence. [charFactory]
        }

        public async void spawnPlayerCharacter(string playerChar)
        {
            pChar = new Character(); // Initalizes the player character object
            pChar = JsonConvert.DeserializeObject<Character>(playerChar); // Deserializes the object to obtain the player's charachter information [NEW PLAYER: charFactory - RETURNING: DB Info]

            await Delay(5000);

            pChar = await SpawnManager.SpawnPlayer(pChar); // Spawns the player & updates firstSpawn for new players - returns the object to update it's properties.

            await Delay(5000);
            HasPlayerSpawned = true; // flag invoked to start saving the player data every 25 seconds [savePlayerCharacter]
        }
        public async Task savePlayerCharacter() // runs every 25 seconds - gets the player location/health/armor & sends the info to the server to be updated/saved in the DB.
        {
            if(HasPlayerSpawned)
            {
                Screen.LoadingPrompt.Show("Saving Player Data...", LoadingSpinnerType.SocialClubSaving);

                pChar = await pChar.getPedRenderLocation();
                var playerChar = JsonConvert.SerializeObject(pChar);
                TriggerServerEvent("dFRP:savePlayerCharacter", playerChar);

                Screen.LoadingPrompt.Hide();
                
                await Delay(25000); // Wait 25 seconds before invoking the function again.
            }
        }
        public static void revivePlayer(string sourceName)
        {
            Game.PlayerPed.ResetVisibleDamage();
            Game.PlayerPed.Resurrect();
            Game.PlayerPed.Health = Game.PlayerPed.MaxHealth;
            CommFuncs.DisplayNotify($"You have been revived by {sourceName}");
        }
    }
}
