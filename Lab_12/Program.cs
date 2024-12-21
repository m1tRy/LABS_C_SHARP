using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=laba_11;Trusted_Connection=True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Open");

                string sqlExpression1 = "SELECT * FROM Authors;";

                SqlCommand command = new SqlCommand(sqlExpression1, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);
                    string columnName4 = reader.GetName(3);
                    Console.WriteLine($"{columnName1}\t{columnName2}\t{columnName3}\t{columnName4}");

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object title = reader.GetValue(1);
                        object isbn = reader.GetValue(2);
                        object year = reader.GetValue(3);
                        Console.WriteLine($"{id} \t {title} \t {isbn} \t {year}");
                    }
                }

                reader.Close();

            }
            

        }
    }
}