using IronPython.Hosting;
using MathPlot.Api.Model;
using MathPlot.Api.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingPlankController : ControllerBase
    {
        ApplicationDbContext db;
        public MappingPlankController(ApplicationDbContext context)
        {
            db = context;

        }

        [HttpPost]
        public async Task<ActionResult<MappingPlank>> Post([FromForm] MappingFunctionsFiles mappingFunctions)
        {
            string login = mappingFunctions.login;
            IFormFile file = mappingFunctions.file;
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
                if (!Directory.Exists(mainpath+"\\"+ mappingFunctions.login))
                {
                    Directory.CreateDirectory(mainpath + "\\"+ mappingFunctions.login);
                }
                if (!Directory.Exists(mainpath +"\\"+ mappingFunctions.login + "\\"+ "mappingplank"))
                {
                    Directory.CreateDirectory(mainpath + "\\" + mappingFunctions.login + "\\" + "mappingplank");
                }
                User user = await db.Users.FirstOrDefaultAsync(x => x.Login == login);
                var mp = await db.MappingPlanks.Where(x => x.user == user).ToListAsync();
                int count = mp.Count();
                if (count >10)
                {
                    string deletepath = mainpath + "\\" + mappingFunctions.login + "\\" + "mappingplank" + "\\" + mp[0].path;
                    if ((System.IO.File.Exists(deletepath)))
                    {
                        System.IO.File.Delete((deletepath));
                    }
                    db.MappingPlanks.Remove(mp[0]);
                    await db.SaveChangesAsync();
                }
                Random rnd = new Random();
                int value = rnd.Next(0, 1000);
                using (var fileStream = new FileStream(mainpath + "\\" + login + "\\"  + "mappingplank"+ "\\" + value.ToString()+ file.FileName, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                MappingPlank mappingPlank =  new MappingPlank
                {
                    r = mappingFunctions.r,
                    bifur = mappingFunctions.bifur,
                    pokazlapuniva = mappingFunctions.pokazlapuniva,
                    path = value.ToString() + file.FileName,
                    user = await db.Users.FirstOrDefaultAsync(x => x.Login == login)
                };
                db.MappingPlanks.Add(mappingPlank);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
