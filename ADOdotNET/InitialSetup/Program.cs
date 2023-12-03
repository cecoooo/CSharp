using Microsoft.Data.SqlClient;

string connectionString = @"--Set_Your_Connection_String--";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string query = "SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > @salaryParam";

using SqlCommand command = new SqlCommand(query, connection);
command.Parameters.AddWithValue("@salaryParam", 50000);

SqlDataReader sqlDataReader = command.ExecuteReader();

while (sqlDataReader.Read()) 
{
    string firstName = sqlDataReader[0].ToString();
    string lastName = sqlDataReader[1].ToString();
    decimal salary = (decimal)sqlDataReader[2];

    Console.WriteLine($"{firstName} {lastName}, {salary}");

}