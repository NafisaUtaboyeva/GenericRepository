using GenericRepository.Api.Models;
using GenericRepository.Api.Services.Interfaces;
using GenericRepository.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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

        [HttpGet]
        public Task<User> Get(int id)
        {
            return userService.GetAsync(p => p.Id == id);
        }

    }
}
