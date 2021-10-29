using SalesWebMvc.Model;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Saller> FindAll()
        {
           return  _context.Saller.ToList();
        }
        public void Insert(Saller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
