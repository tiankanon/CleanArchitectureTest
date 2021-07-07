using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitectureTest.Domain.Entities;
using CleanArchitectureTest.Application.Interfaces;

namespace CleanArchitectureTest.Application.Products.Queries
{
    public class ReadAllProductsQueryHandler : IRequestHandler<ReadAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _context;
        public ReadAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> Handle(ReadAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();
            if (products == null) return null;
            return products;
        }
    }
}