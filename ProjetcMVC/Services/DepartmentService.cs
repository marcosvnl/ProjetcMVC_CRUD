using ProjetcMVC.Data;
using ProjetcMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetcMVC.Services
{
    public class DepartmentService
    {
        private readonly ProjetcMVCContext _context;

        public DepartmentService(ProjetcMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
