using System.Collections.Generic;
using MediatR;
using CleanArchitectureTest.Domain.Entities;

namespace CleanArchitectureTest.Application.Products.Queries
{
    public class ReadProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}