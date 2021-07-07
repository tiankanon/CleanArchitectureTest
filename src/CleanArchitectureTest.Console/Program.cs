using System;
using CleanArchitectureTest.Application.Products.Queries;
using MediatR;
using Microsoft.Extensions.Hosting;
using CleanArchitectureTest.Application;
using CleanArchitectureTest.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitectureTest.Console
{
    class Program
    {
        private readonly IMediator _mediator;
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public Program(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async void Run()
        {
            System.Console.WriteLine(Assembly.GetExecutingAssembly().ToString());
            System.Console.WriteLine("Hello World");
            var query = new ReadAllProductsQuery();
            var products = await _mediator.Send(query);
            foreach (var product in products)
            {
                System.Console.WriteLine($"Product: {product.SKU}");
            }
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddApplication();
                services.AddInfrastructure(new ConfigurationBuilder().Build());
                services.AddTransient<Program>();
            });
        }
    }
}
