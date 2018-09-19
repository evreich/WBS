using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WBS.DAL;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers.Classes;
using WBS.DAL.Layers;
using WBS.DAL.Authorization;
using WBS.DAL.Authorization.Models;
using System.Linq;
using WBS.DAL.Exceptions;

namespace WBS.API.Extensions
{
    static class DALExtension
    {
        public static void AddWBSDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            // levels
            var idalType = typeof(IDAL<>);
            var ipermissionType = typeof(IPermissions<>);
            var icacheType = typeof(ICRUDCache<>);

            services.AddTransient(typeof(IPermissions<>), typeof(Permissions<>));
            services.AddTransient(typeof(ICRUDCache<>), typeof(CrudCache<>));
            services.AddTransient(typeof(IDAL<>), typeof(BaseDAL<>));

            // dependences levels
            services.AddTransient<GetCRUD>(serviceProvider => (clientType, type) => {

                if (clientType == ipermissionType)
                    return serviceProvider.GetService(icacheType.MakeGenericType(type));

                if(clientType == icacheType)
                    return serviceProvider.GetService(idalType.MakeGenericType(type));

                if (clientType == typeof(ProfilesDAL))
                {
                    if (type == typeof(User))
                        return serviceProvider.GetService(icacheType.MakeGenericType(type));
                    else
                        return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                }
                if (clientType == typeof(RolesDAL))
                    return serviceProvider.GetService(icacheType.MakeGenericType(type));
                if (clientType == typeof(AttachmentDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(BudgetPlanDAL))
                {
                    if (type == typeof(Event) || type == typeof(Status))
                        return serviceProvider.GetService(icacheType.MakeGenericType(type));
                    else
                        return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                }
                if (clientType == typeof(CategoriesOfEquipmentDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(CategoryGroupsDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(DAIRequestDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(EventsDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(FormatDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(BudgetLineDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(RequestLineDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(ProviderDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(RationaleForInvestmentsDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(ResultCentresDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(SiteDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(TechnicalServiceDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                if (clientType == typeof(TypesOfInvestmentDAL))
                    return serviceProvider.GetService(ipermissionType.MakeGenericType(type));
                throw new DependencyNotFoundException($"Не найдена зависимость при запрашивании типом {clientType.Name} типа {type.Name}");
            });
            services.AddTransient(typeof(ICRUD<>), typeof(Permissions<>));

            // includes extentions
            services.AddTransient(typeof(IExtensionDALIQueryable<>), typeof(ExtensionDALIQueryable<>));
            services.AddTransient<IExtensionDALIQueryable<User>, ExtensionDALIQueryableProfile>();
            services.AddTransient<IExtensionDALIQueryable<BudgetPlan>, ExtensionDALIQueryableBudgetPlan>();
            services.AddTransient<IExtensionDALIQueryable<Attachment>, ExtensionDALIQueryableAttachment>();
            services.AddTransient<IExtensionDALIQueryable<CategoryOfEquipment>, ExtensionDALIQueryableCategoryOfEquipment>();
            services.AddTransient<IExtensionDALIQueryable<DAIRequest>, ExtensionDALIQueryableDAIRequest>();
            services.AddTransient<IExtensionDALIQueryable<Event>, ExtensionDALIQueryableEvent>();
            services.AddTransient<IExtensionDALIQueryable<Format>, ExtensionDALIQueryableFormat>();
            services.AddTransient<IExtensionDALIQueryable<BudgetLine>, ExtensionDALIQueryableBudgetLine>();
            services.AddTransient<IExtensionDALIQueryable<RequestLine>, ExtensionDALIQueryableRequestLine>();
            services.AddTransient<IExtensionDALIQueryable<Provider>, ExtensionDALIQueryableProvider>();
            services.AddTransient<IExtensionDALIQueryable<Site>, ExtensionDALIQueryableSite>();

            // levels extentions
            services.AddTransient<ICRUD<User>, ProfilesDAL>();
            services.AddTransient<ICRUD<Role>, RolesDAL>();
            services.AddTransient<ICRUD<BudgetPlan>, BudgetPlanDAL>();
            services.AddTransient<ICRUD<Attachment>, AttachmentDAL>();
            services.AddTransient<ICRUD<CategoryOfEquipment>, CategoriesOfEquipmentDAL>();
            services.AddTransient<ICRUD<CategoryGroup>, CategoryGroupsDAL>();
            services.AddTransient<ICRUD<DAIRequest>, DAIRequestDAL>();
            services.AddTransient<ICRUD<Event>, EventsDAL>();
            services.AddTransient<ICRUD<Format>, FormatDAL>();
            services.AddTransient<ICRUD<BudgetLine>, BudgetLineDAL>();
            services.AddTransient<ICRUD<RequestLine>, RequestLineDAL>();
            services.AddTransient<ICRUD<Provider>, ProviderDAL>();
            services.AddTransient<ICRUD<RationaleForInvestment>, RationaleForInvestmentsDAL>();
            services.AddTransient<ICRUD<ResultCenter>, ResultCentresDAL>();
            services.AddTransient<ICRUD<Site>, SiteDAL>();
            services.AddTransient<ICRUD<TechnicalService>, TechnicalServiceDAL>();
            services.AddTransient<ICRUD<TypeOfInvestment>, TypesOfInvestmentDAL>();

            services.AddTransient<ICRUD<UserRoles>, BaseDAL<UserRoles>>();
            services.AddTransient<ICRUD<ProvidersTechnicalService>, BaseDAL<ProvidersTechnicalService>>();

            services.AddTransient<IPermissionsDAL, PermissionsDAL>();

            services.AddDbContext<WBSContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
