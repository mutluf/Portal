using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Users;

namespace Portal.Persistence.Context
{
    public class PortalAPIDbContext : IdentityDbContext<User, Role, int>
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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryUser>().HasKey(cu => new { cu.CategoryId, cu.UserId });

            modelBuilder.Entity<CategoryUser>()
                .HasOne(cu => cu.User)
                .WithMany(c => c.Categories)
                .HasForeignKey(cu => cu.UserId);

            modelBuilder.Entity<CategoryUser>()
                .HasOne(cu => cu.Category)
                .WithMany(u => u.Users)
                .HasForeignKey(cu => cu.CategoryId);
        }
    }
}
