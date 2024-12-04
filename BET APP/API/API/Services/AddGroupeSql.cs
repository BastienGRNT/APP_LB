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

                string AjouterGroupe = ""

                using (var commande = new NpgsqlCommand(AjouterUnAmis, connection))
                {
                    commande.Parameters.AddWithValue("@id_user", amis.id_user);
                    commande.Parameters.AddWithValue("@id_user_amis", amis.id_user_amis);

                    commande.ExecuteNonQuery();
                }
            }
            return "Amis Ajouter avec succes";
        }
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }
}
