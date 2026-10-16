using Microsoft.EntityFrameworkCore;
using EntityFramework_1.Models;
using EntityFramework_1.EF;

namespace EntityFramework_1.EF
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) { 
            
        }

        public DbSet<Student> student {  get; set; }

    }
}
