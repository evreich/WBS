using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WBS.DAL;
using WBS.DAL.Cache;
using WBS.DAL.Models;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Models.ViewModels;

namespace WBS.API.Extensions
{
    static class DALExtension
    {
        public static void AddWBSDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<AbstractDAL<TypeOfInvestment>, TypesOfInvestmentDAL>();
            services.AddScoped<AbstractDAL<ResultCenter>, ResultCentresDAL>();
            services.AddScoped<AbstractDAL<CategoryGroup>, CategoryGroupsDAL>();
            services.AddScoped<AbstractDAL<CategoryOfEquipment>, CategoriesOfEquipmentDAL>();
            services.AddScoped<AbstractDAL<Provider>, ProviderDAL>();
            services.AddScoped<AbstractDAL<Format>, FormatDAL>();
            services.AddScoped<AbstractDAL<Site>, SiteDAL>();
            services.AddScoped<AbstractDAL<BudgetPlan>, BudgetPlanDAL>();
            services.AddScoped<AbstractDAL<Event>, EventsDAL>();
            services.AddScoped<AbstractDAL<ItemOfBudgetPlan>, ItemsOfBudgetPlanDAL>();
            services.AddScoped<AbstractDAL<TechnicalService>, TechnicalServiceDAL>();
            services.AddScoped<AbstractDAL<DAIRequest>, DAIRequestDAL>();
            services.AddScoped<AbstractDAL<RationaleForInvestment>, RationaleForInvestmentsDAL>();
            services.AddScoped<AbstractDAL<ProvidersTechnicalService>, ProvidersTechnicalServicesDAL>();
            services.AddDbContext<WBSContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
