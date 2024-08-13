using Adapter.PostgreSQL.Context;
using Adapter.PostgreSQL.Repositories;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.PostgreSQL;

public static class Startup
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PostgreSqlContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UsuarioDal>();
        services.AddScoped<IProductRepository, ProdutoDal>();

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var dbContext = serviceProvider.GetRequiredService<PostgreSqlContext>();
            dbContext.MigrateDatabase();
        }
        
        return services;
    }
}
