using GenericRepository.Api.Models;
using GenericRepository.Api.Services.Interfaces;
using GenericRepository.Api.ViewModels;
using GenericRepository.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace GenericRepository.Api.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> CreateAsync(UserForCreationViewModel user)
        {
            User user1 = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var result = await unitOfWork.Users.CreateAsync(user1);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var user = await unitOfWork.Users.GetAsync(expression);

            if(user is not null)
            {
                user.Deleted();
                var result = await unitOfWork.Users.UpdateAsync(user);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<User, bool>> expression = null)
        {
            var users = await unitOfWork.Users.GetAllAsync(expression);
            return users.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        public Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return unitOfWork.Users.GetAsync(expression);
        }

        public async Task<User> UpdateAsync(int id, UserForCreationViewModel user)
        {
            var student = await unitOfWork.Users.GetAsync(p => p.Id == id);

            student.FirstName = user.FirstName;
            student.LastName = user.LastName;

            student.Update();

            var result = await unitOfWork.Users.UpdateAsync(student);

            await unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
