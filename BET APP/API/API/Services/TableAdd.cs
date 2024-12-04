using Npgsql;
using API.CS.CLASS;

namespace API.CS.BACK;

public class TableAdd
{
    public static string AjouterLogin(Login login)
    {
        try
        {
            using (var connection = SQL_Connection.ConnectSql())
            {
                connection.Open();

                string AjouterUnLogin = "INSERT INTO login (Pseudo, AdresseMail) VALUES (@Pseudo, @AdresseMail);";

                using (var command = new NpgsqlCommand(AjouterUnLogin, connection))
                {
                    command.Parameters.AddWithValue("@Pseudo", login.Pseudo);
                    command.Parameters.AddWithValue("@AdresseMail", login.AdresseMail);

                    command.ExecuteNonQuery();
                }
            }
            return "Login Ajouter avec succes";
        }
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }
}
