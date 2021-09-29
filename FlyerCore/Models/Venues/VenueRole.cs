using System.Collections.Generic;

namespace Flyer.Core.Models.Venues
{
    public class VenueRole
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Color { get; set; }
        public List<string> Users{ get; set; }
        public bool IsAdmin { get; set; }
        public bool CanManageRoles { get; set; }
        public bool CanManageSpaces { get; set; }
        public bool CanManageMembers { get; set; }
        public bool CanManageTemplates { get; set; }
        public bool CanSendAnyMessage { get; set; }
        public bool CanSendAnyTemplatedMessage { get; set; }
    }
}
