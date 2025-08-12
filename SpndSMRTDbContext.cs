using Microsoft.EntityFrameworkCore;

namespace SpndSMRT.Models
{
    public class SpndSMRTDbContext : DbContext
    {
       public DbSet<Expense> Expenses { get; set; }

        //constructor
       public SpndSMRTDbContext(DbContextOptions<SpndSMRTDbContext> options)
          :  base(options)
        {

        }
    }
}
