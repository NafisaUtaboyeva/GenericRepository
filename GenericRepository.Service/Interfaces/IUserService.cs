using GenericRepository.Api.Models;
using GenericRepository.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository.Api.Services.Interfaces
{
    public interface IUserService 
    {
        Task<User> CreateAsync(UserForCreationViewModel user);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<IEnumerable<User>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<User, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<User> UpdateAsync(int id, UserForCreationViewModel user);
    }
}
