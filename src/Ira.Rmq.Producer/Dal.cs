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
                using SqlConnection con = new(_connectionString);
                SqlCommand cmd = new("select * from Notification where SentDate is null", con);

                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    notifications.Add(new()
                    {
                        Id = rdr.GetGuid("Id"),
                        Email = rdr.GetString("Email"),
                        Subject = rdr.GetString("Subject"),
                        Message = rdr.GetString("Message"),
                    });
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
