using DbSeed;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.DBSeed;

namespace WBS.DBSeed
{
    public class UserRole
    {
        public void FillUserRole(string login, Array ListRole)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Constants.connectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(Constants.InsertUserRoles, connection))
            {
                connection.Open();
                foreach (var role in ListRole)
                {
                    cmd.Parameters.Add("@Login", NpgsqlDbType.Text).Value = login;
                    cmd.Parameters.Add("@RoleName", NpgsqlDbType.Text).Value = role.ToString();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
        public void FillUserRole(string login, string role)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Constants.connectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(Constants.InsertUserRoles, connection))
            {
                connection.Open();
                cmd.Parameters.Add("@Login", NpgsqlDbType.Text).Value = login;
                cmd.Parameters.Add("@RoleName", NpgsqlDbType.Text).Value = role;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }
    }
}
