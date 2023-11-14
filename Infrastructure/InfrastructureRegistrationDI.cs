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
            services.AddDbContext<ECommerceApplicationContext>(
                options =>
                options.UseNpgsql(
                    configuration.GetConnectionString
                    ("ECommerceApplicationConnection"),
                    builder =>
                    builder.MigrationsAssembly(
                        typeof(ECommerceApplicationContext)
                        .Assembly.FullName)));
            services.AddScoped
                (typeof(IAsyncRepository<>),
                typeof(BaseRepository<>));
            services.AddScoped<
                ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
