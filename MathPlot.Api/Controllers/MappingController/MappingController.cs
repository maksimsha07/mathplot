using MathPlot.Api.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Controllers.MappingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingController : ControllerBase 
    {
        ApplicationDbContext db;
        public MappingController(ApplicationDbContext context)
        {
            db = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        [HttpGet("{login}")]
        public async Task<List<List<string>>> Get(string login)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Login == login);

            var mappingPlank = await db.MappingPlanks.Where(x => x.user == user).Select(x => x.path).ToListAsync();
            var mappingGauss = await db.mappingGausses.Where(x => x.user == user).Select(x => x.path).ToListAsync();
            var mappingLogistic = await db.mappingLogistics.Where(x => x.user == user).Select(x => x.path).ToListAsync();
            var mappingTwo = await db.mappingTwos.Where(x => x.user == user).Select(x => x.path).ToListAsync();
            var mappingSinnus = await db.MappingSinus.Where(x => x.user == user).Select(x => x.path).ToListAsync();

            List<List<string>> charts = new List<List<string>>();
            charts.AddRange(new List<List<string>> { mappingPlank , mappingGauss , mappingLogistic, mappingTwo , mappingSinnus });
            return charts;
        }
    }
}
