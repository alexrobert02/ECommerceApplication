using ECommerceApplication.Application.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureRegistrationDI
    {
        public static IServiceCollection AddInfrastrutureToDI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ECommergeApplicationContext>(
                options =>
                options.UseNpgsql(
                    configuration.GetConnectionString
                    ("ECommerceApplicationConnection"),
                    builder =>
                    builder.MigrationsAssembly(
                        typeof(ECommergeApplicationContext)
                        .Assembly.FullName)));
            services.AddScoped
                (typeof(IAsyncRepository<>),
                typeof(BaseRepository<>));
            services.AddScoped<
                ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
