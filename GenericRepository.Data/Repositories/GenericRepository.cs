using GenericRepository.Api.Data.Context;
using GenericRepository.Api.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository.Api.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ProjectDbContext dbContext;
        private DbSet<T> dbSet;

        public GenericRepository(ProjectDbContext projectDb)
        {
            dbContext = projectDb;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate)
        { 
            var entry = await dbSet.FirstOrDefaultAsync(predicate);

            if(entry is null)
                return false;

            dbSet.Remove(entry);

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate is null ? dbSet : dbSet.Where(predicate);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = dbSet.Update(entity);

            return entry.Entity;
        }
    }
}
