using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

string connectionString = "Server=CECO\\SQLEXPRESS;Database=MinionsDB;User Id=sa;Password=1234;TrustServerCertificate=True;";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string query = "SELECT \r\n\tm.[Name]\r\n\t,m.Age\r\nFROM Minions m\r\nJOIN MinionsVillains mv ON mv.MinionId = m.Id\r\nJOIN Villains v ON v.id = mv.VillainId\r\nWHERE v.Id = @vId;";
string queryCheckForVallains = "SELECT v.[Name], COUNT(m.Id) FROM Minions m\r\nRIGHT JOIN MinionsVillains mv ON mv.MinionId = m.Id\r\nRIGHT JOIN Villains v ON v.Id = mv.VillainId\r\nWHERE v.id = @vId\r\nGROUP BY v.[Name]";

using SqlCommand command = new SqlCommand(query, connection);
using SqlCommand commandCheckForVallains = new SqlCommand(queryCheckForVallains, connection);

int vId = int.Parse(Console.ReadLine());
command.Parameters.AddWithValue("@vId", vId);
commandCheckForVallains.Parameters.AddWithValue("@vId", vId);


SqlDataReader sqlDataReaderCheckForVallains = commandCheckForVallains.ExecuteReader();
sqlDataReaderCheckForVallains.Read();
if (!sqlDataReaderCheckForVallains.HasRows)
{
    Console.WriteLine($"No villain with ID {vId} exists in the database.");
    return;
}
string vName = (string)sqlDataReaderCheckForVallains[0];
int numOfMinions = (int)sqlDataReaderCheckForVallains[1];
sqlDataReaderCheckForVallains.Close();
SqlDataReader sqlDataReader = command.ExecuteReader();


if (numOfMinions == 0)
    Console.WriteLine("(no minions)");
else 
{
    Console.WriteLine($"Villain: {vName}");
    int i = 1;
    while (sqlDataReader.Read()) 
    {
        Console.WriteLine($"{i}. {sqlDataReader[0]} {sqlDataReader[1]}");
        i++;
    }
}