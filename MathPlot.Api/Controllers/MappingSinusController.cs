using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathPlot.Api.Entity;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace MathPlot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingSinusController : ControllerBase
    {
        ApplicationDbContext db;
        public MappingSinusController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<ActionResult<MappingSinus>> Post([FromForm] MappingFunctionsFiles mappingFunctions)
        {
            string login = mappingFunctions.login;
            IFormFile file = mappingFunctions.file;
            string mapping = "mappingSunis";
            string mainpath = "C:\\Users\\Admin\\source\\repos\\MathPlot\\MathPlot\\mathplot.ui\\Charts";
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
                var mp = await db.MappingSinus.Where(x => x.user == user).ToListAsync();
                int count = mp.Count();
                if (count > 10)
                {
                    string deletepath = mainpath + "\\" + mappingFunctions.login + "\\" + mapping + "\\" + mp[0].path;
                    if ((System.IO.File.Exists(deletepath)))
                    {
                        System.IO.File.Delete((deletepath));
                    }
                    db.MappingSinus.Remove(mp[0]);
                    await db.SaveChangesAsync();
                }
                Random rnd = new Random();
                int value = rnd.Next(0, 1000);
                using (var fileStream = new FileStream(mainpath + "\\" + login + "\\" + mapping + "\\" + value.ToString() + file.FileName, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                MappingSinus mappingSinus = new MappingSinus
                {
                    r = mappingFunctions.r,
                    bifur = mappingFunctions.bifur,
                    pokazlapuniva = mappingFunctions.pokazlapuniva,
                    path = value.ToString() + file.FileName,
                    user = await db.Users.FirstOrDefaultAsync(x => x.Login == user.Login)
                };
                db.MappingSinus.Add(mappingSinus);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
