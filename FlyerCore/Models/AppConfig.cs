using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace Flyer.Core.Models
{
    public class AppConfig
    {
        public List<MsgTemplate> Templates { get; set; }
        public BotConfig BotConfig { get; set; }
    }
}
