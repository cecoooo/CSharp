using Microsoft.Data.SqlClient;

string connectionString = "Server=CECO\\SQLEXPRESS;Database=MinionsDB;User Id=sa;Password=1234;TrustServerCertificate=True;";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string queryChangeTownNames = "UPDATE t\r\nSET t.[Name] = UPPER(t.[Name])\r\nFROM Towns t\r\nJOIN Countries c\r\nON t.CountryCode = c.Id\r\nWHERE c.[Name] = @country;";
string queryGetTowns = "SELECT t.[Name] \r\nFROM Towns t \r\nJOIN Countries c ON c.Id = t.CountryCode\r\nWHERE c.[Name] = @country;";

string country = Console.ReadLine();

using SqlCommand sqlCommandChangeTownNames = new SqlCommand(queryChangeTownNames, connection);
sqlCommandChangeTownNames.Parameters.AddWithValue("@country", country);
using SqlDataReader sqlDataReaderChangeTownNames = sqlCommandChangeTownNames.ExecuteReader();
sqlDataReaderChangeTownNames.Close();

using SqlCommand sqlCommandGetTowns = new SqlCommand(queryGetTowns, connection);
sqlCommandGetTowns.Parameters.AddWithValue("@country", country);
using SqlDataReader sqlDataReaderGetTowns = sqlCommandGetTowns.ExecuteReader();
List<string> towns = new List<string>();
int i = 0;
while (sqlDataReaderGetTowns.Read() && sqlDataReaderGetTowns.HasRows) 
{
    towns.Add((string)sqlDataReaderGetTowns["Name"]);
    i++;
}

if (i != 0)
    Console.WriteLine($"{towns.Count} town names were affected.\n[{String.Join(", ", towns)}]");
else
    Console.WriteLine("No town names were affected.");