using System.Collections.Generic;
using MediatR;
using CleanArchitectureTest.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitectureTest.Application.Interfaces;

namespace CleanArchitectureTest.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.SKU = command.SKU;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}