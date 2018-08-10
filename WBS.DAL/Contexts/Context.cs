using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
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

            //мультиключи для промежуточной таблицы EventQuarters
            modelBuilder.Entity<EventQuarter>().HasKey(c => new { c.EventId, c.QuarterOfYearId });

            modelBuilder.Entity<ProvidersTechnicalService>().HasKey(c => new { c.ProviderId, c.TechnicalServiceId });

            modelBuilder.Entity<ProvidersTechnicalService>()
                .HasOne(p_ts => p_ts.Provider)
                .WithMany(provider => provider.ProvidersTechnicalServices)
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
    }
}
