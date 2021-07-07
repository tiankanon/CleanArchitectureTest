using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureTest.Domain.Entities;

namespace CleanArchitectureTest.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync();
    }
}