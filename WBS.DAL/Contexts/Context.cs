using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data;
using WBS.DAL.Data.Models;
using WBS.DAL.Models;

namespace WBS.DAL
{
    public class WBSContext : DbContext
    {
        public WBSContext(DbContextOptions<WBSContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.SetNull;
            }

            //инициализация таблицы годовых кварталов
            modelBuilder.Entity<QuarterOfYear>().HasData(
                        new QuarterOfYear { Id = 1, Title = Constants.QUARTER_FIRST },
                        new QuarterOfYear { Id = 2, Title = Constants.QUARTER_SECOND },
                        new QuarterOfYear { Id = 3, Title = Constants.QUARTER_THIRD },
                        new QuarterOfYear { Id = 4, Title = Constants.QUARTER_FOURTH }
                    );

            //инициализация таблицы статусов бюджетного плана
            modelBuilder.Entity<Status>().HasData(
                        new Status { Id = 1, Title = Constants.STATUS_BP_PROJECT },
                        new Status { Id = 2, Title = Constants.STATUS_BP_EDIT },
                        new Status { Id = 3, Title = Constants.STATUS_BP_CURRENT },
                        new Status { Id = 4, Title = Constants.STATUS_BP_ARCHIVE }
                    );

            //инициализация таблицы типов
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && (t.Namespace == "WBS.DAL.Data.Models" || t.Namespace == "WBS.DAL.Authorization.Models"))
                .Select((t, index) => new ObjectType() { AssemblyName = t.Assembly.GetName().Name, TypeName = t.FullName, Id = index+1 })
                .ToArray();
            modelBuilder.Entity<ObjectType>().HasData(types);

            //инициализация таблицы полей типов
            List<ObjectField> typeFields = new List<ObjectField>();
            int counter = 1;

            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && (t.Namespace == "WBS.DAL.Data.Models" || t.Namespace == "WBS.DAL.Authorization.Models")).ToList()
                .ForEach(x => x.GetProperties().ToList()
                               .ForEach(f => typeFields.Add(new ObjectField()
                               {
                                   Id = counter++,
                                   FieldName = f.Name,                                
                                   ObjectTypeId = types.First(to => to.TypeName.Equals(x.FullName)).Id
                               })));
            modelBuilder.Entity<ObjectField>().HasData(typeFields.ToArray());

            //мультиключи для промежуточной таблицы EventQuarters
            modelBuilder.Entity<EventQuarter>().HasKey(c => new { c.EventId, c.QuarterOfYearId });

            modelBuilder.Entity<ProvidersTechnicalService>().HasKey(c => new { c.ProviderId, c.TechnicalServiceId });

            modelBuilder.Entity<ProvidersTechnicalService>()
                .HasOne(p_ts => p_ts.Provider)
                .WithMany(provider => provider.ProvidersTechnicalServices)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DAIRequestsProvider>()
                .HasOne(dai_prov => dai_prov.DAI)
                .WithMany(provider => provider.DAIRequestsProviders)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DAIRequestsTechnicalService>()
                .HasOne(dai_prov => dai_prov.DAI)
                .WithMany(provider => provider.DAIRequestsTechnicalService)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<User> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<CategoryOfEquipment> CategoriesOfEquipment { get; set; }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<TypeOfInvestment> TypesOfInvestment { get; set; }
        public DbSet<ResultCenter> ResultCentres { get; set; }
        public DbSet<BudgetPlan> BudgetPlans { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventQuarter> EventQuarters { get; set; }
        public DbSet<QuarterOfYear> QuarterOfYears { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ItemOfBudgetPlan> ItemOfBudgetPlans { get; set; }
        public DbSet<DAIRequest> DaiRequests { get; set; }
        public DbSet<TechnicalService> TechnicalServices { get; set; }
        public DbSet<DAIRequestsTechnicalService> DaiRequestTechnicalServices { get; set; }
        public DbSet<DAIRequestsProvider> DaiRequestProvider { get; set; }
        public DbSet<ProvidersTechnicalService> ProvidersTechnicalServices { get; set; }
        public DbSet<RationaleForInvestment> RationaleForInvestments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }
        public DbSet<FieldComponent> FieldComponents { get; set; }
        public DbSet<RolesObjectTypes> RolesObjectTypes { get; set; }
        public DbSet<ObjectField> ObjectFields { get; set; }
        public DbSet<RolesObjectFields> RolesObjectFields { get; set; }
    }
}
