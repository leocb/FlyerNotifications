using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Flyer.Core.Models
{
    public class Member
    {
        [JsonPropertyName("UserGUID")]
        public string UserGUID { get; set; }

        [JsonPropertyName("IsAdmin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("AllowedSpaces")]
        public List<string> AllowedSpaces { get; set; }

        [JsonPropertyName("SubscribedSpaces")]
        public List<string> SubscribedSpaces { get; set; }

        [JsonPropertyName("AllowedTemplates")]
        public List<string> AllowedTemplates { get; set; }
    }
}
