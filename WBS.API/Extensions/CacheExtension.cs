using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WBS.DAL.Layers;

namespace WBS.API.Extensions
{
    static class CacheExtension
    {
        public static void AddWBSCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddTransient<GetExpirationTime>(serviceProvider => () =>
            {
                var expirationString = configuration.GetSection("CacheSettings").GetSection("RelativeExpiration").Value;
                TimeSpan expTimespan;
                try
                {
                    expTimespan = TimeSpan.Parse(expirationString);
                }
                catch
                {
                    expTimespan = TimeSpan.FromMinutes(20); // hardcode defaultValue
                }
                return expTimespan;
            });
        }
    }
}
