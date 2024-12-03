using Npgsql;

namespace API;

public class SQL_Table
{
    
    public static string LoginTable()
    {
        try
        {
            using (var conection = SQL_Connection.ConnectSql())
            {
                conection.Open();

                string creerLogin = @"CREATE TABLE IF NOT EXISTS Login
                                        (ID_User SERIAL,
                                        Pseudo VARCHAR(50),
                                        AdresseMail VARCHAR(50),
                                        PRIMARY KEY (ID_User));";

                using (var command = new NpgsqlCommand(creerLogin, conection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return "Table Login Créer avec succes";
        }
        
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }
    
}