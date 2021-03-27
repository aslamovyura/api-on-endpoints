using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(c => c.UseInMemoryDatabase("Application"));
        }
    }
}