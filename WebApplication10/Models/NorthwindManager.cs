using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApplication10.Models
{
    public class NorthwindManager
    {
        private string _connectionString;

        public NorthwindManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> SearchByStock(int? min, int? max)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE UnitsInStock " +
                              "BETWEEN @min AND @max";
            if (min == null)
            {
                cmd.Parameters.AddWithValue("@min", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@min", min);
            }
            if (max == null)
            {
                cmd.Parameters.AddWithValue("@max", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@max", max);
            }
            List<Product> products = new List<Product>();
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    Name = (string)reader["PRoductName"],
                    QuantityInStock = (short)reader["UnitsInStock"],
                    UnitPrice = (decimal)reader["UnitPrice"]
                });
            }

            connection.Close();
            connection.Dispose();
            return products;
        }
    }
}