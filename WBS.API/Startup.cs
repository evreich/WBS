using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WBS.API.Extensions;
using NLog.Web;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace WBS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                   builder => builder.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader()
                                     .AllowCredentials()
                                     .Build());
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddLogging();
            services.AddErrorHandlers();
            services.AddWBSDALServices(Configuration);
            services.AddWBSCacheServices(Configuration);
            services.AddWBSAuthServices(Configuration);
            services.AddDescriptors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //настройка логгирования
            env.ConfigureNLog(Configuration.GetValue<string>("NLogConfigName"));
            loggerFactory.AddNLog();

            app.UseRequestResponseLogging();
            app.UseAuthentication();
            app.UseCors("AllowAnyOrigin");
            app.UseErrorHandlerMiddleware();
            app.UseMvc();
        }
    }
}
