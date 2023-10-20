using Microsoft.Data.SqlClient;

string connectionString = "Server=CECO\\SQLEXPRESS;Database=MinionsDB;User Id=sa;Password=1234;TrustServerCertificate=True;";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string query = "SELECT \r\n\tv.[Name]\r\n\t,COUNT(m.Id) [OutPut]\r\nFROM Villains v\r\nJOIN MinionsVillains mv ON mv.VillainId = v.Id\r\nJOIN Minions m ON m.Id = mv.MinionId\r\nGROUP BY v.[Name] \r\nHAVING COUNT(m.Id) > 3\r\nORDER BY [OutPut] DESC";

using SqlCommand command = new SqlCommand(query, connection);

SqlDataReader sqlDataReader = command.ExecuteReader();

while (sqlDataReader.Read())
{
    Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]}");
}