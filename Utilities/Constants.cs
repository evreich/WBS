using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSeed
{
    public class Constants
    {
        public const string connectionString = "Host=localhost;Port=5432;Database=WBSDB;Username=postgres;Password=BGTnhyMJU100";

        //Запрос на заполнение таблицы Поставщики
        public const string InsertProviders = "INSERT INTO public.\"Providers\"(title) VALUES (@Title)";

        //Заполнение Пользователей
        public const string InsertProfiles = "INSERT INTO public.\"Profiles\"(\"login\", \"password\", \"fio\", \"jobPosition\" , department, \"deletionMark\")" +
            " VALUES (@Login,@Password, @FIO, @jobPosition,@Department, @DeletionMark)";

        //заполнение ролей
        public const string InsertRole = "INSERT INTO public.\"Roles\" (id, title)" +
            @"VALUES(1, 'Инициатор'),
                    (2, 'Доступ на чтение DAI'),
                    (3, 'Генеральный директор'),
                    (4, 'Директор по КУ'),
                    (5, 'Техническая служба/руководитель'),
                    (6, 'Бухгалтерия'),
                    (7, 'Администратор бюджета'),
                    (8, 'КУ технической дирекции'),
                    (9, 'Администратор'),
                    (10, 'Техническая служба (Construction)'),
                    (11, 'Техническая служба (Equipment)'),
                    (12, 'Техническая служба (IT)'),
                    (13, 'Руководитель технической службы (Construction)'),
                    (14, 'Руководитель технической службы (IT)'),
                    (15, 'Служба ИТ поддержки'),
                    (16, 'Руководитель технической службы (Equipment)'),
                    (17, 'Cлужба поддержки'),
                    (18, 'Ответственные за ситы'),
                    (19, 'Контролер бюджета')";

        //Связывание ролей и пользователей
        public const string InsertUserRoles = "INSERT INTO public.\"UserRoles\"(\"UserId\", \"RoleId\") VALUES ((SELECT \"id\" FROM public.\"Profiles\" WHERE \"login\" = @Login), (SELECT \"id\" FROM public.\"Roles\" WHERE \"title\" = @RoleName))";

        //Запрос на заполнение таблицы Типы инвестиций
        public const string InsertTypesOfInvestment = "INSERT INTO public.\"TypesOfInvestment\" (\"Title\", \"Code\", \"ExternalCode\")" +
            "VALUES (@Title, @Code , @ExternalCode)";

        //Запрос на заполнение таблицы Категории групп
        public const string InsertGroupsOfCategories = "INSERT INTO public.\"CategoryGroups\" (\"Title\", \"Code\") VALUES (@Title, @Code)";

        //Запрос на заполнение таблицы Категории оборудования
        public const string InsertCategoriesOfEquipment = "INSERT INTO public.\"CategoriesOfEquipment\" (\"Title\", \"Code\", \"DepreciationPeriod\", \"CategoryGroupId\")" +
            "VALUES (@Title, @Code, @DepreciationPeriod, (Select \"Id\" FROM public.\"CategoryGroups\" WHERE \"Title\" = @NameCategory))";
        
        public const string InsertProvidersTechnicalServices = "INSERT INTO public.\"ProvidersTechnicalServices\" (ProviderId, TechnicalServiceId)" +
            "VALUES (@ProviderId, (SELECT \"Id\" FROM public.\"TechnicalServices\" WHERE \"Title\" = @NameService)";

        //Запрос на заполнение таблицы Центры результатов
        public const string InsertResultCentres = "INSERT INTO public.\"ResultCentres\"(\"Title\", \"Code\") VALUES (@Title, @Code)";

        //Запрос на заполнение таблицы Форматы
        public const string InsertFormats = "INSERT INTO public.\"Formats\"(\"Title\",\"TypeOfFormat\",\"E1Limit\",\"E2Limit\",\"E3Limit\",\"DirectorOfFormatId\",\"DirectorOfKYFormatId\",\"KYFormatId\")" +
            "VALUES (" +
            "@Title," +
            "@TypeOfFormat," +
            "@E1," +
            "@E2," +
            "@E3," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @DirOfFormatLogin)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @DirOfKYFormatLogin)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @KYFormatLogin)" +
            ")";

        //Запрос на заполнение Бюджетные планы
        public const string InsertBudgetPlan = "INSERT INTO public.\"BudgetPlans\"(\"Year\") VALUES(@Year)";

        //Запрос на заполнение Строки бюджетных планов
        public const string InsertBudgetLines = "INSERT INTO public.\"BudgetLines\"(\"SubjectOfInvestment\",\"PlannedInvestmentDate\",\"Count\",\"Price\",\"Amount\"," +
            "\"BudgetPlanId\",\"CategoryOfEquipmentId\",\"ResultCenterId\",\"SiteId\",\"TypeOfInvestmentId\") VALUES(@SubjectOfInvestment,@DateOfDelivery, @Count, @Price,@Amount," +
            "(SELECT \"Id\" FROM \"BudgetPlans\" WHERE \"Year\" = @BudgetPlanYear)," +
            "(SELECT \"Id\" FROM \"CategoriesOfEquipment\" WHERE \"Title\" = @CategoryOfEquipmentTitle)," +
            "(SELECT \"Id\" FROM \"ResultCentres\" WHERE \"Title\" = @ResultCenterTitle)," +
            "(SELECT \"Id\" FROM \"Sites\" WHERE \"Title\" = @SiteTitle)," +
            "(SELECT \"Id\" FROM \"TypesOfInvestment\" WHERE \"Title\" = @TypeOfInvestmentTitle))";

        //Запрос на заполнение таблицы Ситы
        public const string InsertSites = "INSERT INTO public.\"Sites\"(\"Title\", \"FormatId\",\"KySitId\",\"TechnicalExpertId\",\"DirectorOfSitId\",\"CreaterOfBudgetId\",\"KyRegionId\",\"OperationDirectorId\")" +
            "VALUES (@Title," +
            "(SELECT \"id\" FROM public.\"Formats\" Where \"Title\" = @FormatName)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @KYSiteLogin)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @TechnicalExpertLogin)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @DirectorOfSiteLogin)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @CreaterOfBudgetLogin)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @KYRegionLogin)," +
            "(SELECT \"id\" FROM public.\"Profiles\" Where \"login\" = @OperationDirectorLogin)" +
            ")";
        //Удаление данных из таблиц
        public const string DeleteCmd =
            "DELETE FROM public.\"UserRoles\";" +
            "DELETE FROM public.\"Providers\";" +
            "DELETE FROM public.\"CategoryGroups\";" +
            "DELETE FROM public.\"Roles\";" +
            "DELETE FROM public.\"ResultCentres\";" +
            "DELETE FROM public.\"Formats\";" +
            "DELETE FROM public.\"BudgetLines\";" +
            "DELETE FROM public.\"BudgetPlans\";" +
            "DELETE FROM public.\"CategoriesOfEquipment\";" +
            "DELETE FROM public.\"TypesOfInvestment\";" +
            "DELETE FROM public.\"Profiles\";" +
            "DELETE FROM public.\"Sites\"";

    }
}
