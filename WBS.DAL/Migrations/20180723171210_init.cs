using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WBS.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    fio = table.Column<string>(nullable: true),
                    jobPosition = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true),
                    deletionMark = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "QuarterOfYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterOfYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RationaleForInvestments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RationaleForInvestments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    token = table.Column<string>(nullable: false),
                    expire = table.Column<DateTime>(nullable: false),
                    audience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.token);
                });

            migrationBuilder.CreateTable(
                name: "ResultCentres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultCentres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: true),
                    routes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfInvestment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ExternalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfInvestment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesOfEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    DepreciationPeriod = table.Column<double>(nullable: false),
                    CategoryGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesOfEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesOfEquipment_CategoryGroups_CategoryGroupId",
                        column: x => x.CategoryGroupId,
                        principalTable: "CategoryGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    TypeOfFormat = table.Column<string>(nullable: true),
                    E1Limit = table.Column<int>(nullable: false),
                    E2Limit = table.Column<int>(nullable: false),
                    E3Limit = table.Column<int>(nullable: false),
                    DirectorOfFormatId = table.Column<int>(nullable: true),
                    DirectorOfKYFormatId = table.Column<int>(nullable: true),
                    KYFormatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.id);
                    table.ForeignKey(
                        name: "FK_Formats_Profiles_DirectorOfFormatId",
                        column: x => x.DirectorOfFormatId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Formats_Profiles_DirectorOfKYFormatId",
                        column: x => x.DirectorOfKYFormatId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Formats_Profiles_KYFormatId",
                        column: x => x.KYFormatId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserRoles_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(maxLength: 100, nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    BudgetPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_BudgetPlans_BudgetPlanId",
                        column: x => x.BudgetPlanId,
                        principalTable: "BudgetPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Events_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProvidersTechnicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProviderId = table.Column<int>(nullable: false),
                    TechnicalServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersTechnicalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidersTechnicalServices_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProvidersTechnicalServices_TechnicalServices_TechnicalServi~",
                        column: x => x.TechnicalServiceId,
                        principalTable: "TechnicalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    FormatId = table.Column<int>(nullable: true),
                    KySitId = table.Column<int>(nullable: true),
                    TechnicalExpertId = table.Column<int>(nullable: true),
                    DirectorOfSitId = table.Column<int>(nullable: true),
                    CreaterOfBudgetId = table.Column<int>(nullable: true),
                    KyRegionId = table.Column<int>(nullable: true),
                    OperationDirectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Profiles_CreaterOfBudgetId",
                        column: x => x.CreaterOfBudgetId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sites_Profiles_DirectorOfSitId",
                        column: x => x.DirectorOfSitId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sites_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sites_Profiles_KyRegionId",
                        column: x => x.KyRegionId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sites_Profiles_KySitId",
                        column: x => x.KySitId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sites_Profiles_OperationDirectorId",
                        column: x => x.OperationDirectorId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sites_Profiles_TechnicalExpertId",
                        column: x => x.TechnicalExpertId,
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EventQuarters",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    QuarterOfYearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventQuarters", x => new { x.EventId, x.QuarterOfYearId });
                    table.ForeignKey(
                        name: "FK_EventQuarters_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EventQuarters_QuarterOfYears_QuarterOfYearId",
                        column: x => x.QuarterOfYearId,
                        principalTable: "QuarterOfYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DaiRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<string>(nullable: true),
                    CreationData = table.Column<DateTime>(nullable: true),
                    LastModifiedData = table.Column<DateTime>(nullable: true),
                    ReceiptTaskData = table.Column<DateTime>(nullable: true),
                    DirectorApprovalDate = table.Column<DateTime>(nullable: true),
                    DeliveryTime = table.Column<DateTime>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    ApprovalOfTechExpertIsRequired = table.Column<bool>(nullable: false),
                    RationaleForInvestmentId = table.Column<int>(nullable: true),
                    SitId = table.Column<int>(nullable: true),
                    CommentForDirectorGeneral = table.Column<string>(nullable: true),
                    ResultCentreId = table.Column<int>(nullable: true),
                    TotalInvestment = table.Column<double>(nullable: false),
                    EstimatedOperationPeriod = table.Column<double>(nullable: false),
                    AdditionalSalesPerYear = table.Column<double>(nullable: false),
                    MarginOnAddedValue = table.Column<double>(nullable: false),
                    PeriodOfPayback = table.Column<double>(nullable: false),
                    ExtraAnnualCost = table.Column<double>(nullable: false),
                    NetMargin = table.Column<double>(nullable: false),
                    InternalRateOfReturn = table.Column<double>(nullable: false),
                    NetPresentValue = table.Column<double>(nullable: false),
                    SavingsPerYear = table.Column<double>(nullable: false),
                    ReasonForDAI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaiRequests_RationaleForInvestments_RationaleForInvestmentId",
                        column: x => x.RationaleForInvestmentId,
                        principalTable: "RationaleForInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DaiRequests_ResultCentres_ResultCentreId",
                        column: x => x.ResultCentreId,
                        principalTable: "ResultCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DaiRequests_Sites_SitId",
                        column: x => x.SitId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ItemOfBudgetPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ItemOfInvestment = table.Column<string>(maxLength: 200, nullable: true),
                    InvestmentDate = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CostItem = table.Column<double>(nullable: false),
                    AmountAllItems = table.Column<double>(nullable: false),
                    BudgetPlanId = table.Column<int>(nullable: false),
                    CategoryOfEquipmentId = table.Column<int>(nullable: false),
                    ResultCenterId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: false),
                    TypeOfInvestmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfBudgetPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOfBudgetPlans_BudgetPlans_BudgetPlanId",
                        column: x => x.BudgetPlanId,
                        principalTable: "BudgetPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemOfBudgetPlans_CategoriesOfEquipment_CategoryOfEquipment~",
                        column: x => x.CategoryOfEquipmentId,
                        principalTable: "CategoriesOfEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemOfBudgetPlans_ResultCentres_ResultCenterId",
                        column: x => x.ResultCenterId,
                        principalTable: "ResultCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemOfBudgetPlans_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemOfBudgetPlans_TypesOfInvestment_TypeOfInvestmentId",
                        column: x => x.TypeOfInvestmentId,
                        principalTable: "TypesOfInvestment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DaiRequestProvider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DaiId = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiRequestProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaiRequestProvider_DaiRequests_DaiId",
                        column: x => x.DaiId,
                        principalTable: "DaiRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DaiRequestProvider_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DaiRequestTechnicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DaiId = table.Column<int>(nullable: false),
                    TechnicalServId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiRequestTechnicalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaiRequestTechnicalServices_DaiRequests_DaiId",
                        column: x => x.DaiId,
                        principalTable: "DaiRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DaiRequestTechnicalServices_TechnicalServices_TechnicalServ~",
                        column: x => x.TechnicalServId,
                        principalTable: "TechnicalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "QuarterOfYears",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Первый" },
                    { 2, "Второй" },
                    { 3, "Третий" },
                    { 4, "Четвертый" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Проект" },
                    { 2, "Редактирование" },
                    { 3, "Действующий" },
                    { 4, "Архив" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesOfEquipment_CategoryGroupId",
                table: "CategoriesOfEquipment",
                column: "CategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiRequestProvider_DaiId",
                table: "DaiRequestProvider",
                column: "DaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiRequestProvider_ProviderId",
                table: "DaiRequestProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiRequests_RationaleForInvestmentId",
                table: "DaiRequests",
                column: "RationaleForInvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiRequests_ResultCentreId",
                table: "DaiRequests",
                column: "ResultCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiRequests_SitId",
                table: "DaiRequests",
                column: "SitId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiRequestTechnicalServices_DaiId",
                table: "DaiRequestTechnicalServices",
                column: "DaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiRequestTechnicalServices_TechnicalServId",
                table: "DaiRequestTechnicalServices",
                column: "TechnicalServId");

            migrationBuilder.CreateIndex(
                name: "IX_EventQuarters_QuarterOfYearId",
                table: "EventQuarters",
                column: "QuarterOfYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_BudgetPlanId",
                table: "Events",
                column: "BudgetPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_StatusId",
                table: "Events",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Formats_DirectorOfFormatId",
                table: "Formats",
                column: "DirectorOfFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Formats_DirectorOfKYFormatId",
                table: "Formats",
                column: "DirectorOfKYFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Formats_KYFormatId",
                table: "Formats",
                column: "KYFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfBudgetPlans_BudgetPlanId",
                table: "ItemOfBudgetPlans",
                column: "BudgetPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfBudgetPlans_CategoryOfEquipmentId",
                table: "ItemOfBudgetPlans",
                column: "CategoryOfEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfBudgetPlans_ResultCenterId",
                table: "ItemOfBudgetPlans",
                column: "ResultCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfBudgetPlans_SiteId",
                table: "ItemOfBudgetPlans",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfBudgetPlans_TypeOfInvestmentId",
                table: "ItemOfBudgetPlans",
                column: "TypeOfInvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersTechnicalServices_ProviderId",
                table: "ProvidersTechnicalServices",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersTechnicalServices_TechnicalServiceId",
                table: "ProvidersTechnicalServices",
                column: "TechnicalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_CreaterOfBudgetId",
                table: "Sites",
                column: "CreaterOfBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DirectorOfSitId",
                table: "Sites",
                column: "DirectorOfSitId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_FormatId",
                table: "Sites",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_KyRegionId",
                table: "Sites",
                column: "KyRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_KySitId",
                table: "Sites",
                column: "KySitId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_OperationDirectorId",
                table: "Sites",
                column: "OperationDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_TechnicalExpertId",
                table: "Sites",
                column: "TechnicalExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaiRequestProvider");

            migrationBuilder.DropTable(
                name: "DaiRequestTechnicalServices");

            migrationBuilder.DropTable(
                name: "EventQuarters");

            migrationBuilder.DropTable(
                name: "ItemOfBudgetPlans");

            migrationBuilder.DropTable(
                name: "ProvidersTechnicalServices");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "DaiRequests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "QuarterOfYears");

            migrationBuilder.DropTable(
                name: "CategoriesOfEquipment");

            migrationBuilder.DropTable(
                name: "TypesOfInvestment");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "TechnicalServices");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "RationaleForInvestments");

            migrationBuilder.DropTable(
                name: "ResultCentres");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "BudgetPlans");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
