using GenericRepository.Api.Data.IRepositories;
using GenericRepository.Api.Data.Repositories;
using GenericRepository.Api.Models;
using GenericRepository.Api.ViewModels;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository.Api.Services.Interfaces
{
    public interface IUserService 
    {
        Task<User> CreateAsync(UserForCreationViewModel user);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
    }
}
