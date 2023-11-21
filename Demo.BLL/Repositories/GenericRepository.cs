using Demo.BLL.Interfaces;
using Demo.DAL.Models.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MVCAppContext _dbContext;
        public GenericRepository(MVCAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T t)
        {
            await _dbContext.AddAsync(t);
        }

        public void Delete(T t)
        {
            _dbContext.Remove(t);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T) == typeof(Employee))
            {
              return  (IEnumerable<T>)await _dbContext.Employees.Include(e=>e.Department).ToListAsync();
            }
           return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            _dbContext.Update(item);
        }
    }
}
