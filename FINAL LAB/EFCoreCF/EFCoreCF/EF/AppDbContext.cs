using EFCoreCF.Models;
using EFCoreCF.EF;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCF.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Depertment> Depertments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dept1 = new Depertment() { Id=1, Deptname = "BBA" };
            modelBuilder.Entity<Depertment>().HasData(dept1);
        }

    }

    
}