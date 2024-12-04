using Microsoft.AspNetCore.Mvc;
using API;
using API.CS.BACK;
using API.CS.CLASS;
using API.CS.BACK;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API_LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult AjouterLogin([FromQuery] Login login)
        {
            if (login == null)
            {
                return BadRequest("Merci de renseigner quelque chose.");
            }
            
            string resultat = AddLoginSql.AjouterLogin(login);
            if (resultat == "Login Ajouter avec succes")
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

//T'en pense quoi ???

