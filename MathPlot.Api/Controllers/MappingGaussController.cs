﻿using MathPlot.Api.Entity;
using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingGaussController : ControllerBase
    {
        ApplicationDbContext db;
        public IConfiguration Configuration { get; }
        private string mainpath;

        public MappingGaussController(ApplicationDbContext context, IConfiguration configuration)
        {
            db = context;
            Configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<MappingGauss>> Post([FromForm] MappingFunctionsFiles mappingFunctions)
        {
            string login = mappingFunctions.login;
            IFormFile file = mappingFunctions.file;
            string mapping = "mappingGauss";
            mainpath = Configuration.GetSection("SaveImgPath").GetValue<string>("MainPath");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (mappingFunctions.login == null && mappingFunctions.login == "")
            {
                return Ok();
            }
            else
            {
                if (!Directory.Exists(mainpath + "\\" + mappingFunctions.login))
                {
                    Directory.CreateDirectory(mainpath + "\\" + mappingFunctions.login);
                }
                if (!Directory.Exists(mainpath + "\\" + mappingFunctions.login + "\\" + mapping))
                {
                    Directory.CreateDirectory(mainpath + "\\" + mappingFunctions.login + "\\" + mapping);
                }
                User user = await db.Users.FirstOrDefaultAsync(x => x.Login == login);
                var mp = await db.mappingGausses.Where(x => x.user == user).ToListAsync();
                int count = mp.Count();
                if (count > 10)
                {
                    string deletepath = mainpath + "\\" + mappingFunctions.login + "\\" + mapping + "\\" + mp[0].path;
                    if ((System.IO.File.Exists(deletepath)))
                    {
                        System.IO.File.Delete((deletepath));
                    }
                    db.mappingGausses.Remove(mp[0]);
                    await db.SaveChangesAsync();
                }
                Random rnd = new Random();
                int value = rnd.Next(0, 1000);
                using (var fileStream = new FileStream(mainpath + "\\" + login + "\\" + mapping + "\\" + value.ToString() + file.FileName, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                MappingGauss mappingGausss = new MappingGauss
                {
                    r = mappingFunctions.r,
                    bifur = mappingFunctions.bifur,
                    pokazlapuniva = mappingFunctions.pokazlapuniva,
                    path = value.ToString() + file.FileName,
                    user = await db.Users.FirstOrDefaultAsync(x => x.Login == user.Login)
                };
                db.mappingGausses.Add(mappingGausss);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
