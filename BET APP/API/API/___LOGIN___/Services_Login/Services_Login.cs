using BCrypt.Net;
using Npgsql;
using API.Data;

namespace API.Services;

public class CheckLoginClass
{
    public string UserLogin(Data_Login dataLogin)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, "Services", "CommandeCheckLogin.sql");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Le fichier SQL n'a pas été trouvé : {filePath}");
        }
        
        string sqlCommands = File.ReadAllText(filePath);
        
        using (var connection = SQL_Connection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            string query = sqlCommands.Split(';')[0];
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Identifiant", dataLogin.user_id);

                string CheckHashedPassword = command.ExecuteScalar() as string;

                if (string.IsNullOrEmpty(CheckHashedPassword))
                {
                    return "Erreur : L'identifiant n'existe pas !";
                }

                bool CorrectPassword = BCrypt.Net.BCrypt.Verify(dataLogin.user_password, CheckHashedPassword);
                if (CorrectPassword)
                {
                    return "Mot de passe correct !";
                }
                else
                {
                    return "Mot de passe incorrect !";
                }
            }
        }
    }
}