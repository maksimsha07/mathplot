using IronPython.Hosting;
using MathPlot.Api.Model;
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
        public async Task<ActionResult<MappingPlank>> Post(MappingFunctions mappingFunctions)
        {
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

                User user = await db.Users.FirstOrDefaultAsync(x => x.Login == mappingFunctions.login);
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "C:\\Users\\Admin\\source\\repos\\MathPlot\\MathPlot\\MathPlot.Api\\PythonScripts\\OneDimensionalMappings\\mappingSinus.py";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                    }
                }
                /*
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
                */
                return Ok();
            }
        }
    }
}
