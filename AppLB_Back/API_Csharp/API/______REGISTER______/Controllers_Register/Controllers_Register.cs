using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserLoginController : ControllerBase
{
    [HttpPost]
    public IActionResult ApiResgister([FromBody] Data_Register dataRegister)
    {
        if (dataRegister == null)
        {
            return BadRequest(new { success = false, error = "Les données utilisateur sont manquantes." });
        }

        var result = Services_Register.UserRegister(dataRegister);

        if (result.StartsWith("Utilisateur ajouté avec succès"))
        {
            return Ok(new { success = true, message = result });
        }
        else
        {
            return BadRequest(new { success = false, error = result });
        }
    }
}