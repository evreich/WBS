﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WBS.DAL;

namespace WBS.DAL.Migrations
{
    [DbContext(typeof(WBSContext))]
    [Migration("20180802104821_ChangeProviderTechServsTableKeys")]
    partial class ChangeProviderTechServsTableKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WBS.DAL.Authorization.Models.RefreshToken", b =>
                {
                    b.Property<string>("Token")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("token");

                    b.Property<string>("Audience")
                        .HasColumnName("audience");

                    b.Property<DateTime>("Expire")
                        .HasColumnName("expire");

                    b.HasKey("Token");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("WBS.DAL.Authorization.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Routes")
                        .HasColumnName("routes");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WBS.DAL.Authorization.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("DeletionMark")
                        .HasColumnName("deletionMark");

                    b.Property<string>("Department")
                        .HasColumnName("department");

                    b.Property<string>("Fio")
                        .HasColumnName("fio");

                    b.Property<string>("JobPosition")
                        .HasColumnName("jobPosition");

                    b.Property<string>("Login")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("WBS.DAL.Authorization.Models.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.BudgetPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("BudgetPlans");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.CategoryGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("CategoryGroups");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.CategoryOfEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryGroupId");

                    b.Property<string>("Code");

                    b.Property<double>("DepreciationPeriod");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryGroupId");

                    b.ToTable("CategoriesOfEquipment");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.DAIRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AdditionalSalesPerYear");

                    b.Property<bool>("ApprovalOfTechExpertIsRequired");

                    b.Property<string>("CommentForDirectorGeneral");

                    b.Property<DateTime?>("CreationData");

                    b.Property<DateTime?>("DeliveryTime");

                    b.Property<DateTime?>("DirectorApprovalDate");

                    b.Property<double>("EstimatedOperationPeriod");

                    b.Property<double>("ExtraAnnualCost");

                    b.Property<double>("InternalRateOfReturn");

                    b.Property<DateTime?>("LastModifiedData");

                    b.Property<double>("MarginOnAddedValue");

                    b.Property<double>("NetMargin");

                    b.Property<double>("NetPresentValue");

                    b.Property<string>("Number");

                    b.Property<double>("PeriodOfPayback");

                    b.Property<int?>("RationaleForInvestmentId");

                    b.Property<string>("ReasonForDAI");

                    b.Property<DateTime?>("ReceiptTaskData");

                    b.Property<int?>("ResultCentreId");

                    b.Property<double>("SavingsPerYear");

                    b.Property<int?>("SitId");

                    b.Property<string>("Subject");

                    b.Property<double>("TotalInvestment");

                    b.HasKey("Id");

                    b.HasIndex("RationaleForInvestmentId");

                    b.HasIndex("ResultCentreId");

                    b.HasIndex("SitId");

                    b.ToTable("DaiRequests");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.DAIRequestsProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DaiId");

                    b.Property<int>("ProviderId");

                    b.HasKey("Id");

                    b.HasIndex("DaiId");

                    b.HasIndex("ProviderId");

                    b.ToTable("DaiRequestProvider");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.DAIRequestsTechnicalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DaiId");

                    b.Property<int>("TechnicalServId");

                    b.HasKey("Id");

                    b.HasIndex("DaiId");

                    b.HasIndex("TechnicalServId");

                    b.ToTable("DaiRequestTechnicalServices");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BudgetPlanId");

                    b.Property<string>("Comment")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Date");

                    b.Property<int>("StatusId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("BudgetPlanId");

                    b.HasIndex("StatusId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.EventQuarter", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<int>("QuarterOfYearId");

                    b.HasKey("EventId", "QuarterOfYearId");

                    b.HasIndex("QuarterOfYearId");

                    b.ToTable("EventQuarters");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.ItemOfBudgetPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("BudgetPlanId");

                    b.Property<int>("CategoryOfEquipmentId");

                    b.Property<int>("Count");

                    b.Property<DateTime>("DateOfDelivery");

                    b.Property<double>("Price");

                    b.Property<int?>("ResultCenterId");

                    b.Property<int>("SiteId");

                    b.Property<string>("SubjectOfInvestment")
                        .HasMaxLength(200);

                    b.Property<int>("TypeOfInvestmentId");

                    b.HasKey("Id");

                    b.HasIndex("BudgetPlanId");

                    b.HasIndex("CategoryOfEquipmentId");

                    b.HasIndex("ResultCenterId");

                    b.HasIndex("SiteId");

                    b.HasIndex("TypeOfInvestmentId");

                    b.ToTable("ItemOfBudgetPlans");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.ProvidersTechnicalService", b =>
                {
                    b.Property<int>("ProviderId");

                    b.Property<int>("TechnicalServiceId");

                    b.HasKey("ProviderId", "TechnicalServiceId");

                    b.HasIndex("TechnicalServiceId");

                    b.ToTable("ProvidersTechnicalServices");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.QuarterOfYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("QuarterOfYears");

                    b.HasData(
                        new { Id = 1, Title = "Первый" },
                        new { Id = 2, Title = "Второй" },
                        new { Id = 3, Title = "Третий" },
                        new { Id = 4, Title = "Четвертый" }
                    );
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.RationaleForInvestment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("RationaleForInvestments");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.ResultCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ResultCentres");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreaterOfBudgetId");

                    b.Property<int?>("DirectorOfSitId");

                    b.Property<int?>("FormatId");

                    b.Property<int?>("KyRegionId");

                    b.Property<int?>("KySitId");

                    b.Property<int?>("OperationDirectorId");

                    b.Property<int?>("TechnicalExpertId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreaterOfBudgetId");

                    b.HasIndex("DirectorOfSitId");

                    b.HasIndex("FormatId");

                    b.HasIndex("KyRegionId");

                    b.HasIndex("KySitId");

                    b.HasIndex("OperationDirectorId");

                    b.HasIndex("TechnicalExpertId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new { Id = 1, Title = "Проект" },
                        new { Id = 2, Title = "Редактирование" },
                        new { Id = 3, Title = "Действующий" },
                        new { Id = 4, Title = "Архив" }
                    );
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.TechnicalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TechnicalServices");
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.TypeOfInvestment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("ExternalCode");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TypesOfInvestment");
                });

