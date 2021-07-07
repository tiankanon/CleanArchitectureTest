using System.Reflection;
using CleanArchitectureTest.Application.Interfaces;
using CleanArchitectureTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
            // configuration => configuration.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("DataSource=../CleanArchitectureTest.Infrastructure/Persistence/Sqlite/Data/cleanarchitecturetest.db",
            configuration => configuration.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }
    }
}