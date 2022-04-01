using GenericRepository.Api.Data.Context;
using GenericRepository.Api.Data.IRepositories;
using GenericRepository.Api.Data.Repositories;
using GenericRepository.Data.IRepositories;
using System;
using System.Threading.Tasks;

namespace GenericRepository.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext dbContext;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
            Users = new UserRepository(dbContext);
        }


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