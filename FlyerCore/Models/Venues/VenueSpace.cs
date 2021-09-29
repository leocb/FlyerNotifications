using Flyer.Core.Models.Venues.Spaces;
using System.Collections.Generic;

namespace Flyer.Core.Models.Venues
{
    public class VenueSpace
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AllowedUsers { get; set; }
        public List<string> AllowedRoles { get; set; }
        public List<MessageTemplate> MessageTemplates { get; set; }
        public List<SpaceMessage> Messages { get; set; }


    }
}
