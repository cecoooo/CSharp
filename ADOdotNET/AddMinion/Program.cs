using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;


string connectionString = "Server=CECO\\SQLEXPRESS;Database=MinionsDB;User Id=sa;Password=1234;TrustServerCertificate=True;";

using SqlConnection sqlConnection = new SqlConnection(connectionString);
sqlConnection.Open();

string[] inputMinion = Console.ReadLine().Split(" ");
string[] inputVillian = Console.ReadLine().Split(" ");

if (!IsThereTownId(sqlConnection, inputMinion)) 
    addTown(sqlConnection, inputMinion[3]);

int townId = getTownId(sqlConnection, inputMinion[3]);

insertIntoMinions(sqlConnection, inputMinion, townId);

if (!isThereVallainId(sqlConnection, inputVillian[1])) 
    addVillain(sqlConnection, inputVillian[1]);

makeMinionServantToVallain(sqlConnection,
    getMinionId(sqlConnection, inputMinion, townId), 
    getVillainId(sqlConnection, inputVillian[1]), 
    inputMinion[1], 
    inputVillian[1]);



bool IsThereTownId(SqlConnection sqlConnection, string[] inputMinion) 
{
    string checkForTownQuery = "SELECT COUNT(Id) FROM Towns \r\nWHERE [Name] = @town;";
    using SqlCommand sqlCommandGetTownId = new SqlCommand(checkForTownQuery, sqlConnection);
    sqlCommandGetTownId.Parameters.AddWithValue("@town", inputMinion[3]);
    using SqlDataReader sqlDataReaderTownId = sqlCommandGetTownId.ExecuteReader();
    sqlDataReaderTownId.Read();
    if ((int)sqlDataReaderTownId[0] == 0)
    {
        sqlDataReaderTownId.Close();
        return false;
    }
    else
    {
        sqlDataReaderTownId.Close();
        return true;
    }
}

int getTownId(SqlConnection sqlConnection, string town) 
{
    string checkForTownQuery = "SELECT Id FROM Towns \r\nWHERE [Name] = @town;";
    using SqlCommand sqlCommandGetTownId = new SqlCommand(checkForTownQuery, sqlConnection);
    sqlCommandGetTownId.Parameters.AddWithValue("@town", town);
    using SqlDataReader sqlDataReaderTownId = sqlCommandGetTownId.ExecuteReader();
    sqlDataReaderTownId.Read();
    int res = (int)sqlDataReaderTownId[0];
    sqlDataReaderTownId.Close();
    return res;
}

void addTown(SqlConnection sqlConnection, string townName) 
{
    string addTownQuery = "INSERT INTO Towns([Name])\r\nVALUES\r\n(@town)";
    using SqlCommand sqlCommandAddTown = new SqlCommand(addTownQuery, sqlConnection);
    sqlCommandAddTown.Parameters.AddWithValue("@town", townName);
    using SqlDataReader sqlDataReaderAddTown = sqlCommandAddTown.ExecuteReader();
    Console.WriteLine($"Town {townName} was added to the database.");
    sqlDataReaderAddTown.Close();
}

void insertIntoMinions(SqlConnection sqlConnection, string[] inputMinion, int townId) 
{
    string insertMinionQuery = "INSERT INTO Minions ([Name], [Age], [TownId])\r\nVALUES\r\n(@name, @age, @town);";
    using SqlCommand sqlCommandInsertIntoMinions = new SqlCommand(insertMinionQuery, sqlConnection);
    sqlCommandInsertIntoMinions.Parameters.AddWithValue("@name", inputMinion[1]);
    sqlCommandInsertIntoMinions.Parameters.AddWithValue("@age", int.Parse(inputMinion[2]));
    sqlCommandInsertIntoMinions.Parameters.AddWithValue("@town", townId);
    using SqlDataReader sqlDataReaderInsertIntoMinions = sqlCommandInsertIntoMinions.ExecuteReader();
    sqlDataReaderInsertIntoMinions.Close();
}

