using MathPlot.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathPlot.Api.Entity;

namespace MathPlot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ApplicationDbContext db;
        public UserController(ApplicationDbContext context)
        {
            db = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        [HttpGet("{login}")]
        public async Task<ActionResult<User>> Get(string login)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            
            User userl = await db.Users.FirstOrDefaultAsync(x => x.Login == user.Login);
            if (userl != null)
            {
                ModelState.AddModelError("Login", "Такой логин уже используется");
            }
            if (user.Login == "admin")
            {
                ModelState.AddModelError("Login", "Недопустимый логин - admin");
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
                return Ok(user);
        }
    }
}
