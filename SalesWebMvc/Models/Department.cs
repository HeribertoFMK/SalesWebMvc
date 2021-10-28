using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Saller> Sallers { get; set; }
        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddSeller(Saller saller)
        {
            Sallers.Add(saller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sallers.Sum(saller => saller.TotalSales(initial, final));
        }
    }
}
