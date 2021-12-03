using Microsoft.EntityFrameworkCore;
using System;

namespace MathPlot.Api.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<MappingGauss> mappingGausses { get; set; }
        public DbSet<MappingLogistic> mappingLogistics { get; set; }
        public DbSet<MappingTwo> mappingTwos { get; set; }
        public DbSet<MappingPlank> MappingPlanks { get; set; }
        public DbSet<MappingSinus> MappingSinus { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
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
