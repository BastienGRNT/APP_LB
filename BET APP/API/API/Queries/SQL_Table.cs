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

                string creerLogin = @"CREATE TABLE IF NOT EXISTS login
                                        (ID_User SERIAL,
                                        Pseudo VARCHAR(50) UNIQUE NOT NULL,
                                        AdresseMail VARCHAR(50) UNIQUE NOT NULL,
                                        PRIMARY KEY (ID_User));";

                using (var command = new NpgsqlCommand(creerLogin, conection))
                {
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("OKKKKK");
            return "Table Login Créer avec succes";
        }
        
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }

    public static string AmisTable()
    {
        try
        {
            using (var conection = SQL_Connection.ConnectSql())
            {
                conection.Open();
                
                string CreerAmis = @"CREATE TABLE Amis(
                                       ID_User INT,
                                       ID_User_amis INT,
                                       PRIMARY KEY(ID_User, ID_User_amis),
                                       FOREIGN KEY(ID_User) REFERENCES login(ID_User),
                                       FOREIGN KEY(ID_User_amis) REFERENCES login(ID_User)
                                       );";
                
                using (var command = new NpgsqlCommand(CreerAmis, conection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return "Table amis créer avec succes";
        }
        catch (Exception ex)
        {
            return $"Erreur: {ex.Message}";
        }
    }

    public static string GroupeTable()
    {
        try
        {
            using (var conection = SQL_Connection.ConnectSql())
            {
                conection.Open();
                
                string CreerGroupe = @"CREATE TABLE Groupe(
                                       id_groupe INT,
                                       nom_groupe VARCHAR(50) NOT NULL,
                                       id_createur INT NOT NULL,
                                       PRIMARY KEY(id_groupe),
                                       FOREIGN KEY(id_createur) REFERENCES login(ID_User) 
                                       );";

                using (var command = new NpgsqlCommand(CreerGroupe, conection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return ("Table groupe créer avec succes");
        }
        catch (Exception e)
        {
            return $"Erreur: {e.Message}";
        }
    }
}