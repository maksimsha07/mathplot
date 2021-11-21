using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using MathPlot.Api.Entity;

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
        public async Task<ActionResult<List<string>>> Login(Login u)
        {
            var user = await db.Users.SingleOrDefaultAsync(x => x.Login == u.login && x.Password == u.password);
            if(user == null)
            {
                ModelState.AddModelError("Pass", "Неверный логин или пароль");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
                login = user.Login,
                imagePath = user.ImagePath
            };
            return Ok(response);
            
        }
    }
}
