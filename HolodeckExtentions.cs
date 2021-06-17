using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.StaticFiles;
using Microsoft.Extensions.DependencyInjection;

namespace Holodeck
{
    public static class HoloDeckExtensions
    {
        public static void UseHoloDeck(this IApplicationBuilder app, Action<ISpaBuilder> configuration)
        {
        }

        public static void AddHoloDeck(this IServiceCollection services)
        {
            services.AddTransient<HoloDeckMiddleware>();
            // TODO: prob should be a scoped?
            services.AddTransient<MetaDetector>();
        }
        
        // public static void UseHoloSpa(this IApplicationBuilder app, Action<ISpaBuilder> configuration)
        // {
        // }
    }

    
}