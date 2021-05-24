using System.Text.Json.Serialization;

namespace Flyer.Core.Models
{
    public class Field
    {
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("IsNumeric")]
        public bool IsNumeric { get; set; }

        [JsonPropertyName("IsRequired")]
        public bool IsRequired { get; set; }

        [JsonPropertyName("MaxLength")]
        public int MaxLength { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("TextAfter")]
        public string TextAfter { get; set; }

        [JsonPropertyName("TextAfterIf")]
        public string TextAfterIf { get; set; }

        [JsonPropertyName("TextAfterIfCondition")]
        public string TextAfterIfCondition { get; set; }

        [JsonPropertyName("TextBefore")]
        public string TextBefore { get; set; }
    }
}
