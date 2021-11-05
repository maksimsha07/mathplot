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
    public class MappingPlankController : ControllerBase
    {
        ApplicationDbContext db;
        public MappingPlankController(ApplicationDbContext context)
        {
            db = context;

        }

        [HttpPost]
        public async Task<ActionResult<MappingPlank>> Post(double r,bool lestlameri, bool bifur, bool pokazlapuniva,string login)
        {
            string mainpath = "C:\\Users\\Admin\\source\\repos\\MathPlot\\MathPlot\\mathplot.ui\\Charts";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (login == null)
            {
                return Ok();
            }
            else 
            {
                if (!Directory.Exists(mainpath+"\\"+login))
                {
                    Directory.CreateDirectory(mainpath + "\\"+login);
                }
                if (!Directory.Exists(mainpath +"\\"+ login +"\\"+ "mappingplank"))
                {
                    Directory.CreateDirectory(mainpath + "\\" + login + "\\" + "mappingplank");
                }
                MappingPlank mappingPlank =  new MappingPlank
                {
                    r = r,
                    lestlameri = lestlameri,
                    bifur = bifur,
                    pokazlapuniva = pokazlapuniva,
                    path = (mainpath + "\\" + login + "\\" + "mappingplank"),
                    user = await db.Users.FirstOrDefaultAsync(x => x.Login == login)
                };
                db.MappingPlanks.Add(mappingPlank);
                await db.SaveChangesAsync();
                return Ok(mappingPlank);
            }
        }
    }
}
