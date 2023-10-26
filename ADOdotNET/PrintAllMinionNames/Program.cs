using Microsoft.Data.SqlClient;

string connectionString = "Server=CECO\\SQLEXPRESS;Database=MinionsDB;User Id=sa;Password=1234;TrustServerCertificate=True;";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string query = "SELECT [Name] FROM Minions;";

SqlCommand command = new SqlCommand(query, connection);
SqlDataReader reader = command.ExecuteReader();
List<string> list = new List<string>();

while (reader.Read()) 
{
    list.Add(reader["Name"].ToString());
}

for (int i = 0; i < list.Count/2; i++)
{
    Console.WriteLine(list[i]);
    Console.WriteLine(list[list.Count-i-1]);
}