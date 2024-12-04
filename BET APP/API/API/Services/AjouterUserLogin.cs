using System;
using System.IO;
using API.Data;
using API;
using Npgsql;
using BCrypt.Net;

namespace API.Services
{
    public class AjouterUserLogin
    {
        public static string UserLogin(UserLogin userLogin)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(currentDirectory, "Services", "CommandsUserLogin.sql");

                // Vérification de l'existence du fichier
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

                    // Vérification de l'identifiant
                    string checkIdentifiantQuery = sqlCommands.Split(';')[0];
                    using (var command = new NpgsqlCommand(checkIdentifiantQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Identifiant", userLogin.identifiant);
                        int identifiantCount = Convert.ToInt32(command.ExecuteScalar());

                        if (identifiantCount > 0)
                        {
                            return "Erreur : L'identifiant existe déjà.";
                        }
                    }

                    // Vérification de l'adresse mail
                    string checkEmailQuery = sqlCommands.Split(';')[1];
                    using (var command = new NpgsqlCommand(checkEmailQuery, connection))
                    {
                        command.Parameters.AddWithValue("@AdresseMail", userLogin.adresse_mail);
                        int emailCount = Convert.ToInt32(command.ExecuteScalar());

                        if (emailCount > 0)
                        {
                            return "Erreur : L'adresse e-mail est déjà utilisée.";
                        }
                    }

                    // Hashage du mot de passe
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userLogin.mot_de_passe);

                    // Insertion dans la base de données
                    string insertQuery = sqlCommands.Split(';')[2];
                    using (var command = new NpgsqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Identifiant", userLogin.identifiant);
                        command.Parameters.AddWithValue("@AdresseMail", userLogin.adresse_mail);
                        command.Parameters.AddWithValue("@MotDePasse", hashedPassword);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Console.WriteLine($"Utilisateur {userLogin.identifiant} ajouté avec succès !");
                            return "Utilisateur ajouté avec succès !";
                        }
                        else
                        {
                            return "Erreur lors de l'ajout de l'utilisateur.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                return $"Erreur : {ex.Message}";
            }
        }
    }
}
