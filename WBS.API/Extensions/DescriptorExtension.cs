using Microsoft.Extensions.DependencyInjection;
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
