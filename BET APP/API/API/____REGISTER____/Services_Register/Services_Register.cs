using System;
using System.IO;
using API.Data;
using API;
using Npgsql;
using BCrypt.Net;

namespace API.Services
{
    public class Services_Register
    {
        public static string UserRegister(Data_Register dataRegister)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(currentDirectory, "Services", "CommandsUserLogin.sql");

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

                    string queryCheckRegisterID = sqlCommands.Split(';')[0];
                    using (var command = new NpgsqlCommand(queryCheckRegisterID, connection))
                    {
                        command.Parameters.AddWithValue("@Identifiant", dataRegister.user_id);
                        int identifiantCount = Convert.ToInt32(command.ExecuteScalar());

                        if (identifiantCount > 0)
                        {
                            return "Erreur : L'identifiant existe déjà.";
                        }
                    }

                    string QueryCheckRegisterEmail = sqlCommands.Split(';')[1];
                    using (var command = new NpgsqlCommand(QueryCheckRegisterEmail, connection))
                    {
                        command.Parameters.AddWithValue("@AdresseMail", dataRegister.user_mail);
                        int emailCount = Convert.ToInt32(command.ExecuteScalar());

                        if (emailCount > 0)
                        {
                            return "Erreur : L'adresse e-mail est déjà utilisée.";
                        }
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dataRegister.user_password);

                    string QueryPassword = sqlCommands.Split(';')[2];
                    using (var command = new NpgsqlCommand(QueryPassword, connection))
                    {
                        command.Parameters.AddWithValue("@Identifiant", dataRegister.user_id);
                        command.Parameters.AddWithValue("@AdresseMail", dataRegister.user_mail);
                        command.Parameters.AddWithValue("@MotDePasse", hashedPassword);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Console.WriteLine($"Utilisateur {dataRegister.user_id} ajouté avec succès !");
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
