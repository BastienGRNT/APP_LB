using Microsoft.AspNetCore.Mvc;
using API;
using API.CS.BACK;
using API.CS.CLASS;
using API.CS.BACK;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API_GroupeController : ControllerBase
    {
        [HttpGet]
        public IActionResult AjouterGroupe([FromQuery]Groupe groupe)
        {
            if (groupe == null)
            {
                return BadRequest("Merci de renseigner quelque chose.");
            }
            
            string resultat = AddGroupeSql.AjouterGroupe(groupe);
            if (resultat == "Groupe créé avec succes")
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