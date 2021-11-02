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
        public DbSet<MappingSinus> MappingSinus { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Page> Pages { get; set; }

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
            });
            builder.Entity<Page>().HasData(new Page
            {
                Id = 1,
                name = "OneDimensionalMappings"
            });
            builder.Entity<Page>().HasData(new Page
            {
                Id = 2,
                name = "BifurcationTheory"
            });
            builder.Entity<Page>().HasData(new Page
            {
                Id = 3,
                name = "LyapunovExponentsTheory"
            });
            builder.Entity<Page>().HasData(new Page
            {
                Id = 4,
                name = "TheoryLogistic"
            });
            builder.Entity<Page>().HasData(new Page
            {
                Id = 5,
                name = "TwoDimensionalMappings"
            });

        }
    }
}
