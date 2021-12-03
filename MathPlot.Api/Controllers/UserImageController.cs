using MathPlot.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MathPlot.Api.Entity;
using Microsoft.Extensions.Configuration;

namespace MathPlot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImageController : ControllerBase
    {
        ApplicationDbContext db;
        public IConfiguration Configuration { get; }
        private string mainpath;
        public UserImageController(ApplicationDbContext context, IConfiguration configuration)
        {
            db = context;
            Configuration = configuration;

        }
        [HttpPut]
        public async Task<ActionResult<User>> Put([FromForm]UserImage info)
        {
            string login = info.login;
            IFormFile file = info.file;
            mainpath = Configuration.GetSection("SaveImgPath").GetValue<string>("MainUserPath");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = db.Users.FirstOrDefault(x => x.Login == login);
            if (!Directory.Exists(mainpath + "\\" +login))
            {
                Directory.CreateDirectory(mainpath + "\\" + login); 
            }
            if(user.ImagePath != null)
            {
                foreach (string folder in Directory.GetDirectories(mainpath + "\\" + login))
                {
                    Directory.Delete(folder, true);
                }   
            }
            using (var fileStream = new FileStream(mainpath + "\\" + login + "\\" + file.FileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            user.ImagePath = (file.FileName);
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
