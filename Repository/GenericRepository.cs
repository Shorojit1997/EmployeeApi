using EmployeeApi.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeApi.Repository
{
    public class GenericRepository<T> :IGenericRepository<T>   where T : class
    {
        protected readonly EmployeeDbContext _context;
        protected readonly ILogger _logger;
        internal DbSet<T> dbset;
        public GenericRepository(EmployeeDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbset = _context.Set<T>();

        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public virtual async Task<bool> Delete(T entity)
        {
            dbset.Remove(entity);
            return true;
        }


        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbset.FindAsync(id);
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
            return;
        }
    }
}
