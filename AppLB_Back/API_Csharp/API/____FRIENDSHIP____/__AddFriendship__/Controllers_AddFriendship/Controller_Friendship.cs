using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Controller_Friendship : ControllerBase
    {
        [HttpPost]
        public IActionResult AddFriend([FromBody] Data_Friendship dataFriendship)
        {
            if (dataFriendship == null || dataFriendship.utilisateur_id == dataFriendship.ami_id)
            {
                return BadRequest(new { success = false, error = "Les données de l'ami sont manquantes." });
            }

            var service = new Service_Friendship();
            var result = service.AddFriend(dataFriendship);

            if (result == "Ami ajouté avec succès." || result == "Demande d'amis accepté." || result == "Vous êtes déjà amis.")
            {
                return Ok(new { success = true, message = result });
            }
            else
            {
                return BadRequest(new { success = false, error = result });
            }
        }
    }
}