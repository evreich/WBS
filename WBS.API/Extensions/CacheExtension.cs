using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WBS.DAL;
using WBS.DAL.Cache;
using WBS.DAL.Models;

namespace WBS.API.Extensions
{
    static class CacheExtension
    {
        public static void AddWBSCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICache>(serviceProvider =>
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
                return new WBSMemoryCache(serviceProvider.GetService<IMemoryCache>(), expTimespan);
            });
        }
    }
}
