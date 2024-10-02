using homegains.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace homegains.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DayPlan> dayplans { get; set; }
        public DbSet<FigureMain> FigureMains { get; set; }
        public DbSet<Shedule> Sheduless { get; set; }
        public DbSet<Work> Works { get; set; }

        public DbSet<BMI> BMIs{ get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
    }
}
