using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<ProjetcMVC.Models.Department> Department { get; set; }
    }
}
