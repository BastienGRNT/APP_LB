/*
using Npgsql;
using API.CS.CLASS;

namespace API.CS.BACK;

public class TableAdd
{
    public static string AjouterLogin(Login login)
    {
        using (var connection = SQL_Connection.ConnectSql())
        {
            connection.Open();
            SQL_Table.LoginTable();
            
            
            string AjouterUnLogin = "INSERT INTO Login (Pseudo, AdresseMail) VALUES (@Pseudo, @AdresseMail)";

            using (var command = NpgsqlCommand(AjouterUnLogin, connection))
            {
                command.Parameters.AddWithValue("@Pseudo", Login.Pseudo);
                command.Parameters.AddWithValue("@AdresseMail", Login.AdresseMail);
            }
        }
    }
} */