using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Holodeck
{
    public class HoloDeckMiddleware : IMiddleware
    {
        private readonly ILogger<HoloDeckMiddleware> Logger;

        public HoloDeckMiddleware(ILogger<HoloDeckMiddleware> logger)
        {
            Logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Logger.LogInformation("Checking metadata exists");
            
            //TODO: make sure the request is for the default route


            await next(context);
        }
    }
}