using Npgsql;
using API;
using API.CS.CLASS;

namespace API.CS.BACK;

public class AddLoginSql
{
    public static string AjouterLogin(Login login)
    {
        try
        {
            using (var connection = SQL_Connection.ConnectSql())
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open(); 
                }
                

                string AjouterUnLogin = "INSERT INTO public.login (Pseudo, AdresseMail) VALUES (@Pseudo, @AdresseMail);";

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
