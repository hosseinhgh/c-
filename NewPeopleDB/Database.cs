using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPeopleDB
{
    class Database
    {
        private string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\teacher\Documents\NewPeopleDB.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }

        public List<Person> GetAllPersons()
        {
            List<Person> result = new List<Person>();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM People ORDER BY Id", conn);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int xId = (int)reader["Id"];
                    string xName = (string)reader["Name"];
                    int xAge = (int)reader["Age"];
                    double xHeight = (float)reader["Height"]; // float -> double
                    Person p = new Person {Id=xId, Name=xName, Age=xAge, Height=xHeight};
                    result.Add(p);
                }
            }
            return result;
        }

        // NOTE add modified so that it returns ID of the record just created
        public int AddPerson(Person p)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO People (Name, Age, Height) VALUES (@Name, @Age, @Height); SELECT SCOPE_IDENTITY();", conn);
            insertCommand.Parameters.Add(new SqlParameter("Name", p.Name));
            insertCommand.Parameters.Add(new SqlParameter("Age", p.Age));
            insertCommand.Parameters.Add(new SqlParameter("Height", p.Height));
            //insertCommand.ExecuteNonQuery();
            int id = (int) insertCommand.ExecuteScalar(); // return ID of the record just created
            return id;
        }

        public void DeletePerson(int Id)
        {

        }

        public void UpdatePerson(Person p)
        {

        }

    }
}
