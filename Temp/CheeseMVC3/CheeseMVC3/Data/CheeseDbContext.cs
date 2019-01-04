using Microsoft.EntityFrameworkCore;
using CheeseMVC3.Models;

namespace CheeseMVC3.Data
{
    public class CheeseDbContext: DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        public CheeseDbContext(DbContextOptions<CheeseDbContext>options)
            :base(options)
        {

        }
    }
}
