using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanArchitectureTest.Application.Products.Queries;
using CleanArchitectureTest.Application.Products.Commands;
using MediatR;

namespace CleanArchitectureTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllProducts()
        {
            return Ok(await _mediator.Send(new ReadAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadProductById(int id) 
        {
            return Ok(await _mediator.Send(new ReadProductByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command) 
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
