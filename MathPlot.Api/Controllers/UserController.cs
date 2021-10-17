﻿using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
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
                return BadRequest();
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
            return Ok(user);
        }



    }
}
