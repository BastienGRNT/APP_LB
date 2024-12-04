using Microsoft.AspNetCore.Mvc;
using API;
using API.CS.BACK;
using API.CS.CLASS;
using API.CS.BACK;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API_AmisController : ControllerBase
    {
        [HttpGet]
        public IActionResult AjouterAmis([FromQuery] Amis amis)
        {
            if (amis == null)
            {
                return BadRequest("Merci de renseigner quelque chose.");
            }
            
            string resultat = AddAmisSql.AjouterAmis(amis);
            if (resultat == "Amis Ajouter avec succes")
            {
                return Ok(resultat);
            }
            else
            {
                return BadRequest(resultat);
            }
        }
    }
}

