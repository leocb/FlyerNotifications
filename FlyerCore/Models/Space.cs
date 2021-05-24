using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flyer.Core.Models
{
    public class Space
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

        [JsonPropertyName("MessageTemplates")]
        public List<MessageTemplate> MessageTemplates { get; set; }

        [JsonPropertyName("Messages")]
        public List<Message> Messages { get; set; }
    }
}
