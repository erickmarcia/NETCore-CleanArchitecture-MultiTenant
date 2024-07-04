using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantService.Application.DataBase;
using MultiTenantService.Application.Feactures.Auth;
using MultiTenantService.Persistence.DataBase;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MultiTenantService.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            // Obtener la configuración del motor de base de datos
            var databaseEngine = configuration["DatabaseSettings:DatabaseEngine"];

            // Configuración de DbContext para Organización
            ConfigureDbContext<OrgDbContext>(services, configuration, databaseEngine, "OrgDb");
            services.AddScoped<IOrgDbContext, OrgDbContext>();

            // Configuración de DbContext para Productos
            ConfigureDbContext<ProductoDbContext>(services, configuration, databaseEngine, "ProductDb");
            services.AddScoped<IProductoDbContext, ProductoDbContext>();

            return services;
        }

        private static void ConfigureDbContext<TContext>(IServiceCollection services, IConfiguration configuration, string databaseEngine, string connectionStringName) where TContext : DbContext
        {
            var connectionString = configuration[$"DatabaseSettings:ConnectionStrings:{connectionStringName}"];
            switch (databaseEngine)
            {
                case "SqlServer":
                    services.AddDbContext<TContext>(options =>
                       options.UseSqlServer(connectionString, x => x.UseNetTopologySuite()));
                    break;

                case "PostgreSQL":
                    services.AddDbContext<TContext>(options =>
                       options.UseNpgsql(connectionString));
                    break;

                case "MySQL":
                                   services.AddDbContext<TContext>(options =>
                                       options.UseMySql(connectionString, 
                                       ServerVersion.AutoDetect(connectionString),
                                        mySqlOptions =>
                                        {
                                            mySqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                                        }
                                       ));
                  break;

           
                default:
                    throw new Exception($"Unsupported database engine: {databaseEngine}");
            }
        }
    }
}
