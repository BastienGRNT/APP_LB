using Npgsql;

namespace API;

public class SQL_Connection
{
    public static NpgsqlConnection ConnectSql()
    {
        string host = "51.75.78.44";
        string port = "5432";
        string database = "database";
        string username = "cacaboudin";
        string password = "parisapp";

        var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";

        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}