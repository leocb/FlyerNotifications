using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Flyer.Core.Models
{
    public class Venue
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Icon")]
        public string Icon { get; set; }

        [JsonPropertyName("IsEnabled")]
        public bool IsEnabled { get; set; }

        [JsonPropertyName("IsPublic")]
        public bool IsPublic { get; set; }

        [JsonPropertyName("Members")]
        public List<Member> Members { get; set; }

        [JsonPropertyName("Spaces")]
        public List<Space> Spaces { get; set; }
    }
}
