using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;

namespace Client.Utility
{
    public class CommFuncs : BaseScript
    {
        public CommFuncs()
        {
            EventHandlers["dFRP:VehicleInfo::Speed"] += new Action<int>(DisplaySpeedo);
        }
        public static void DisplaySubTitle(string msg, int time)
        {
            API.ClearPrints();
            API.SetTextEntry_2("STRING");
            API.AddTextComponentString(msg);
            API.DrawSubtitleTimed(time, true);
        }

        public static void DisplayMessage(string title, string message, int r, int g, int b)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { r, g, b },
                multiline = true,
                args = new[] { title, message }
            });
        }
        public static void DisplayNotify(string message)
        {
            Screen.ShowNotification(message, false);
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

        // USER INPUT DIALOG BOX.

        public static async Task<string> GetUserInput(int maxLength) // input-box with no text.
        {
            return await GetUserInput(WindowTitle.FMMC_KEY_TIP8, string.Empty, maxLength);
        }

        public static async Task<string> GetUserInput(string defaultText, int maxLength) // input-box with default-text for the box.
        {
            return await GetUserInput(WindowTitle.FMMC_KEY_TIP8, defaultText, maxLength);
        }

        public static async Task<string> GetUserInputCustom(string customTitle, int maxLength) // input-box with a custom title.
        {
             return await GetUserInputCustom(customTitle, string.Empty, maxLength);
        }

        public static async Task<string> GetUserInput(WindowTitle windowTitle, int maxLength) // input-box with a specefic windowTitle
        {
            return await GetUserInput(windowTitle, string.Empty, maxLength);
        }

        public static async Task<string> GetUserInput(WindowTitle windowTitle, string defaultText, int maxLength) // input-box with all parameters provided.
        {

            API.DisplayOnscreenKeyboard(1, windowTitle.ToString(), null, defaultText, null, null, null, maxLength + 1);
            await Delay(0);

            while (true)
            {
                int KeyboardStatus = UpdateOnscreenKeyboard();
                switch (KeyboardStatus)
                {
                    case 3:
                    case 2: return null;
                    case 1: return GetOnscreenKeyboardResult();
                    default:
                        await Delay(0);
                        break;
                }
            }
        }

        public static async Task<string> GetUserInputCustom(string windowTitle, string defaultText, int maxLength) // input-box with all parameters provided & a custom title.
        {
            API.AddTextEntry("FMMC_MPM_NA", windowTitle);
            API.DisplayOnscreenKeyboard(1, "FMMC_MPM_NA", null, defaultText, null, null, null, maxLength + 1);
            await Delay(0);

            while (true)
            {
                int KeyboardStatus = UpdateOnscreenKeyboard();
                switch (KeyboardStatus)
                {
                    case 3:
                    case 2: return null;
                    case 1: return GetOnscreenKeyboardResult();
                    default:
                        await Delay(0);
                        break;
                }
            }
        }
        //-----------------//
    }
}