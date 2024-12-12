namespace API.Data
{
    public class Friendship
    {
        public string utilisateur_id { get; set; } // ID de l'utilisateur
        public string ami_id { get; set; }         // ID de l'ami
        public DateTime date_ajout { get; set; }   // Date d'ajout
    }
}