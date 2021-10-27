using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<MappingPlank>> Post(MappingPlank mappingplank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.MappingPlanks.Add(mappingplank);
            await db.SaveChangesAsync();
            return Ok(mappingplank);
        }
    }
}
