using System.Text.Json.Serialization;

namespace Flyer.Core.Models
{
    public class Message
    {
        [JsonPropertyName("Content")]
        public string Content { get; set; }

        [JsonPropertyName("CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("CreatedOn")]
        public string CreatedOn { get; set; }

        [JsonPropertyName("TemplateGUID")]
        public string TemplateGUID { get; set; }
    }
}
