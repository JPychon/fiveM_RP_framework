using CitizenFX.Core;
using MySqlConnector;

namespace DBAcesss
{
    public class DB_Connection : BaseScript
    {
        // DB connection info

        private const string SERVER = "127.0.0.1"; // DB Server IP

        private const string DATABASE = "fivem"; // DB Schema 

        private const string UID = "root"; // DB Login user

        private const string PASSWORD = ""; // DB Login password

        public static MySqlConnection DBConnection; // DB Connection object - MySQLConnector reference obj.
        public DB_Connection() { }

        public static void InitalizeDB() // static function to initalize the DB on server start-up
        {
            var DB_String_Builder = new MySqlConnectionStringBuilder(); // string builder to connect the connection info
            DB_String_Builder.Server = SERVER;
            DB_String_Builder.UserID = UID;
            DB_String_Builder.Password = PASSWORD;
            DB_String_Builder.Database = DATABASE;

            var DB_Connection_String = DB_String_Builder.ToString(); // parse into 1 string

            DB_String_Builder = null; // set to null to reset string

            DBConnection = new MySqlConnection(DB_Connection_String); // set the connection string

            Debug.WriteLine("[SERVER-DB] MySQL-Database initalization successful!");

        }
    }
}
