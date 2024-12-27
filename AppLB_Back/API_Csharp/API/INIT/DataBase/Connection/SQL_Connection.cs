using Npgsql;
using DotNetEnv;

namespace API
{
    public class SQL_Connection
    {
        public static NpgsqlConnection ConnectSql()
        {
            string envPath = Path.Combine(Directory.GetCurrentDirectory(), "INIT", "DATABASE", "CONNECTION", "database.env");
            Env.Load(envPath);

            string host = "51.75.78.44"; //Env.GetString("DB_HOST");
            string port = "5432"; //Env.GetString("DB_PORT");
            string database = "database"; //Env.GetString("DB_NAME");
            string username = "lbapidb"; //Env.GetString("DB_USER");
            string password = "applicationlb"; //Env.GetString("DB_PASSWORD");

            var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}