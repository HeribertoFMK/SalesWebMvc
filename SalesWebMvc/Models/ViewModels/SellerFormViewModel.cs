using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public  Saller  Saller{ get; set; }
        public List<Department> Departments { get; set; }
    }
}
