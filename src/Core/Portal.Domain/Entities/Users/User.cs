using Microsoft.AspNetCore.Identity;

namespace Portal.Domain.Entities.Users
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Participant Participant { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<CategoryUser>? Categories { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
