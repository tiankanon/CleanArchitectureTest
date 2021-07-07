using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MediatR;
using CleanArchitectureTest.Domain.Entities;
using CleanArchitectureTest.Application.Interfaces;

namespace CleanArchitectureTest.Application.Products.Queries
{
    public class ReadProductByIdHandler : IRequestHandler<ReadProductByIdQuery, Product>
    {
        private readonly IApplicationDbContext _context;
        public ReadProductByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(ReadProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == query.Id).FirstOrDefaultAsync();
            if (product == null) return null;
            return product;
        }
    }
}