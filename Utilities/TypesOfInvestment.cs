using DbSeed;
using Microsoft.SharePoint.Client;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.DBSeed
{
    class TypesOfInvestment
    {
        public void FillTypeOfInvestment(ListItemCollection items)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Constants.connectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(Constants.InsertTypesOfInvestment, connection))
            {
                connection.Open();
                Console.WriteLine("Заполнение данных Типы инвестиций...");
                foreach (ListItem item in items)
                {
                    Console.WriteLine(item.FieldValues["Title"]);
                    cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                    cmd.Parameters.Add("@Code", NpgsqlDbType.Text).Value = item["Code"].ToString();
                    cmd.Parameters.Add("@ExternalCode", NpgsqlDbType.Text).Value = item["CodeExternal"].ToString();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            } 
        }
    }
}
