using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            var user = _userService.ValidateUser(model.UserName, model.Password);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),

                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-sifrelenecek-cumle"));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                      issuer: "aktifbank.api",
                      audience: "aktifbank.mobil",
                      claims: claims,
                      notBefore: DateTime.Now,
                      expires: DateTime.Now.AddHours(6),
                      signingCredentials: credential
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });



            }
            return BadRequest(new { message = "Hatalı kullanıcı adı veya şifre" });
        }
    }
}
