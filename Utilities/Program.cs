using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Library;
using NpgsqlTypes;
using System.Linq;
using WBS.DBSeed;

namespace DbSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRole userRole = new UserRole();
            using (ClientContext cc = new ClientContext("http://192.168.88.69:3333"))
            {

                cc.Credentials = new NetworkCredential("auchan_admin", "P@ssWord*1!", "Qpd");
                Web web = cc.Web;

                using (NpgsqlConnection connection = new NpgsqlConnection(Constants.connectionString))
                using (NpgsqlCommand cmd = new NpgsqlCommand(Constants.DeleteCmd, connection))
                {
                    connection.Open();

                    //Удаление из таблиц данных командой DeleteCmd
                    cmd.ExecuteNonQuery();

                    //Получение таблицы Поставщики
                    List list = web.Lists.GetByTitle("Поставщики");

                    CamlQuery caml = new CamlQuery();

                    //Получение столбцов таблицы Поставщики
                    ListItemCollection items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    //Изменение команды
                    cmd.CommandText = Constants.InsertProviders;
                    Console.WriteLine("Заполнение данных Providers...");

                    //Заполнение таблицы поставщиков
                    foreach (ListItem item in items)
                    {
                        cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                        Console.WriteLine(item["Title"]);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    //Получение таблицы Типы инвестиций
                    list = web.Lists.GetByTitle("Типы инвестиций");

                    //Получение данных таблицы Поставщики
                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    cmd.CommandText = Constants.InsertTypesOfInvestment;

                    Console.WriteLine("Заполнение данных Типы инвестиций...");

                    //Заполнение таблицы поставщиков
                    foreach (ListItem item in items)
                    {
                        Console.WriteLine(item.FieldValues["Title"]);
                        cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                        cmd.Parameters.Add("@Code", NpgsqlDbType.Text).Value = item["Code"].ToString();
                        cmd.Parameters.Add("@ExternalCode", NpgsqlDbType.Text).Value = item["CodeExternal"].ToString();
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    //Получение таблицы Группы категорий
                    list = web.Lists.GetByTitle("Группы категорий");

                    //Получение данных таблицы Группы категорий
                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    cmd.CommandText = Constants.InsertGroupsOfCategories;

                    Console.WriteLine("Заполнение данных Группы категорий...");

                    //Заполнение таблицы Группы категорий
                    foreach (ListItem item in items)
                    {
                        cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                        cmd.Parameters.Add("@Code", NpgsqlDbType.Text).Value = item["Code"].ToString();
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    //Получение таблицы Категории оборудования
                    list = web.Lists.GetByTitle("Категории оборудования");

                    //Получение столбцов таблицы Категории оборудования
                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    cmd.CommandText = Constants.InsertCategoriesOfEquipment;

                    Console.WriteLine("Заполнение данных Категории оборудования...");

                    foreach (ListItem item in items)
                    {
                        FieldLookupValue field = item.FieldValues["CategoryGroupsLookup"] as FieldLookupValue;
                        cc.Load(item);

                        cc.ExecuteQuery();

                        cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                        cmd.Parameters.Add("@Code", NpgsqlDbType.Text).Value = item["Code"].ToString();
                        cmd.Parameters.Add("@DepreciationPeriod", NpgsqlDbType.Integer).Value = Convert.ToDouble(item["Amortization"]);
                        cmd.Parameters.Add("@NameCategory", NpgsqlDbType.Text).Value = field.LookupValue;

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    //заполнение Ролей
                    cmd.CommandText = Constants.InsertRole;
                    cmd.ExecuteNonQuery();

                    //заполнение пользователей
                    Console.WriteLine("Заполнение данных Пользователи...");
                    list = web.Lists.GetByTitle("Пользователи");

                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    List userInformationList = web.SiteUserInfoList;

                    string login = string.Empty;
                    string jobPosition = string.Empty;
                    string department = string.Empty;
                    Array arrayRoles;

                    foreach (var item in items)
                    { 
                        try
                        {
                            cmd.CommandText = Constants.InsertProfiles;
                            FieldUserValue userValue = (FieldUserValue)item["DAIUser"];
                            ListItem itm = userInformationList.GetItemById(userValue.LookupId);
                            cc.Load(itm);
                            cc.ExecuteQuery();

                            //Если пользователь удалён, пропускаем итерацию
                            //if (Convert.ToBoolean(item["IsDeleted"]) == true)
                            //{
                            //    continue;
                            //}

                            login = itm["UserName"].ToString();

                            if (login == null)
                            {
                                login = itm["Name"].ToString();
                            }

                            jobPosition = item["DAIJobTitle"].ToString();

                            if (jobPosition == null)
                            {
                                jobPosition = "empty";
                            }

                            department = item["DAIDepartment"].ToString();

                            if (department == null)
                            {
                                department = "empty";
                            }

                            cmd.Parameters.Add("@Login", NpgsqlDbType.Text);
                            cmd.Parameters.Add("@Password", NpgsqlDbType.Text);
                            cmd.Parameters.Add("@FIO", NpgsqlDbType.Text);
                            cmd.Parameters.Add("@DeletionMark", NpgsqlDbType.Boolean);
                            cmd.Parameters.Add("@jobPosition", NpgsqlDbType.Text);
                            cmd.Parameters.Add("@Department", NpgsqlDbType.Text);

                            cmd.Parameters["@Login"].Value = login;
                            cmd.Parameters["@Password"].Value = "AQAAAAEAACcQAAAAEMxLaU+KB/2Daq1cjWcUEVM+mk01XyoaAO46VoDocwFobNVaCEjCzOxATCa478fQUg==";
                            cmd.Parameters["@FIO"].Value = userValue.LookupValue;
                            cmd.Parameters["@DeletionMark"].Value = Convert.ToBoolean(itm["Attachments"]);
                            cmd.Parameters["@jobPosition"].Value = jobPosition;
                            cmd.Parameters["@Department"].Value = department;

                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            //Заполнение UserRoles
                            arrayRoles = (Array)item["DAIRoles"];
                            userRole.FillUserRole(login, arrayRoles);
                            cmd.Parameters.Clear();
                            //foreach (var role in arrayRoles)
                            //{
                            //    cmd.Parameters.Add("@Login", NpgsqlDbType.Text).Value = login;
                            //    cmd.Parameters.Add("@RoleName", NpgsqlDbType.Text).Value = role.ToString();
                            //    cmd.ExecuteNonQuery();
                            //    cmd.Parameters.Clear();
                            //}
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            cmd.Parameters.Clear();
                        }
                    }

                    //получение таблицы Центры результата
                    list = web.Lists.GetByTitle("Центры результата");
                    //получение данных таблицы
                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    Console.WriteLine("Заполнение данных Центры результата...");

                    cmd.CommandText = Constants.InsertResultCentres;
                    //Заполнение таблицы Центры результата
                    foreach (var item in items)
                    {
                        try
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"];
                            cmd.Parameters.Add("@Code", NpgsqlDbType.Text).Value = item["Code"];
                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    //Получение таблицы Формат ситов
                    list = web.Lists.GetByTitle("Формат ситов");

                    //Получение данных таблицы Формат ситов
                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    string DirOfFormatLogin = string.Empty;
                    string DirOfKYFormatLogin = string.Empty;
                    string KYFormatLogin = string.Empty;

                    Console.WriteLine("Заполнение данных Формат ситов...");

                    cmd.CommandText = Constants.InsertFormats;
                    FieldUserValue userValue1;
                    FieldUserValue userValue2;
                    FieldUserValue userValue3;

                    foreach (var item in items)
                    {
                        try
                        {
                            cmd.Parameters.Clear();
                            userValue1 = (FieldUserValue)item["SiteDirOfFormat"];
                            userValue2 = (FieldUserValue)item["SiteDirOfKYFormat"];
                            userValue3 = (FieldUserValue)item["SiteKYFormat"];

                            ListItem DirOfFormat = userInformationList.GetItemById(userValue1.LookupId);
                            ListItem DirOfKYFormat = userInformationList.GetItemById(userValue2.LookupId);
                            ListItem KYFormat = userInformationList.GetItemById(userValue3.LookupId);

                            cc.Load(DirOfFormat);
                            cc.Load(DirOfKYFormat);
                            cc.Load(KYFormat);

                            cc.ExecuteQuery();

                            AddUser user = new AddUser();
                            user.FillUsers(DirOfFormat, "Директор формата", "Администратор");
                            user.FillUsers(DirOfKYFormat, "Директор КУ формата", "Администратор");
                            user.FillUsers(KYFormat, "КУ формата", "Администратор");

                            DirOfFormatLogin = DirOfFormat["UserName"].ToString();
                            DirOfKYFormatLogin = DirOfKYFormat["UserName"].ToString();
                            KYFormatLogin = KYFormat["UserName"].ToString();

                            if (DirOfFormatLogin == null)
                            {
                                DirOfFormatLogin = DirOfFormat["Name"].ToString();
                            }

                            if (DirOfKYFormatLogin == null)
                            {
                                DirOfKYFormatLogin = DirOfKYFormat["Name"].ToString();
                            }

                            if (KYFormatLogin == null)
                            {
                                KYFormatLogin = KYFormat["Name"].ToString();
                            }


                            cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                            cmd.Parameters.Add("@E1", NpgsqlDbType.Integer).Value = Convert.ToDouble(item["E1Limit"]);
                            cmd.Parameters.Add("@E2", NpgsqlDbType.Integer).Value = Convert.ToDouble(item["E2Limit"]);
                            cmd.Parameters.Add("@E3", NpgsqlDbType.Integer).Value = Convert.ToDouble(item["E3Limit"]);
                            cmd.Parameters.Add("@TypeOfFormat", NpgsqlDbType.Text).Value = item["KindOfFormat"].ToString();
                            cmd.Parameters.Add("@DirOfFormatLogin", NpgsqlDbType.Text).Value = DirOfFormatLogin;
                            cmd.Parameters.Add("@DirOfKYFormatLogin", NpgsqlDbType.Text).Value = DirOfKYFormatLogin;
                            cmd.Parameters.Add("@KYFormatLogin", NpgsqlDbType.Text).Value = KYFormatLogin;

                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    list = web.Lists.GetByTitle("Ситы");
                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    cmd.CommandText = Constants.InsertSites;

                    Console.WriteLine("Заполнение данных Ситы...");

                    string SiteKYLogin;
                    string SiteTechExpLogin;
                    string SiteDirectorLogin;
                    string SiteCreaterOfBudgetLogin;
                    string SiteKYRegionalLogin;
                    string SiteOperatingDirLogin;

                    FieldUserValue userValue4;
                    FieldUserValue userValue5;
                    FieldUserValue userValue6;
                    FieldLookupValue FormatLookup;

                    ListItem SiteDirector;
                    ListItem SiteKY;
                    ListItem SiteTechExp;
                    ListItem SiteKYRegional;
                    ListItem SiteOperatingDir;
                    ListItem SiteCreaterOfBudget;

                    foreach (var item in items)
                    {
                        try
                        {
                            cmd.Parameters.Clear();

                            Array KYRegional = (Array)item["SiteKYRegional"];
                            cmd.Parameters.Clear();
                            userValue1 = (FieldUserValue)item["SiteDirector"];
                            userValue2 = (FieldUserValue)item["SiteKY"];
                            userValue3 = (FieldUserValue)item["SiteTechExp"];
                            userValue4 = (FieldUserValue)KYRegional.GetValue(0);
                            userValue5 = (FieldUserValue)item["SiteOperatingDir"];
                            userValue6 = (FieldUserValue)item["SiteCreaterOfBudget"];
                            FormatLookup = (FieldLookupValue)item["FormatLookup"];

                            SiteDirector = userInformationList.GetItemById(userValue1.LookupId);
                            SiteKY = userInformationList.GetItemById(userValue2.LookupId);
                            SiteTechExp = userInformationList.GetItemById(userValue3.LookupId);
                            SiteKYRegional = userInformationList.GetItemById(userValue4.LookupId);
                            SiteOperatingDir = userInformationList.GetItemById(userValue5.LookupId);
                            SiteCreaterOfBudget = userInformationList.GetItemById(userValue6.LookupId);

                            cc.Load(SiteDirector);
                            cc.Load(SiteKY);
                            cc.Load(SiteTechExp);
                            cc.Load(SiteKYRegional);
                            cc.Load(SiteOperatingDir);
                            cc.Load(SiteCreaterOfBudget);

                            cc.ExecuteQuery();

                            AddUser user = new AddUser();
                            user.FillUsers(SiteDirector,"Директор Сита", "Администратор");
                            user.FillUsers(SiteKY, "КУ Сита", "Администратор");
                            user.FillUsers(SiteTechExp, "Технический эксперт", "Администратор");
                            user.FillUsers(SiteKYRegional, "КУ региональный", "Администратор");
                            user.FillUsers(SiteOperatingDir, "Операционный директор", "Администратор");
                            user.FillUsers(SiteCreaterOfBudget, "Creater of Budget", "Администратор");

                            SiteKYLogin = SiteKY["UserName"].ToString();
                            SiteTechExpLogin = SiteTechExp["UserName"].ToString();
                            SiteDirectorLogin = SiteDirector["UserName"].ToString();
                            SiteCreaterOfBudgetLogin = SiteCreaterOfBudget["UserName"].ToString();
                            SiteKYRegionalLogin = SiteKYRegional["UserName"].ToString();
                            SiteOperatingDirLogin = SiteOperatingDir["UserName"].ToString();

                            if (SiteKYLogin == null)
                            {
                                SiteKYLogin = SiteKY["Name"].ToString();
                            }

                            if (SiteTechExpLogin == null)
                            {
                                SiteTechExpLogin = SiteTechExp["Name"].ToString();
                            }

                            if (SiteDirectorLogin == null)
                            {
                                SiteDirectorLogin = SiteDirector["Name"].ToString();
                            }

                            if (SiteCreaterOfBudgetLogin == null)
                            {
                                SiteCreaterOfBudgetLogin = SiteCreaterOfBudget["Name"].ToString();
                            }

                            if (SiteKYRegionalLogin == null)
                            {
                                SiteKYRegionalLogin = SiteKYRegional["Name"].ToString();
                            }

                            if (SiteOperatingDirLogin == null)
                            {
                                SiteOperatingDirLogin = SiteOperatingDir["Name"].ToString();
                            }
                            if(FormatLookup.LookupValue == null || item["Title"].ToString() == null || SiteKYLogin ==null || SiteTechExpLogin == null || SiteDirectorLogin == null || SiteCreaterOfBudgetLogin ==null || SiteKYRegionalLogin == null || SiteOperatingDirLogin == null)
                            {
                                Console.WriteLine("Значение - null");
                            }

                            cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                            cmd.Parameters.Add("@FormatName", NpgsqlDbType.Text).Value = FormatLookup.LookupValue.ToString();
                            cmd.Parameters.Add("@KYSiteLogin", NpgsqlDbType.Text).Value = SiteKYLogin;
                            cmd.Parameters.Add("@TechnicalExpertLogin", NpgsqlDbType.Text).Value = SiteTechExpLogin;
                            cmd.Parameters.Add("@DirectorOfSiteLogin", NpgsqlDbType.Text).Value = SiteDirectorLogin;
                            cmd.Parameters.Add("@CreaterOfBudgetLogin", NpgsqlDbType.Text).Value = SiteCreaterOfBudgetLogin;
                            cmd.Parameters.Add("@KYRegionLogin", NpgsqlDbType.Text).Value = SiteKYRegionalLogin;
                            cmd.Parameters.Add("@OperationDirectorLogin", NpgsqlDbType.Text).Value = SiteOperatingDirLogin;

                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            cmd.Parameters.Clear();
                        }
                    }

                    list = web.Lists.GetByTitle("Бюджетные планы");

                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();

                    Console.WriteLine("Заполнение данных Бюджетные планы...");

                    cmd.CommandText = Constants.InsertBudgetPlan;

                    foreach (var item in items)
                    {
                        try
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Year", NpgsqlDbType.Integer).Value = Convert.ToInt32(item["BudgetYear"]);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    list = web.Lists.GetByTitle("Строки бюджетного плана");

                    items = list.GetItems(caml);
                    cc.Load(items);

                    cc.ExecuteQuery();
                    double Price = 1;
                    double Amount;
                    int Count = 1;
                    string Month;
                    int MonthId = 0;
                    FieldLookupValue BudgetLookup;
                    FieldLookupValue CategoryOfEquipment;
                    FieldLookupValue ResultCenter;
                    FieldLookupValue Site;
                    FieldLookupValue TypeOfInvestment;

                    Console.WriteLine("Заполнение данных Строки бюджетного плана...");
                    cmd.CommandText = Constants.InsertBudgetLines;

                    foreach (var item in items)
                    {
                        try
                        {
                            Month = item["PlannedInvestmentDate"].ToString();
                            Price = Convert.ToInt32(item["Price"]);
                            Count = Convert.ToInt32(item["Quantity"]);
                            Amount = Price * Count;
                            switch (Month)
                            {
                                case "Январь":
                                    MonthId = 1;
                                    break;
                                case "Февраль":
                                    MonthId = 2;
                                    break;
                                case "Март":
                                    MonthId = 3;
                                    break;
                                case "Апрель":
                                    MonthId = 4;
                                    break;
                                case "Май":
                                    MonthId = 5;
                                    break;
                                case "Июнь":
                                    MonthId = 6;
                                    break;
                                case "Июль":
                                    MonthId = 7;
                                    break;
                                case "Август":
                                    MonthId = 8;
                                    break;
                                case "Сентябрь":
                                    MonthId = 9;
                                    break;
                                case "Октябрь":
                                    MonthId = 10;
                                    break;
                                case "Ноябрь":
                                    MonthId = 11;
                                    break;
                                case "Декабрь":
                                    MonthId = 12;
                                    break;
                                default: break;
                            }

                            BudgetLookup = (FieldLookupValue)item["BudgetLookup"];
                            CategoryOfEquipment = (FieldLookupValue)item["CategoryOfEquipmentLookup"];
                            ResultCenter = (FieldLookupValue)item["ResultCenterLookup"];
                            Site = (FieldLookupValue)item["SiteLookup"];
                            TypeOfInvestment = (FieldLookupValue)item["TypeOfInvestmentLookup"];

                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@SubjectOfInvestment", NpgsqlDbType.Text).Value = item["InvestmentSubject"].ToString();
                            cmd.Parameters.Add("@DateOfDelivery", NpgsqlDbType.Integer).Value = MonthId;
                            cmd.Parameters.Add("@Count", NpgsqlDbType.Integer).Value = Count;
                            cmd.Parameters.Add("@Price", NpgsqlDbType.Double).Value = Price;
                            cmd.Parameters.Add("@Amount", NpgsqlDbType.Double).Value = Amount;
                            cmd.Parameters.Add("@BudgetPlanYear", NpgsqlDbType.Integer).Value = Convert.ToInt32(BudgetLookup.LookupValue);
                            cmd.Parameters.Add("@CategoryOfEquipmentTitle", NpgsqlDbType.Text).Value = CategoryOfEquipment.LookupValue;
                            cmd.Parameters.Add("@SiteTitle", NpgsqlDbType.Text).Value = Site.LookupValue;
                            cmd.Parameters.Add("@TypeOfInvestmentTitle", NpgsqlDbType.Text).Value = TypeOfInvestment.LookupValue;

                            if (ResultCenter is null)
                            {
                                cmd.Parameters.Add("@ResultCenterTitle", NpgsqlDbType.Text).Value = "empty";
                            }
                            else
                                cmd.Parameters.Add("@ResultCenterTitle", NpgsqlDbType.Text).Value = ResultCenter.LookupValue;


                            cmd.ExecuteNonQuery();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    connection.Close();
                    Console.WriteLine("Заполнение окончено");
                    Console.ReadLine();
                }
            }
        }
    }
}
