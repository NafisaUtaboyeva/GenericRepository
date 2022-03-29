using GenericRepository.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Api.Data.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
