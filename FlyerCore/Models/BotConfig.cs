using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Core.Models
{
    public class BotConfig
    {
        public BotConfig()
        {
            Token = File.ReadAllText(".token");
            AppClientID = File.ReadAllText(".appclientid");
        }

        // Permissions: Bot, Application.Commands
        // Bot General Permissions: View Server Insights, All Manages, Create invite, View Channels
        // Bot Text Permissions: Send Messages, Manage Messages, read Message history, Add Reactions, Use Slash Commands
        public string OAuth2URL => $@"https://discord.com/api/oauth2/authorize?client_id={AppClientID}&permissions=2416520305&redirect_uri=https%3A%2F%2Fdiscord.events.stdlib.com%2Fdiscord%2Fauth%2F&scope=bot%20applications.commands";
        public string AppClientID { get; }
        public string Token { get; }
    }
}
