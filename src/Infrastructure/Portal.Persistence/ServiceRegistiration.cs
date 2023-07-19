using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Abstractions.Services;
using Portal.Application.Repositories;
using Portal.Domain.Entities.Users;
using Portal.Persistence.Context;
using Portal.Persistence.Repositories;
using Portal.Persistence.Services;

namespace Portal.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<PortalAPIDbContext>(options =>
            options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<ISeminarRepository, SeminarRepository>();
            services.AddScoped<IWorkshopRepository, WorkshopRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            services.AddScoped<IRoleService,RoleService>();

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;

            }
            ).AddEntityFrameworkStores<PortalAPIDbContext>();
        }
    }

    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager cfg = new ConfigurationManager();
                cfg.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Portal.WebAPI"));
                cfg.AddJsonFile("appsettings.json");//microsoft.extensions.configuration.json adındaki paket üst 2 satır için gerekli. çok gerekli

                return cfg.GetConnectionString("MicrosoftSQL");
            }
        }
    }
}
