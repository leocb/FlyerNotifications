using Flyer.Core.Models.Venues.MessageTemplates;
using System.Collections.Generic;

namespace Flyer.Core.Models.Venues.Spaces
{
    public class MessageTemplate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AllowedUsers { get; set; }
        public List<string> AllowedRoles { get; set; }
        public List<TemplateField> Fields { get; set; }
    }
}
