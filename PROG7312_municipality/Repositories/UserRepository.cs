using PROG7312_municipality.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_municipality.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
       

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                //command.CommandText = "select *from [User] where username=@username and [password]=@password";
                command.CommandText = "SELECT * FROM [User] WHERE username = @Username";
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = credential.UserName;
              //  command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }


        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {

                            Id = reader.GetGuid(reader.GetOrdinal("Id")), // Correctly cast GUID
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Avoid storing plain passwords
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                        };
                    }
                }
            }
            return user;
        }



       










        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }


        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
