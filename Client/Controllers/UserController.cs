using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static Client.Utility.CommFuncs;

namespace Client.Controllers
{
    public class UserController : BaseScript
    {
        public static bool validationProcess { get; set; } = false; // boolean to detect when the player is validating/creating a password for the account.
        public UserController()
        {
            TriggerServerEvent("dFRP:NeedLicense"); //- When player connects -> client requests license/ID from the server [STEP 1]

            EventHandlers["dFRP:returnlicense"] += new Action<string>(ReceivedLicense); // License/ID recieved from the server[STEP 2]
            EventHandlers["dFRP:registerUser"] += new Action<string>(registerUser); //- Post validation, server triggers the registeration process if account NOT found [STEP 3]
            EventHandlers["dFRP:loginUser"] += new Action<string>(loginUser); // - Post validation, server triggers the login process if account IS found [STEP 3]
            EventHandlers["dFRP:loginSuccess"] += new Action<string, string>(onLoginSuccess); // Post password validation -> client recieves licenses & userID to load the player char
            EventHandlers["dFRP:loginFail"] += new Action<string>(onLoginFail); // Post password validation -> client repeats the login process for the user.
            

            Tick += AuthenticationCancellation;
        }
        public static void ReceivedLicense(string licenseID) // recieves player license from the server [username]
        {
            TriggerServerEvent("dFRP:validatePlayer"); // Triggers the server event to validate the player information.
        }

        public static async void registerUser(string playerLicense) // Shows the input box for the user to input a password & register a new account.
        {
            string TextEntry = "DeFacto RPG - Please insert a password to register your account.";
            var password = await GetUserInputCustom(TextEntry, 100);
            validationProcess = true;
            
            TriggerServerEvent("dFRP:registerationComplete", password); // triggers the server event to add the user info to the DB.
            validationProcess = false;
        }

        public static async void loginUser(string playerLicense) // Shows the input box for the user to input a password to login.
        {

            string TextEntry = "DeFacto RPG - Please insert your password to login";
            var password = await GetUserInputCustom(TextEntry, 100);
            validationProcess = true;
            TriggerServerEvent("dFRP:loginRequest", password); // triggers the serverr event to validate the user password.
        }

        public static void onLoginSuccess(string playerLicense, string userID) // spawns the char if the password enter is valid.
        {
            DisplayNotify("You have succesfully logged in - welcome!");
            validationProcess = false;
            TriggerServerEvent("dFRP:loadPlayerCharacter", userID);
            API.DoScreenFadeOut(500);
        }

        public static async void onLoginFail(string playerLicense) // allows the user to input the password again if the initial input doesnt match.
        {
            string TextEntry = "You have inserted a wrong password, please try again!";
            var password = await GetUserInputCustom(TextEntry, 100);
            TriggerServerEvent("dFRP:loginRequest", password); // triggers the server event again to revalidate.
        }

        public async Task AuthenticationCancellation()
        {
            if (validationProcess)
            {
                if (API.IsDisabledControlPressed(0, 202)) // kicks the player if ESC pressed during login/registeration
                {
                    string dropReason = "You have cancelled the login/registeration process.";
                    TriggerServerEvent("dFRP:dropPlayer", dropReason);
                }
            }

            await Delay(0);
        }
    }
}
