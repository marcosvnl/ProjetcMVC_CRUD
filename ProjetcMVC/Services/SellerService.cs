using ProjetcMVC.Data;
using ProjetcMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetcMVC.Services
{
    public class SellerService
    {
        private readonly ProjetcMVCContext _context;

        public SellerService(ProjetcMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
