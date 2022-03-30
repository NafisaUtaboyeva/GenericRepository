using GenericRepository.Api.Data.Context;
using GenericRepository.Api.Data.IRepositories;
using GenericRepository.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext dbContext;


        public IUserRepository Users { get; private set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
