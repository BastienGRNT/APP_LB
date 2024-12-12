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