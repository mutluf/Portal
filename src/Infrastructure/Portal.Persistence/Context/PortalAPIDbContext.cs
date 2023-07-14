using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Users;

namespace Portal.Persistence.Context
{
    public class PortalAPIDbContext : IdentityDbContext<User, Role, string>
    {
        public PortalAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
    }
}
