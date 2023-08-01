using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Survey;
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

        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public DbSet<AnsweredOption> AnsweredOptions { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }

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
