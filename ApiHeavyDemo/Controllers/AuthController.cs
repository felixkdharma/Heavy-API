using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiHeavyDemo.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login()
    {
        // ⚠️ Dummy login dulu
        var claims = new[]
        {
            new Claim("UserId", "11111111-1111-1111-1111-111111111111"),
            new Claim("CompanyId", "22222222-2222-2222-2222-222222222222"),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("THIS_IS_SUPER_SECRET_KEY_CHANGE_LATER"));

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    [Authorize]
    [HttpGet("whoami")]
    public IActionResult WhoAmI()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value });
        return Ok(claims);
    }

    [Authorize]
    [HttpGet("debug-token")]
    public IActionResult DebugToken()
    {
        var claims = User.Claims
            .Select(c => new { c.Type, c.Value });

        return Ok(claims);
    }

}
