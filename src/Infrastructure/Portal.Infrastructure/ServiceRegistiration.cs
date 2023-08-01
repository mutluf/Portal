using FloraAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Services;

namespace Portal.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();

        }
    }
}
