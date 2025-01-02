using DAL.Entities;
using DAL.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString = @"Data Source=DESKTOP-56GOFPS\DEVPERSO;Initial Catalog=TF_Architect_ASPDB;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

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

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
