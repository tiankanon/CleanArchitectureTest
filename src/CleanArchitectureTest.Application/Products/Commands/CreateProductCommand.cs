using System.Collections.Generic;
using MediatR;
using CleanArchitectureTest.Domain.Entities;

namespace CleanArchitectureTest.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string SKU { get; set; }
    }
}