using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendshipController : ControllerBase
    {
        [HttpPost]
        public IActionResult AjouterAmi([FromBody] Friendship friendship)
        {
            if (friendship == null)
            {
                return BadRequest(new { success = false, error = "Les données de l'ami sont manquantes." });
            }

            var service = new FriendshipService();
            var result = service.AjouterAmi(friendship);

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