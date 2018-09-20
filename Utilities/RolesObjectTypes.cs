using DbSeed;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.DBSeed
{
    public class RolesObjectTypes
    {
        public void FillRolesObjectTypes()
        {
            List<(string, string, bool, bool, bool, bool)> List = new List<(string, string, bool Read, bool Write, bool Create, bool Delete)>
            {
                ("Инициатор","BudgetPlan",true, false,false,false),
                ("Доступ на чтение DAI","BudgetPlan",false, false,false,false),
                ("Генеральный директор","BudgetPlan",true, false,false,false),
                ("Директор по КУ","BudgetPlan",true, false,false,false),
                ("Техническая служба/руководитель","BudgetPlan",false, false,false,false),
                ("Бухгалтерия","BudgetPlan",true, false,false,false),
                ("Администратор бюджета","BudgetPlan",true, false,true,false),
                ("КУ технической дирекции","BudgetPlan",false, false,false,false),
                ("Администратор","BudgetPlan",true, false,true,false),
                ("Служба ИТ Поддержки","BudgetPlan",true, false,false,false),

                ("Инициатор","CategoryGroup",true, false,false,false),
                ("Доступ на чтение DAI","CategoryGroup",false, false,false,false),
                ("Генеральный директор","CategoryGroup",true, false,false,false),
                ("Директор по КУ","CategoryGroup",true, false,false,false),
                ("Техническая служба/руководитель","CategoryGroup",true, false,false,false),
                ("Бухгалтерия","CategoryGroup",true, false,false,false),
                ("Администратор бюджета","CategoryGroup",true, false,false,false),
                ("КУ технической дирекции","CategoryGroup",true, false,false,false),
                ("Администратор","CategoryGroup",true, false,false,false),
                ("Служба ИТ Поддержки","CategoryGroup",true, false,false,false),

                ("Инициатор","CategoryOfEquipment",true, false,false,false),
                ("Доступ на чтение DAI","CategoryOfEquipment",false, false,false,false),
                ("Генеральный директор","CategoryOfEquipment",true, false,true,false),
                ("Директор по КУ","CategoryOfEquipment",true, false,true,false),
                ("Техническая служба/руководитель","CategoryOfEquipment",true, false,false,false),
                ("Бухгалтерия","CategoryOfEquipment",true, false,false,false),
                ("Администратор бюджета","CategoryOfEquipment",true, false,false,false),
                ("КУ технической дирекции","CategoryOfEquipment",true, false,false,false),
                ("Администратор","CategoryOfEquipment",true, false,false,false),
                ("Служба ИТ Поддержки","CategoryOfEquipment",true, false,false,false),

                ("Инициатор","DAIRequest",true, false,true,false),
                ("Доступ на чтение DAI","DAIRequest",true, false,false,false),
                ("Генеральный директор","DAIRequest",true, false,true,false),
                ("Директор по КУ","DAIRequest",true, false,true,false),
                ("Техническая служба/руководитель","DAIRequest",true, false,false,false),
                ("Бухгалтерия","DAIRequest",true, false,false,false),
                ("Администратор бюджета","DAIRequest",true, false,true,false),
                ("КУ технической дирекции","DAIRequest",true, false,false,false),
                ("Администратор","DAIRequest",true, false,true,false),
                ("Служба ИТ Поддержки","DAIRequest",true, false,true,false),

                ("Инициатор","Format",true, false,false,false),
                ("Доступ на чтение DAI","Format",false, false,false,false),
                ("Генеральный директор","Format",false, false,false,false),
                ("Директор по КУ","Format",false, false,false,false),
                ("Техническая служба/руководитель","Format",false, false,false,false),
                ("Бухгалтерия","Format",false, false,false,false),
                ("Администратор бюджета","Format",false, false,false,false),
                ("КУ технической дирекции","Format",false, false,false,false),
                ("Администратор","Format",true, false,false,false),
                ("Служба ИТ Поддержки","Format",false, false,false,false),

                ("Инициатор","Provider",true, false,false,false),
                ("Доступ на чтение DAI","Provider",false, false,false,false),
                ("Генеральный директор","Provider",true, false,false,false),
                ("Директор по КУ","Provider",true, false,false,false),
                ("Техническая служба/руководитель","Provider",true, false,false,false),
                ("Бухгалтерия","Provider",true, false,false,false),
                ("Администратор бюджета","Provider",true, false,false,false),
                ("КУ технической дирекции","Provider",true, false,false,false),
                ("Администратор","Provider",true, false,false,false),
                ("Служба ИТ Поддержки","Provider",true, false,false,false),

                ("Инициатор","ResultCenter",true, false,false,false),
                ("Доступ на чтение DAI","ResultCenter",false, false,false,false),
                ("Генеральный директор","ResultCenter",true, false,false,false),
                ("Директор по КУ","ResultCenter",true, false,false,false),
                ("Техническая служба/руководитель","ResultCenter",true, false,false,false),
                ("Бухгалтерия","ResultCenter",true, false,false,false),
                ("Администратор бюджета","ResultCenter",true, false,false,false),
                ("КУ технической дирекции","ResultCenter",true, false,false,false),
                ("Администратор","ResultCenter",true, false,false,false),
                ("Служба ИТ Поддержки","ResultCenter",true, false,false,false),

                ("Инициатор","Site",true, false,false,false),
                ("Доступ на чтение DAI","Site",false, false,false,false),
                ("Генеральный директор","Site",true, false,false,false),
                ("Директор по КУ","Site",true, false,false,false),
                ("Техническая служба/руководитель","Site",true, false,false,false),
                ("Бухгалтерия","Site",true, false,false,false),
                ("Администратор бюджета","Site",true, false,false,false),
                ("КУ технической дирекции","Site",true, false,false,false),
                ("Администратор","Site",true, false,false,false),
                ("Служба ИТ Поддержки","Site",true, false,false,false),

                ("Инициатор","TypeOfInvestment",true, false,false,false),
                ("Доступ на чтение DAI","TypeOfInvestment",false, false,false,false),
                ("Генеральный директор","TypeOfInvestment",true, false,false,false),
                ("Директор по КУ","TypeOfInvestment",true, false,false,false),
                ("Техническая служба/руководитель","TypeOfInvestment",true, false,false,false),
                ("Бухгалтерия","TypeOfInvestment",true, false,false,false),
                ("Администратор бюджета","TypeOfInvestment",true, false,false,false),
                ("КУ технической дирекции","TypeOfInvestment",true, false,false,false),
                ("Администратор","TypeOfInvestment",true, false,false,false),
                ("Служба ИТ Поддержки","TypeOfInvestment",true, false,false,false),

                ("Инициатор","User",true, false,false,false),
                ("Доступ на чтение DAI","User",false, false,false,false),
                ("Генеральный директор","User",true, false,false,false),
                ("Директор по КУ","User",true, false,false,false),
                ("Техническая служба/руководитель","User",true, false,false,false),
                ("Бухгалтерия","User",true, false,false,false),
                ("Администратор бюджета","User",true, false,false,false),
                ("КУ технической дирекции","User",true, false,false,false),
                ("Администратор","User",true, false,false,false),
                ("Служба ИТ Поддержки","User",true, false,false,false),
            };
            using (NpgsqlConnection connection = new NpgsqlConnection(Constants.connectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(Constants.InsertRolesObjectTypes, connection))
            {
                connection.Open();
                foreach (var item in List)
                {
                    cmd.Parameters.Add("@RoleTitle", NpgsqlTypes.NpgsqlDbType.Text).Value = item.Item1;
                    cmd.Parameters.Add("@ObjectTitle",NpgsqlTypes.NpgsqlDbType.Text).Value ="%." + item.Item2;
                    cmd.Parameters.Add("@AllowRead", NpgsqlTypes.NpgsqlDbType.Boolean).Value = item.Item3;
                    cmd.Parameters.Add("@AllowWrite", NpgsqlTypes.NpgsqlDbType.Boolean).Value = item.Item4;
                    cmd.Parameters.Add("@AllowCreate", NpgsqlTypes.NpgsqlDbType.Boolean).Value = item.Item5;
                    cmd.Parameters.Add("@AllowDelete", NpgsqlTypes.NpgsqlDbType.Boolean).Value = item.Item6;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                connection.Close();
            }
        }
    }
}
