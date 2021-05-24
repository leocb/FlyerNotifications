using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flyer.Core.Models
{
    public class MessageTemplate
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("IsEnabled")]
        public bool IsEnabled { get; set; }

        [JsonPropertyName("Fields")]
        public List<Field> Fields { get; set; }
    }
}
