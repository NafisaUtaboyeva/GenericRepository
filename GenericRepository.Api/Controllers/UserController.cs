using GenericRepository.Api.Models;
using GenericRepository.Api.Services.Interfaces;
using GenericRepository.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserService userService;
        public UserController(IUserService service)
        {
            userService = service;
        }

        [HttpPost]
        public Task<User> Create(UserForCreationViewModel user)
        {
            return userService.CreateAsync(user);
        }

        [HttpGet("{id}")]
        public Task<User> Get(int id)
        {
            return userService.GetAsync(p => p.Id == id);
        }


        [HttpGet]
        public Task<IEnumerable<User>> GetAll([FromQuery] int pageSize, int pageIndex)
        {
            return userService.GetAllAsync(pageSize, pageIndex);
        }


        [HttpPut("{id}")]
        public Task<User> Update(int id, UserForCreationViewModel user)
        {
            return userService.UpdateAsync(id, user);
        }


        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return userService.DeleteAsync(p => p.Id == id);
        }
    }
}




