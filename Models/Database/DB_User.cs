using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using MySqlConnector;
using Server.Models;

namespace DBAcesss
{
    public class DB_User : BaseScript
    {
       
        // DB user connection info 

        public Guid ID { get; private set; } // player ID
        public string USER_NAME { get; private set; } // player user-name
        public string USER_PASSWORD { get; private set; } // player password 
        public DateTime DATE_CREATED { get; private set; } // Date user created

        // 

        public DB_User() { } // default contructor

        public DB_User(Guid I, string U, string P, DateTime C) // parametric constructor
        {
            ID = I;
            USER_NAME = U;
            USER_PASSWORD = P;
            DATE_CREATED = C;
        }

        public static async Task<List<User>> Load_Users() // loads a list of users from the DB - returns a list<DB_user>
        {
            List<User> userList = new List<User>(); // List to hold all user info

            string userQuery = "SELECT * FROM users"; // SQL query-string to hold execute in the DB

            MySqlCommand userCommand = new MySqlCommand(userQuery, DB_Connection.DBConnection); // command object to execute the query

            await DB_Connection.DBConnection.OpenAsync(); //
            using (var userList_Reader = await userCommand.ExecuteReaderAsync())

            if (await userList_Reader.ReadAsync()) // loop to read user id/name/pass - convert to string & store into a new DB_User object - then adds to the userlist
            {
                Guid id = userList_Reader.GetGuid(0);
                string username = userList_Reader["username"].ToString();
                string password = userList_Reader["password"].ToString();
                DateTime DateCreated = userList_Reader.GetDateTime(3);


                User userInfo = new User
                {
                    Id = id,
                    name = username,
                    password = password,
                    Created = DateCreated
                };


                userList.Add(userInfo);
            }

            await DB_Connection.DBConnection.CloseAsync(); // close the connection

            return userList; // return the userlist
        }


        public static async Task Insert_User(User user) // inserts a new user into the database
        {
           var DateCreated = user.Created;
           string DateCreatedFormatted = DateCreated.ToString("yyyy-MM-dd H:mm:ss");

           string insertQuery = string.Format("INSERT INTO users(id, username, password, DateCreated) VALUES('{0}', '{1}', '{2}', '{3}')", user.Id, user.name, user.password, DateCreatedFormatted); // insertion query string
           MySqlCommand insertCommand = new MySqlCommand(insertQuery, DB_Connection.DBConnection); // insertion command

           await  DB_Connection.DBConnection.OpenAsync();
           await insertCommand.ExecuteNonQueryAsync();
           await DB_Connection.DBConnection.CloseAsync();
        }
        public static async Task update_user_name(User user, string newName)// updates user name
        {
            string updateQuery = string.Format("UPDATE users SET username='{0}' WHERE id={1}", newName, user.Id); // update query string
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, DB_Connection.DBConnection); // update command

            await DB_Connection.DBConnection.OpenAsync();
            await updateCommand.ExecuteNonQueryAsync();
            await DB_Connection.DBConnection.CloseAsync();
        }

        public static async Task update_user_password(User user, string newPassword) // updates user password
        {
            string updateQuery = string.Format("UPDATE users SET password='{0}' WHERE id={1}", newPassword, user.Id); // update query string
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, DB_Connection.DBConnection); // update command

            await DB_Connection.DBConnection.OpenAsync();
            await updateCommand.ExecuteNonQueryAsync();
            await DB_Connection.DBConnection.CloseAsync();
        }

        public static async Task delete_user(User user) // deletes a user [through ID]
        {
            string deleteQuery = string.Format("DELETE FROM users WHERE ID={0}", user.Id); // delete query string
            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, DB_Connection.DBConnection); // delete command

            await DB_Connection.DBConnection.OpenAsync();
            await deleteCommand.ExecuteNonQueryAsync();
            await DB_Connection.DBConnection.CloseAsync();
        }

    }
}
