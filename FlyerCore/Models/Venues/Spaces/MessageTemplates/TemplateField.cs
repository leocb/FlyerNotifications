namespace Flyer.Core.Models.Venues.MessageTemplates
{
    public class TemplateField
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsNumeric { get; set; }
        public int MaxLength { get; set; }
        public string TextBefore { get; set; }
        public string TextAfter { get; set; }
        public string TextAfterIfRegex { get; set; }
        public string TextAfterIfRegexMatch { get; set; }
        public string TextAfterIfRegexDontMatch { get; set; }
    }
}
