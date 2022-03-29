using GenericRepository.Api.Enums;
using System;

namespace GenericRepository.Api.Models.Entities
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime EditedDate { get; set; }
        public int UpdatedBy { get; set; }
        public State Status { get; set; } = State.Created;

        public void Update(int userId)
        {
            UpdatedBy = userId;
            EditedDate = DateTime.Now;
            Status = State.Updated;
        }

        public void Deleted(int userId)
        {
            UpdatedBy = userId;
            EditedDate = DateTime.Now;
            Status = State.Deleted;
        }
    }
}
