using Flyer.Core.Models.Venues;
using System.Collections.Generic;

namespace Flyer.Core.Models
{
    public class Venue
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }
        public string BannerURL { get; set; }
        public bool IsPublic { get; set; }
        public List<string> UsersRequestingAccess { get; set; }
        public List<string> Users { get; set; }
        public List<VenueSpace> Spaces { get; set; }
        public List<VenueRole> Roles { get; set; }
    }
}
