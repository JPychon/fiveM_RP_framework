using CitizenFX.Core;
using DBAcesss;
using Newtonsoft.Json;
using Server;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core.Native;

namespace Server.Controllers
{
    public class CharacterController : BaseScript
    {
        private static int pRoutingBucket { get; set; } = 1;

        public CharacterController()
        {
            EventHandlers["dFRP:addNewCharacter"] += new Action<Player, string>(addNewCharacter);
            EventHandlers["dFRP:loadPlayerCharacter"] += new Action<Player, string>(loadPlayerCharacter);
            EventHandlers["dFRP:resetPlayerBucket"] += new Action<Player>(resetPlayerBucket);
            EventHandlers["dFRP:savePlayerCharacter"] += new Action<Player, string>(updateCharacterData);
        }

        public static async void updateCharacterData([FromSource] Player source, string pChar)
        {
            var playerChar = JsonConvert.DeserializeObject<Models.Character>(pChar);
            await DB_Character.update_character_runtime_values(playerChar);
        }

        public static void resetPlayerBucket([FromSource] Player source)
        {
            API.SetPlayerRoutingBucket(source.Handle, 0);
            pRoutingBucket--;
        }

        public static void createCharacter([FromSource] Player source, Guid userID)
        {
            var playerChar = new Character
            {
                Id = userID
            };

            string userObject = JsonConvert.SerializeObject(playerChar);


            API.SetPlayerRoutingBucket(source.Handle, pRoutingBucket);
            pRoutingBucket++;

            TriggerClientEvent(source, "dFRP:createCharacter", userObject, pRoutingBucket);
        }

        public static async void addNewCharacter([FromSource] Player source, string charObject)
        {
            Character playerChar = new Character();
            var playerName = API.GetPlayerName(source.Handle);
            playerChar = JsonConvert.DeserializeObject<Character>(charObject);
            await DB_Character.insert_character(playerChar);

            Debug.WriteLine($"[SERVER-DB] Succesfully added new character to the database! [user: {playerName}]");
        }

        public static async void loadPlayerCharacter([FromSource] Player source, string userID)
        {
            var userDB_ID = JsonConvert.DeserializeObject<Guid>(userID);
            var playerName = API.GetPlayerName(source.Handle);
            List<Character> charList = await DB_Character.load_Characters();
            Character playerChar = charList.FirstOrDefault(x => x.Id == userDB_ID);
            if(playerChar != null)
            {
                string charInfo = JsonConvert.SerializeObject(playerChar);
                TriggerClientEvent(source, "dFRP:spawnPlayerCharacter", charInfo);
                Debug.WriteLine($"[SERVER-DB]: Sucess! Character found in the database! [user: {playerName}]");
            }
            else
            {
                Debug.WriteLine($"[SERVER-DB]: Failure! No character found in the database! [user: {playerName}]");
                createCharacter(source, userDB_ID);
            }
        }
    }
}
