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
    class AddUser
    {
        public void FillUsers(ListItem user,string jobPosition,string role)
        {
            string login;
            string department;
            using (NpgsqlConnection connection = new NpgsqlConnection(Constants.connectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(Constants.InsertProfiles, connection))
            {
                connection.Open();
                try
                {
                    login = user["UserName"].ToString();

                    if (login == null)
                    {
                        login = user["Name"].ToString();
                    }

                    department = user["Department"].ToString();

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
                    cmd.Parameters["@FIO"].Value = user["Title"].ToString();
                    cmd.Parameters["@DeletionMark"].Value = Convert.ToBoolean(user["Attachments"]);
                    cmd.Parameters["@jobPosition"].Value = jobPosition;
                    cmd.Parameters["@Department"].Value = department;

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    UserRole userRole = new UserRole();
                    userRole.FillUserRole(login, role);
                    cmd.Parameters.Clear();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
