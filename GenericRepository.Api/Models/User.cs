using GenericRepository.Api.Models.Entities;

namespace GenericRepository.Api.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
