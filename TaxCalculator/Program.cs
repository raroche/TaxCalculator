using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Models;
using TaxCalculator.Services;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tax Calculator!");


            var endCustomer = new EndCustomer(); // EndCustomer Uses TaxJar


            TaxServiceFactory taxServiceFactory = new TaxServiceFactory();
            var service = taxServiceFactory.CreateTaxService(endCustomer);

            Console.WriteLine(service.CalculateTax("33156"));
            Console.WriteLine(service.CalculateTax(new TaxOrderDTO()));


            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register DI
                    //services.AddTransient<Interface, Class>();
                   
                }).Build();



            //var service = ActivatorUtilities.CreateInstance<Interface>(host.Services);
        }
    }
}
