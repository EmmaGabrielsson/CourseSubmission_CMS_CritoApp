
using Crito.Contexts;
using Crito.Repositories;
using Microsoft.EntityFrameworkCore;
using Umbraco.Cms.Core.Services;

namespace Crito
{
    public class Program
    {        

        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureUmbracoDefaults()
                .ConfigureServices((IServiceCollection services) =>
                {
                    var builder = WebApplication.CreateBuilder(args);

                    // Contexts
                    services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabase")));

                    // Repositories
                    services.AddScoped<ContactFormRepo>();
                    services.AddScoped<SubscriberRepo>();

                    // Services
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
