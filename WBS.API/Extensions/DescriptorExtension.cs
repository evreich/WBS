using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.DAL.Descriptors;

namespace WBS.API.Extensions
{
    static class DescriptorExtension
    {
        public static void AddDescriptors(this IServiceCollection services)
        {
            services.AddScoped<DescriptorOfFormGenerator>(); 
        }
    }
}
