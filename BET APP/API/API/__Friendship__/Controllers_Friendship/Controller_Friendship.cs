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
        public IActionResult AjouterAmi([FromBody] Data_Friendship dataFriendship)
        {
            if (dataFriendship == null)
            {
                return BadRequest(new { success = false, error = "Les données de l'ami sont manquantes." });
            }

            var service = new Friendship_Service();
            var result = service.AjouterAmi(dataFriendship);

            if (result == "Ami ajouté avec succès.")
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