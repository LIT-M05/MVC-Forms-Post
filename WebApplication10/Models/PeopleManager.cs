using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApplication10.Models
{
    public class PeopleManager
    {
        private string _connectionString;

        public PeopleManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(Person person)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO People (FirstName, LastName, Age) " +
                              "VALUES (@f, @l, @a)";
            cmd.Parameters.AddWithValue("@f", person.FirstName);
            cmd.Parameters.AddWithValue("@l", person.LastName);
            cmd.Parameters.AddWithValue("@a", person.Age);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }

        public int GetPeopleCount()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Count(*) FROM People";
            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();
            connection.Dispose();
            return count;
        }

        public IEnumerable<Person> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Person> people = new List<Person>();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            connection.Close();
            connection.Dispose();
            return people;
        }
    }
}