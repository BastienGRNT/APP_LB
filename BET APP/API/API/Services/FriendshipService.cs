using System;
using API.Data;

namespace API.Services
{
    public class FriendshipService
    {
        public string AjouterAmi(Friendship friendship)
        {
            // Validation : éviter qu'un utilisateur s'ajoute lui-même
            if (friendship.utilisateur_id == friendship.ami_id)
            {
                return "Vous ne pouvez pas vous ajouter comme ami.";
            }

            // Simulez l'ajout à la base de données
            // (Remplacez cette logique par une vraie interaction avec la DB)
            return "Ami ajouté avec succès.";
        }
    }
}

namespace API.Data
{
    public class Friendship
    {
        public string utilisateur_id { get; set; }
        public string ami_id { get; set; }
        public DateTime date_ajout { get; set; }
    }
}
Tu l'as déj

c parce que jai pas les droit que ca marche pas
att je vais faire dans le mien pour voir si ca marche

OK

je push
