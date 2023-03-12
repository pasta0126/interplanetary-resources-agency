using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Ira.Rmq.Consumer
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

        public void UpdateNotification(Guid id)
        {
            try
            {
                using SqlConnection con = new(_connectionString);
                SqlCommand cmd = new($"update Notification set IsSentOk = 1, SentDate = GETDATE() where Id = '{id}'", con);

                cmd.CommandType = CommandType.Text;
                con.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
