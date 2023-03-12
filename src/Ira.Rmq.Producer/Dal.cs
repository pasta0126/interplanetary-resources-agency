using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Ira.Models.Entities;

namespace Ira.Rmq.Producer
{
    public class Dal
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Dal(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("IraDBLocal");
        }

        public List<Notification> GetAllNotifications()
        {
            var notifications = new List<Notification>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from Notification", con);

                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        notifications.Add(new()
                        {
                            //DepartmentID = rdr.GetInt16("DepartmentID"),
                            //Name = rdr.GetString("Name"),
                            //GroupName = rdr.GetString("GroupName"),
                            //ModifiedDate = rdr.GetDateTime("ModifiedDate")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return notifications;
        }
    }
}
