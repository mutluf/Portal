using Microsoft.AspNetCore.Identity;

namespace Portal.Domain.Entities.Users
{
    public class User : IdentityUser<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Participant Participant { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
