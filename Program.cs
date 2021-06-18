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
                        Source = @"<h1>{{title}}</h1><p>Welcome to your new single-page application, built with:</p><ul> <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a>for cross-platform server-side code</li> <li><a href='https://angular.io/'>Angular</a> and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li> <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li> </ul> <p>To help you get started, we've also set up:</p> <ul> <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li> <li><strong>Angular CLI integration</strong>. In development mode, there's no need to run <code>ng serve</code>. It runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li> <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration automatically invokes <code>ng build</code> to produce minified, ahead-of-time compiled JavaScript files.</li> </ul> <p>The <code>ClientApp</code> subdirectory is a standard Angular CLI application. If you open a command prompt in that directory, you can run any <code>ng</code> command (e.g., <code>ng test</code>), or use <code>npm</code> to install extra packages into it.</p>",
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