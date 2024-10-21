using Microsoft.EntityFrameworkCore;
using MyLeave.Domain.Leaves;
using System.Reflection.Metadata.Ecma335;

namespace MyLeave.EntityFrameworkCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Leave> Leaves { get; set; }

       

    }
}
