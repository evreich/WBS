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
    public class Providers
    {
        public void FillProvider(ListItemCollection items)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Constants.connectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(Constants.InsertProviders, connection))
            {
                connection.Open();
                Console.WriteLine("Заполнение данных Providers...");
                foreach (var item in items)
                {
                    cmd.Parameters.Add("@Title", NpgsqlDbType.Text).Value = item["Title"].ToString();
                    Console.WriteLine(item["Title"]);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
