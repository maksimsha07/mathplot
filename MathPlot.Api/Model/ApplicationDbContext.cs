using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<MappingPlank> MappingPlanks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Максим",
                LastName = "Чешихин",
                Login = "Maksim",
                Genre = true,
                Email = "deevzmak1234@mail.ru",
                Phone = 89094352590,
                Password = "qwertyuiop123"
            }
                ); ;

        }
    }
}
