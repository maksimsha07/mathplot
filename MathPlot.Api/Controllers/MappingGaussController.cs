using MathPlot.Api.Entity;
using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public MappingGaussController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<ActionResult<MappingGauss>> Post([FromForm] MappingFunctionsFiles mappingFunctions)
        {
            string login = mappingFunctions.login;
            IFormFile file = mappingFunctions.file;
            string mapping = "mappingGauss";
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
                User user = await db.Users.FirstOrDefaultAsync(x => x.Login == mappingFunctions.login);
                if (user.ImagePath != null)
                {
                    foreach (string folder in Directory.GetDirectories(mainpath + "\\" + login + "\\" + mapping))
                    {
                        Directory.Delete(folder, true);
                    }
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
