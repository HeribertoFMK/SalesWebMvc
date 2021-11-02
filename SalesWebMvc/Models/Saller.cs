using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Saller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [StringLength(60,MinimumLength =3, ErrorMessage ="{0} size should be between {2} and {1}")]
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }
        
        [Display(Name = "Birth Date ")]
        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
       
        [Display(Name = "Basy Salary")]
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0,50000.00,ErrorMessage ="{0}must be from {1} to {2}")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BasySalary { get; set; }
        
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public Saller()
        {

        }

        public Saller(int id, string name, string email, DateTime birthDate, double basySalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BasySalary = basySalary;
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
        public double TotalSales(DateTime initial,DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr=> sr.Amount);
        }
        
    }
}
