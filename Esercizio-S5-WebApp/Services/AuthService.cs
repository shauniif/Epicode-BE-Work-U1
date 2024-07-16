using System.Data.SqlClient;
using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public class AuthService : SqlServerServiceBase, IAuthService
    {
        private const string LOGIN_COMM = "SELECT IdUtente FROM Users WHERE Username = @user AND Password = @pass";
        public AuthService(IConfiguration config) : base(config)
        {
        }

        

        public ApplicationUser Login(string username, string password)
        {
            try
            {
                var cmd = GetCommand(LOGIN_COMM);
                using var conn = GetConnection();
                conn.Open();
                cmd.Parameters.Add(new SqlParameter("@user", username));
                cmd.Parameters.Add(new SqlParameter("@pass", password));
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new ApplicationUser
                    {
                        Id = reader.GetInt32(0),
                        Username = username,
                        Password = password
                    };
                    return user;
                }
            }
            catch(Exception ex) 
            {

            }
            return null;
        }
    }
}
