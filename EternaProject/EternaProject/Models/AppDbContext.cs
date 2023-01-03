using EternaProject.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EternaProject.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioImage> PortfolioImages { get; set; }

        //AboutPage-------------------------------------
        public DbSet<Counts> Counts { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        //TeamPage--------------------------------------
        public DbSet<Team> Teams { get; set; }
    }
}
