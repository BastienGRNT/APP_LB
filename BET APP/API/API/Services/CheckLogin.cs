using BCrypt.Net;
using Npgsql;
using API.Data;

namespace API.Services;

public class CheckLoginClass
{
    public string CheckLogin(CheckLogin checkLogin)
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
                command.Parameters.AddWithValue("@Identifiant", checkLogin.identifiant);

                // Exécuter la requête
                string motDePasseHaché = command.ExecuteScalar() as string;

                if (string.IsNullOrEmpty(motDePasseHaché))
                {
                    return "Erreur : L'identifiant n'existe pas !";
                }

                // Comparer le mot de passe haché
                bool motDePasseValide = BCrypt.Net.BCrypt.Verify(checkLogin.mot_de_passe, motDePasseHaché);
                if (motDePasseValide)
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