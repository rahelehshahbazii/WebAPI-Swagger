using EshopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model is not valid");
            }
            if (login.UserName.ToLower() != "Raheleh" || login.Password.ToLower() != "123")
            {
                return Unauthorized();
            }
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurVerifySite"));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var tockenOption = new JwtSecurityToken(
                issuer: "http://localhost:53085",
                claims: new List<Claim>
                {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tockenOption);
            return Ok(new {token = tokenString});



        }

    }
}
