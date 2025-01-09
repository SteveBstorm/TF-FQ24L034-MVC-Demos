using DAL.Entities;
using DAL.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;
        public UserRepository(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        private User Mapper(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Username = (string)reader["Username"],
                Email = (string)reader["Email"],
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users";
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //mapper
                            users.Add(Mapper(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return users;
        }

        public User GetByEmail(string email)
        {
            User CurrentUser = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Email = @email";
                    cmd.Parameters.AddWithValue("email", email);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Mapper
                            CurrentUser = Mapper(reader);
                            //CurrentUser = new User
                            //{
                            //    Id = (int)reader["Id"],
                            //    Username = (string)reader["Username"],
                            //    Email = (string)reader["Email"],
                            //    IsAdmin = (bool)reader["IsAdmin"]
                            //};
                        }
                    }
                    connection.Close();
                }
            }
            return CurrentUser;
        }

        public string GetPassword(string email)
        {
            string password;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT Password FROM Users WHERE Email = @email";
                    cmd.Parameters.AddWithValue("email", email);
                    connection.Open();
                    password = (string)cmd.ExecuteScalar();
                    connection.Close();
                }
            }
            if (!string.IsNullOrEmpty(password))
                return password;
            throw new ArgumentNullException("email inexistant");
        }

        public void Register(string email, string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Users (Email, Password, Username) " +
                        "VALUES (@email, @password, @username)";
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.Parameters.AddWithValue("username", username);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }catch(SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public void SetUserAsAdmin(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Users SET IsAdmin = 1 WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
