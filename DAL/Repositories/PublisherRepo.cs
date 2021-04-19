using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookush.DAL.DBO;
using Microsoft.EntityFrameworkCore;

namespace Bookush.DAL.Repositories
{
    public class PublisherRepo : BaseRepo, IRepository<Publisher>
    {
        public PublisherRepo(BookDBContext context)
            :base(context)
        {
        }

        public async Task CreateAsync(Publisher entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await _context.Publishers
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Publisher entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        
        public bool Exists(int id)
        {
            return _context.Publishers.Any(e => e.Id == id);

        }
    } 
       
}
