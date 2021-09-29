using Flyer.Core.Models.Users;

namespace Flyer.Core.Models
{
    public class User
    {
        public UserPrivate Private { get; set; }
        public UserPublic Public { get; set; }
    }
}
