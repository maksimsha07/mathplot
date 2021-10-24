using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        ApplicationDbContext db;
        public AuthController(ApplicationDbContext context)
        {
            db = context;

        }
        [HttpPost]
        public IActionResult Login(Login u)
        {
            var user = AuthenticateUser(u.login, u.password);
            if (user != null)
            {
                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var response = new
                {
                    access_token = encodedJwt,
                    login = user.Login
                };
                return Ok(response);
            }
            else return Unauthorized();
        }

        private User AuthenticateUser(string login,string password)
        {
            return db.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
        }
    }
}
