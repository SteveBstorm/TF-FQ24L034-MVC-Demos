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
    public class ProductRepository : IProductRepository
    {
        //private string connectionString = @"Data Source=DESKTOP-56GOFPS\DEVPERSO;Initial Catalog=TF_Architect_ASPDB;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private string connectionString;
        public ProductRepository(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        public void Create(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Product (Name, Price, Quantity) " +
                        "VALUES (@name, @price, @quantity)";

                    cmd.Parameters.AddWithValue("name", product.Name);
                    cmd.Parameters.AddWithValue("price", product.Price);
                    cmd.Parameters.AddWithValue("quantity", product.Quantity);

                    connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }

                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Product";
                    connection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product { 
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Quantity = (int)reader["Quantity"],
                                Price = (decimal)reader["Price"]
                            });
                        }
                    }
                    connection.Close();
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            Product products = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Product WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            products = new Product
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Quantity = (int)reader["Quantity"],
                                Price = (decimal)reader["Price"]
                            };
                        }
                    }
                    connection.Close();
                }
            }
            if (products is null) throw new NullReferenceException("Le produit n'existe pas");
            return products;
        }
    }
}
