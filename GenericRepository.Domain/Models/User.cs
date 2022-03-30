using GenericRepository.Api.Enums;
using GenericRepository.Api.Models.Entities;
using System;

namespace GenericRepository.Api.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
