using API.CS.CLASS;
using Npgsql;

namespace API.CS.BACK;

public class AddGroupeSql
{
    public static string AjouterGroupe(Groupe groupe)
    {
        try
        {
            using (var connection = SQL_Connection.ConnectSql())
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                string AjouterGroupe =
                    @"INSERT INTO public.groupe (id_groupe, nom_groupe, id_createur) VALUES (@id_groupe, @nom_groupe, @id_createur);";

                using (var commande = new NpgsqlCommand(AjouterGroupe, connection))
                {
                    commande.Parameters.AddWithValue("@id_groupe", groupe.id_groupe);
                    commande.Parameters.AddWithValue("@nom_groupe", groupe.nom_groupe);
                    commande.Parameters.AddWithValue("@id_createur", groupe.id_createur);

                    commande.ExecuteNonQuery();
                }
            }
            return "Groupe creé avec succes";
        }
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }
}
