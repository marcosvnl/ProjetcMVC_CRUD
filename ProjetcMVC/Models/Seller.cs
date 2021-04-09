using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetcMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo {0} dever ser preenchido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} deve conter entre {2} e {1} letras")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Campo {0} dever ser preenchido")]
        [EmailAddress(ErrorMessage = "E-mail não é valido")]
        public string Email { get; set; }
        
        [Display(Name = "Bird Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo {0} dever ser preenchido")]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Campo {0} dever ser preenchido")]
        //ou [DisplayFormat(DataFormatString = "{0:F2}")] => 2 casas decimal
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve estar detro de {1:C2} to {2:C2}")]
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
