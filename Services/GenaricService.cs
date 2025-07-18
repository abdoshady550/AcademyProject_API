
using System.Threading.Tasks;
using AcademyProject_API.Model.Data;
using AcademyProject_API.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademyProject_API.Services
{
    public class GenaricService<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;


        public GenaricService(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null)
                return null;

            return item;
        }

        public async Task<T> Add(T item)
        {

            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Delete(T item)
        {

            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync(T item, T itemUpdated)
        {

            _context.Entry(item).CurrentValues.SetValues(itemUpdated);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
