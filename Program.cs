using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Holodeck
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<MetaContext>();

                await using (context)
                {
                    await context.Database.EnsureCreatedAsync();

                    await context.Metas.AddAsync(new MetaData()
                    {
                        Id = new Guid("13813F58-6C1D-4456-95F2-BB862D7A0803"),
                        Name = "Chatsubo"
                    });

                    await context.Templates.AddAsync(new Template()
                    {
                        Id = Guid.NewGuid(),
                        Path = "/",
                        Source = "<div>Hello World</div>",
                        Updated = DateTime.Now,
                        MetaId = new Guid("13813F58-6C1D-4456-95F2-BB862D7A0803")
                    });

                    await context.SaveChangesAsync();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}