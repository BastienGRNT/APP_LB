using Npgsql;

namespace API.CS.BACK;
using API.CS.CLASS;

public class AddAmisSql
{
    public static string AjouterAmis(Amis amis)
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
                    @"INSERT INTO public.amis (id_user, id_user_amis) VALUES (@id_user, @id_user_amis);";

                using (var commande = new NpgsqlCommand(AjouterUnAmis, connection))
                {
                    commande.Parameters.AddWithValue("@id_user", amis.id_user);
                    commande.Parameters.AddWithValue("@id_user_amis", amis.id_user_amis);

                    commande.ExecuteNonQuery();
                }
            }
            return "Amis ajouté avec succes";
        }
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }
}