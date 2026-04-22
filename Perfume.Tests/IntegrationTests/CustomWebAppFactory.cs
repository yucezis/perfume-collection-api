using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Perfume.Data; 
using System.Linq;
using System.Data.Common;

namespace Perfume.Tests.IntegrationTests
{
    public class CustomWebAppFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbOptions = services.Where(d => d.ServiceType.Name.Contains("DbContextOptions")).ToList();
                foreach (var option in dbOptions)
                {
                    services.Remove(option);
                }

                var dbConnections = services.Where(d => d.ServiceType == typeof(DbConnection)).ToList();
                foreach (var conn in dbConnections)
                {
                    services.Remove(conn);
                }

                services.AddDbContext<PerfumeDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });
            });

            builder.UseEnvironment("Testing");
        }
    }
}