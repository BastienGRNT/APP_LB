using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserLoginController : ControllerBase
{
    [HttpPost]
    public IActionResult AjouterUser([FromBody] UserLogin userLogin)
    {
        if (userLogin == null)
        {
            return BadRequest("Les données utilisateur sont manquantes.");
        }

        var result = AjouterUserLogin.UserLogin(userLogin);

        if (result.StartsWith("Utilisateur ajouté avec succès"))
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
}