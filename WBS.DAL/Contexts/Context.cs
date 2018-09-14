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

            modelBuilder.Entity<FieldComponent>().HasData(
                    new FieldComponent { Id = 1, Name = "TextFieldPlaceholder" },
                    new FieldComponent { Id = 2, Name = "CategoryGroupSelect" },
                    new FieldComponent { Id = 3, Name = "CategoryOfEquipmentSelect" },
                    new FieldComponent { Id = 4, Name = "FormatSelect" },
                    new FieldComponent { Id = 5, Name = "ResultCenterSelect" },
                    new FieldComponent { Id = 6, Name = "SiteSelect" },
                    new FieldComponent { Id = 7, Name = "TypeOfInvestmentSelect" },
                    new FieldComponent { Id = 8, Name = "TechnicalServMultiSelect" },
                    new FieldComponent { Id = 9, Name = "UserAutosuggestField" },
                    new FieldComponent { Id = 10, Name = "TextFieldMultiline" }
                );

            //инициализация таблицы типов
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && (t.Namespace == "WBS.DAL.Data.Models" || t.Namespace == "WBS.DAL.Authorization.Models"))
                .Select((t, index) => new ObjectType() { AssemblyName = t.Assembly.GetName().Name, TypeName = t.FullName, Id = index+1 })
                .ToArray();
            modelBuilder.Entity<ObjectType>().HasData(types);
             
            //инициализация пунктов меню
            var menuItems = new MenuItem[] {new MenuItem { Id = 1, Text = "Документы", IconName = "FolderIcon" },
                new MenuItem { Id = 2, Text = "Таблица разработки", IconName = "InsertDriveFileIcon", ParentId = 1, To = "/table" },
                new MenuItem { Id = 3, Text = "Макет", IconName = "InsertDriveFileIcon", ParentId = 1, To = "/DateRangePicker" },
                new MenuItem { Id = 4, Text = "Заявки на инвестиции", IconName = "InsertDriveFileIcon", ParentId = 1, To = "/DAIRequests" },
                new MenuItem { Id = 5, Text = "Бюджетные планы", IconName = "DescriptionIcon", ParentId = 1, To = "/BudgetPlans" },
                new MenuItem { Id = 6, Text = "Статистика", IconName = "TrendingUpIcon", ParentId = 1, To = "/Statistics" },
                new MenuItem { Id = 7, Text = "Все обработанные мной заявки", IconName = "RestorePageIcon", ParentId = 1, To = "/DAIProcessedRequests" },
                new MenuItem { Id = 8, Text = "Инструкции", IconName = "InfoOutlineIcon", ParentId = 1, To = "/DocLib" },
                new MenuItem { Id = 9, Text = "Администрирование", IconName = "AccountBoxIcon" },
                new MenuItem { Id = 10, Text = "Добавить пользователя", IconName = "ChromeReaderMode", ParentId = 9, To = "/signup" },
                new MenuItem { Id = 11, Text = "Журнал изменений", IconName = "ChromeReaderMode", ParentId = 9, To = "/EventsHistory" },
                new MenuItem { Id = 12, Text = "Проверка мониторинга системы", IconName = "AssessmentIcon", ParentId = 9, To = "/CheckDAIMonitoringSystem" },
                new MenuItem { Id = 13, Text = "Справочники", IconName = "LibraryBooksIcon" },
                new MenuItem { Id = 14, Text = "Ситы", IconName = "HomeIcon", ParentId = 13, To = "/Sits" },
                new MenuItem { Id = 15, Text = "Пользователи", IconName = "AccountCircleIcon", ParentId = 13, To = "/Profiles" },
                new MenuItem { Id = 16, Text = "Поставщики", IconName = "SupervisorAccountIcon", ParentId = 13, To = "/Providers" },
                new MenuItem { Id = 17, Text = "Формат ситов", IconName = "DescriptionIcon", ParentId = 13, To = "/Formats" },
                new MenuItem { Id = 18, Text = "Типы инвестиций", IconName = "TrendingUpIcon", ParentId = 13, To = "/TypeOfInvestments" },
                new MenuItem { Id = 19, Text = "Центры результатов", IconName = "InsertDriveFileIcon", ParentId = 13, To = "/ResultCentres" },
                new MenuItem { Id = 20, Text = "Группы категорий", IconName = "InsertDriveFileIcon", ParentId = 13, To = "/CategoryGroups" },
                new MenuItem { Id = 21, Text = "Категории оборудования", IconName = "InsertDriveFileIcon", ParentId = 13, To = "/CategoriesOfEquipment" }
            };
            modelBuilder.Entity<MenuItem>().HasData(menuItems);


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

            modelBuilder.Entity<RequestLine>()
                .HasIndex(l => l.RequestId);

            modelBuilder.Entity<RequestLine>()
                .HasOne(rl => rl.ParentRequestLine)
                .WithMany(rl => rl.RequestSubLines)
                .HasForeignKey(rl => rl.ParentRequestLineId);

            modelBuilder.Entity<RequestLine>()
                .HasOne(rl => rl.ByWhoRequestLine)
                .WithMany(rl => rl.OnAccountOfRequestLines)
                .HasForeignKey(rl => rl.ByWhoRequestLineId);

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
        public DbSet<BudgetLine> BudgetLines { get; set; }
        public DbSet<RequestLine> RequestLines { get; set; }
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
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemRoles> MenuItemRoles { get; set; }
        public DbSet<ObjectField> ObjectFields { get; set; }
        public DbSet<RolesObjectFields> RolesObjectFields { get; set; }
    }
}
