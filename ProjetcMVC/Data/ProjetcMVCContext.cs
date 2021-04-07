using Microsoft.EntityFrameworkCore;
using ProjetcMVC.Models;

namespace ProjetcMVC.Data
{
    public class ProjetcMVCContext : DbContext
    {
        public ProjetcMVCContext (DbContextOptions<ProjetcMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
