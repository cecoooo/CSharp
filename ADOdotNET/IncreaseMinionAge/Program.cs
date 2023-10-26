using Microsoft.Data.SqlClient;

string connectionString = "Server=CECO\\SQLEXPRESS;Database=MinionsDB;User Id=sa;Password=1234;TrustServerCertificate=True;";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string query = "SELECT [Name], Age\r\nFROM Minions;";
string query2 = "UPDATE Minions\r\nSET [Name] = LOWER([Name]), Age += 1\r\nWHERE Id = @Id";

int[] ids = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
using SqlCommand command2 = new SqlCommand(query2, connection);
for (int i = 0; i < ids.Length; i++)
{
    command2.Parameters.AddWithValue("@Id", ids[i]);
    using SqlDataReader reader2 = command2.ExecuteReader();
}

using SqlCommand command = new SqlCommand(query, connection);
using SqlDataReader sqlDataReader = command.ExecuteReader();

while (sqlDataReader.Read()) 
{
    Console.WriteLine($"{sqlDataReader["Name"]} {sqlDataReader["Age"]}");
}