using Microsoft.EntityFrameworkCore;
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
            ////teste fa ForeingKey
            //obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            //Include pertence ao EF Core e inclui o obj department para podermos acessar na view
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
