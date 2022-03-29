using GenericRepository.Api.Data.IRepositories;
using GenericRepository.Api.Data.Repositories;
using GenericRepository.Api.Models;
using GenericRepository.Api.Services.Interfaces;
using GenericRepository.Api.ViewModels;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository.Api.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        public UserService(IUserRepository userRepository)
        {
            userRepo = userRepository;
        }

        public Task<User> CreateAsync(UserForCreationViewModel user)
        {
            User user1 = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return userRepo.CreateAsync(user1);
        }

        public Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return userRepo.GetAsync(expression);
        }
    }
}
