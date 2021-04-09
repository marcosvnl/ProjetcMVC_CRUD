using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetcMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name = "Bird Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)] 
        //ou [DisplayFormat(DataFormatString = "{0:F2}")] => 2 casas decimal       
        public double BaseSlary { get; set; }
        
        public Department Department { get; set; }
        //O EF Core vai entender q precisados de uma chave estrangeira para um vendedor resceber o Id de um departamento
        public int DepartmentId { get; set; } 
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() {}

        public Seller(int id, string name, string email, DateTime birthDate, double baseSlary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSlary = baseSlary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
