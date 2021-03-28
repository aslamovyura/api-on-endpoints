using API.Filters;
using ApplicationCore.Entities.PostAggregate;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API
{
    public static class ApiDependencyInjection
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddMemoryCache();
            services.AddMediatR(typeof(Post).Assembly);
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.EnableAnnotations();
                c.SchemaFilter<CustomSchemaFilter>();
            });
        }
    }
}