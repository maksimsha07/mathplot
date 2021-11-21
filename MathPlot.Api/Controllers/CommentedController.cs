using MathPlot.Api.Model;
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
    public class CommentedController : ControllerBase
    {
        ApplicationDbContext db;
        public CommentedController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet("{name}")]
        public async Task<List<Comments>> Get(string name)
        {
            var commenst = await db.Comments.Where(p => p.page.name == name).Select(p => new Comments
            {
                login = p.user.Login,
                imagePath = p.user.ImagePath,
                comment = p.commented
            }).ToListAsync();
            if (commenst == null)
            {
                return null;
            }
            return commenst;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Post(addComment AC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User userl = await db.Users.FirstOrDefaultAsync(x => x.Login == AC.userName);
            Page page1 = await db.Pages.FirstOrDefaultAsync(x => x.name == AC.pageName);
            Comment comment = new Comment { user = userl, page = page1, commented = AC.commentText};
                db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return Ok(AC);
        }
    }
}