            modelBuilder.Entity("WBS.DAL.Models.Format", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("DirectorOfFormatId");

                    b.Property<int?>("DirectorOfKYFormatId");

                    b.Property<int>("E1Limit");

                    b.Property<int>("E2Limit");

                    b.Property<int>("E3Limit");

                    b.Property<int?>("KYFormatId");

                    b.Property<string>("Profile");

                    b.Property<string>("Title");

                    b.Property<string>("TypeOfFormat");

                    b.HasKey("Id");

                    b.HasIndex("DirectorOfFormatId");

                    b.HasIndex("DirectorOfKYFormatId");

                    b.HasIndex("KYFormatId");

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("WBS.DAL.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("WBS.DAL.Authorization.Models.UserRoles", b =>
                {
                    b.HasOne("WBS.DAL.Authorization.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.CategoryOfEquipment", b =>
                {
                    b.HasOne("WBS.DAL.Data.Models.CategoryGroup", "CategoryGroup")
                        .WithMany("CategoriesOfEquipment")
                        .HasForeignKey("CategoryGroupId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.DAIRequest", b =>
                {
                    b.HasOne("WBS.DAL.Data.Models.RationaleForInvestment", "RationaleForInvestment")
                        .WithMany()
                        .HasForeignKey("RationaleForInvestmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.ResultCenter", "ResultCentre")
                        .WithMany()
                        .HasForeignKey("ResultCentreId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.Site", "Sit")
                        .WithMany()
                        .HasForeignKey("SitId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.DAIRequestsProvider", b =>
                {
                    b.HasOne("WBS.DAL.Data.Models.DAIRequest", "DAI")
                        .WithMany("DAIRequestsProviders")
                        .HasForeignKey("DaiId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.DAIRequestsTechnicalService", b =>
                {
                    b.HasOne("WBS.DAL.Data.Models.DAIRequest", "DAI")
                        .WithMany("DAIRequestsTechnicalService")
                        .HasForeignKey("DaiId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.TechnicalService", "TechnicalServ")
                        .WithMany()
                        .HasForeignKey("TechnicalServId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.Event", b =>
                {
                    b.HasOne("WBS.DAL.Data.Models.BudgetPlan", "BudgetPlan")
                        .WithMany("Events")
                        .HasForeignKey("BudgetPlanId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.EventQuarter", b =>
                {
                    b.HasOne("WBS.DAL.Data.Models.Event", "Event")
                        .WithMany("EventQuarters")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.QuarterOfYear", "QuarterOfYear")
                        .WithMany("EventQuarters")
                        .HasForeignKey("QuarterOfYearId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.ItemOfBudgetPlan", b =>
                {
                    b.HasOne("WBS.DAL.Data.Models.BudgetPlan", "BudgetPlan")
                        .WithMany("Items")
                        .HasForeignKey("BudgetPlanId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.CategoryOfEquipment", "CategoryOfEquipment")
                        .WithMany("ItemsOfBudgetPlan")
                        .HasForeignKey("CategoryOfEquipmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.ResultCenter", "ResultCenter")
                        .WithMany("ItemsOfBudgetplan")
                        .HasForeignKey("ResultCenterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.Site", "Site")
                        .WithMany("ItemsOfBudgetPlan")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Data.Models.TypeOfInvestment", "TypeOfInvestment")
                        .WithMany("ItemsOfBudgetPlan")
                        .HasForeignKey("TypeOfInvestmentId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.ProvidersTechnicalService", b =>
                {
                    b.HasOne("WBS.DAL.Provider", "Provider")
                        .WithMany("ProvidersTechnicalServices")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WBS.DAL.Data.Models.TechnicalService", "TechnicalService")
                        .WithMany()
                        .HasForeignKey("TechnicalServiceId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Data.Models.Site", b =>
                {
                    b.HasOne("WBS.DAL.Authorization.Models.User", "CreaterOfBudget")
                        .WithMany()
                        .HasForeignKey("CreaterOfBudgetId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "DirectorOfSit")
                        .WithMany()
                        .HasForeignKey("DirectorOfSitId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Models.Format", "Format")
                        .WithMany("Sites")
                        .HasForeignKey("FormatId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "KyRegion")
                        .WithMany()
                        .HasForeignKey("KyRegionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "KySit")
                        .WithMany()
                        .HasForeignKey("KySitId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "OperationDirector")
                        .WithMany()
                        .HasForeignKey("OperationDirectorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "TechnicalExpert")
                        .WithMany()
                        .HasForeignKey("TechnicalExpertId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WBS.DAL.Models.Format", b =>
                {
                    b.HasOne("WBS.DAL.Authorization.Models.User", "DirectorOfFormat")
                        .WithMany()
                        .HasForeignKey("DirectorOfFormatId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "DirectorOfKYFormat")
                        .WithMany()
                        .HasForeignKey("DirectorOfKYFormatId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WBS.DAL.Authorization.Models.User", "KYFormat")
                        .WithMany()
                        .HasForeignKey("KYFormatId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
