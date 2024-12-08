using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckLoginUser : ControllerBase
{
    [HttpPost]
    public IActionResult CheckLogin([FromBody] CheckLogin checkLogin)
    {
        if (checkLogin == null)
        {
            return BadRequest(new { success = false, error = "Les données sont manquantes." });
        }

        var checkLoginService = new CheckLoginClass();
        var result = checkLoginService.CheckLogin(checkLogin);

        if (result.StartsWith("Mot de passe correct !"))
        {
            return Ok(new { success = true, message = result });
        }
        else
        {
            return BadRequest(new { success = false, error = result });
        }
    }
}