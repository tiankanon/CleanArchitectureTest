using Microsoft.EntityFrameworkCore;
using CleanArchitectureTest.Application.Interfaces;
using CleanArchitectureTest.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitectureTest.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}