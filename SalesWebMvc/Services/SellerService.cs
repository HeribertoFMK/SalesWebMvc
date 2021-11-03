using SalesWebMvc.Model;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Saller>> FindAllAsync()
        {
            return await _context.Saller.ToListAsync();
        }
        public async Task InsertAsysnc(Saller obj)
        {

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Saller> FindByIdAsync(int id)
        {
            return  await _context.Saller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Saller.FindAsync(id);
                _context.Saller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }
        public async Task UpdateAsync(Saller obj)
        {
            bool hasany = await _context.Saller.AnyAsync(x => x.Id == obj.Id);
            if ( !hasany)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
            
        }

    } 
}

