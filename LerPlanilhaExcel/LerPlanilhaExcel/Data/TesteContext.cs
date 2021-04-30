using Microsoft.EntityFrameworkCore;
using LerPlanilhaExcel.Models;

namespace LerPlanilhaExcel.Data
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
