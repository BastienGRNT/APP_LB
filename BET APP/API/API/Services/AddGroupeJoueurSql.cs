using Npgsql;
using API.CS.CLASS;

namespace API.CS.BACK;

public class AddGroupeJoueurSql
{
    public static string AjouterGroupeJoueur(GroupeJoueur groupeJoueur)
    {
        try
        {
            using (var connection = SQL_Connection.ConnectSql())
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                string AjouterUnAmis =
                    @"INSERT INTO public.groupe_joueur (id_user, id_groupe) VALUES (@id_user, @id_groupe);";

                using (var commande = new NpgsqlCommand(AjouterUnAmis, connection))
                {
                    commande.Parameters.AddWithValue("@id_user", groupeJoueur.id_user);
                    commande.Parameters.AddWithValue("@id_groupe", groupeJoueur.id_groupe);

                    commande.ExecuteNonQuery();
                }
            }
            return "Joueur ajouté avec succes au groupe";
        }
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }
}