using System;
using System.IO;
using API.Data;
using Npgsql;
using NpgsqlTypes;

namespace API.Services
{
    public class Service_Friendship
    {
        public string AddFriend(Data_Friendship dataFriendship)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(currentDirectory, "____FRIENDSHIP____", "__AddFriendship__", "Queries_AddFriendship", "CommandsAddFriendship.sql");

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

                    // Vérifier si une relation inversée existe déjà
                    string queryCheckInverse = sqlCommands.Split(';')[0];
                    using (var checkCommand = new NpgsqlCommand(queryCheckInverse, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@user1", dataFriendship.utilisateur_id);
                        checkCommand.Parameters.AddWithValue("@user2", dataFriendship.ami_id);

                        int inverseCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (inverseCount > 0)
                        {
                            // Mettre à jour le statut en "accepté"
                            string queryUpdate = sqlCommands.Split(';')[1];
                            using (var updateCommand = new NpgsqlCommand(queryUpdate, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@user1", dataFriendship.ami_id);
                                updateCommand.Parameters.AddWithValue("@user2", dataFriendship.utilisateur_id);

                                updateCommand.ExecuteNonQuery();
                                return "Demande d'amis accepté.";
                            }
                        }
                    }

                    // Insérer une nouvelle demande d'amitié
                    string queryInsert = sqlCommands.Split(';')[2];
                    using (var insertCommand = new NpgsqlCommand(queryInsert, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@user1", dataFriendship.utilisateur_id);
                        insertCommand.Parameters.AddWithValue("@user2", dataFriendship.ami_id);
                        insertCommand.Parameters.AddWithValue("@statut", "en_attente");

                        insertCommand.ExecuteNonQuery();
                    }
                }

                return "Ami ajouté avec succès.";
            }
            catch (PostgresException ex) when (ex.SqlState == "23505")
            {
                // Gérer les erreurs de contrainte unique
                return "Vous êtes déjà amis.";
            }
            catch (Exception ex)
            {
                // Gérer les autres exceptions
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                return $"Erreur : {ex.Message}";
            }
        }
    }
}
