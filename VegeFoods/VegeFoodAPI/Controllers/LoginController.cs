using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using VegeFoodAPI.DTO;
using VegeFoodAPI.Models;

namespace VegeFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly Appsetting _appsetting;

        public LoginController(IUserRepository user, IOptionsMonitor<Appsetting> optionsMonitor)
        {
            _user = user;
            _appsetting = optionsMonitor.CurrentValue;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Validate(LoginDTO user)
        {
            var userLogin = _user.Login(user.UserName, user.Password);
            if(userLogin == null) 
            {
                return Ok("Invalid Credentials");
            }
            // cấp token
            return  Ok(GenerateToken(userLogin));
        }
        [AllowAnonymous]
        [HttpPost("Registor")]
        public IActionResult Registor(RegistorDTO registor)
        {
            try
            {
                User user = new User();
                user.UserName = registor.username;
                user.Password = registor.password;
                user.Email = registor.email;
                user.Phone = registor.phone;
                user.FullName = registor.fullName;
                user.role = "Customer";
                return Ok(_user.Registor(user));
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
           
        }
        private string GenerateToken(User userLogin)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appsetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userLogin.FullName),
                    new Claim(ClaimTypes.Email, userLogin.Email),
                    new Claim("Phone", userLogin.Phone.ToString()),
                    new Claim("UserName", userLogin.UserName),
                    new Claim("Role", userLogin.role),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
