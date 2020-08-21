using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxCalculator.Models;
using TaxCalculator.Services;

namespace TaxCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Tax Calculator Demo!");

            var endCustomer = new EndCustomer(); // EndCustomer Uses TaxJar


            TaxServiceFactory taxServiceFactory = new TaxServiceFactory();
            var service = taxServiceFactory.CreateTaxService(endCustomer);

            // Calculate taxes by Location
            Console.WriteLine(service.CalculateTax("33156"));

            // Calculate taxes by Order
            Console.WriteLine(service.CalculateTax(new TaxOrderDTO()));



        }

     
    }
}