bool isThereVallainId(SqlConnection sqlConnection, string name) 
{
    string queryGetVillainId = "SELECT COUNT(id) \r\nFROM Villains \r\nWHERE [Name] = @name;";
    using SqlCommand sqlCommandGetVillainId = new SqlCommand(queryGetVillainId, sqlConnection);
    sqlCommandGetVillainId.Parameters.AddWithValue("@name", name);
    using SqlDataReader sqlDataReaderVallainId = sqlCommandGetVillainId.ExecuteReader();
    sqlDataReaderVallainId.Read();
    if ((int)sqlDataReaderVallainId[0] == 0)
    {
        sqlDataReaderVallainId.Close();
        return false;
    }
    else
    {
        sqlDataReaderVallainId.Close();
        return true;
    }
}

int getVillainId(SqlConnection sqlConnection, string name) 
{
    string queryGetVillainId = "SELECT id \r\nFROM Villains \r\nWHERE [Name] = @name;";
    using SqlCommand sqlCommandGetVillainId = new SqlCommand(queryGetVillainId, sqlConnection);
    sqlCommandGetVillainId.Parameters.AddWithValue("@name", name);
    using SqlDataReader sqlDataReaderVallainId = sqlCommandGetVillainId.ExecuteReader();
    sqlDataReaderVallainId.Read();
    int res = (int)sqlDataReaderVallainId[0];
    sqlDataReaderVallainId.Close();
    return res;
}

int getMinionId(SqlConnection sqlConnection, string[] inputMinion, int townId) 
{
    string queryGetMinionId = "SELECT Id FROM Minions\r\nWHERE [Name] = @name AND Age = @age AND TownId = @townId;";
    using SqlCommand sqlCommandGetMinionId = new SqlCommand(queryGetMinionId, sqlConnection);
    sqlCommandGetMinionId.Parameters.AddWithValue("@name", inputMinion[1]);
    sqlCommandGetMinionId.Parameters.AddWithValue("@age", int.Parse(inputMinion[2]));
    sqlCommandGetMinionId.Parameters.AddWithValue("@townId", townId);
    using SqlDataReader sqlDataReaderMinionId = sqlCommandGetMinionId.ExecuteReader();
    sqlDataReaderMinionId.Read();
    int res = (int)sqlDataReaderMinionId[0];
    sqlDataReaderMinionId.Close();
    return res;
}

void addVillain(SqlConnection sqlConnection, string name) 
{
    string queryAddVillain = "INSERT INTO Villains([Name], EvilnessFactorId)\r\nVALUES\r\n(@name, 4)";
    using SqlCommand sqlCommandInsertVallain = new SqlCommand(queryAddVillain, sqlConnection);
    sqlCommandInsertVallain.Parameters.AddWithValue("@name", name);
    using SqlDataReader sqlDataReaderVallain = sqlCommandInsertVallain.ExecuteReader();
    sqlDataReaderVallain.Close();
    Console.WriteLine($"Villain {name} was added to the database.");
}

void makeMinionServantToVallain(SqlConnection sqlConnection, int mId, int vId, string mName, string vName) 
{
    string queryInsertIntoMinionsVallains = "INSERT INTO MinionsVillains(MinionId, VillainId)\r\nVALUES\r\n(@mId, @vId);";
    using SqlCommand sqlCommandInsertIntoMinionsVallains = new SqlCommand(queryInsertIntoMinionsVallains, sqlConnection);
    sqlCommandInsertIntoMinionsVallains.Parameters.AddWithValue("@mId", mId);
    sqlCommandInsertIntoMinionsVallains.Parameters.AddWithValue("@vId", vId);
    using SqlDataReader sqlDataReaderInsertIntoMinionsVallains = sqlCommandInsertIntoMinionsVallains.ExecuteReader();
    sqlDataReaderInsertIntoMinionsVallains.Close();
    Console.WriteLine($"Successfully added {mName} to be minion of {vName}.");
}