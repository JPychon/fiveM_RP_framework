using System.IO;
using System.Threading.Tasks;
using CitizenFX.Core;


namespace Server.Utility
{
    public class CommFuncs : BaseScript
    {
        public static void DisplayMessage(Player player, string title, string message, int r, int g, int b)
        {
            player.TriggerEvent("chat:addMessage", new
            {
                color = new[] { r, g, b },
                multiline = true,
                args = new[] { title, message }
            });
        }

        public static async Task WriteFileAsync(string dir, string file, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file)))
            {
                await outputFile.WriteAsync(content);
            }
        }

    }
}
