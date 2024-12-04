using Microsoft.AspNetCore.Mvc;
using API;
using API.CS.BACK;
using API.CS.CLASS;
using API.CS.BACK;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API_GroupeJoueurController : ControllerBase
    {
        [HttpGet]
        public IActionResult  GroupeJoueur([FromQuery] GroupeJoueur groupejoueur)
        {
            if (groupejoueur == null)
            {
                return BadRequest("Merci de renseigner quelque chose.");
            }
            
            string resultat = AddGroupeJoueurSql.AjouterGroupeJoueur(groupejoueur);
            if (resultat == "Joueur ajouté avec succès au groupe")
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