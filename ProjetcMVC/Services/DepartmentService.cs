using ProjetcMVC.Data;
using ProjetcMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetcMVC.Services
{
    public class DepartmentService
    {
        private readonly ProjetcMVCContext _context;

        public DepartmentService(ProjetcMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
