using GenericRepository.Api.Data.Context;
using GenericRepository.Api.Data.IRepositories;
using GenericRepository.Api.Models;

namespace GenericRepository.Api.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectDbContext dbContext) : base(dbContext)
        {

        }
    }
}
