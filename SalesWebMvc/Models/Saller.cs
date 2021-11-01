using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Saller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
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
