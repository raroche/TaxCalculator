using System;
using System.Collections.Generic;
using TaxCalculator.Models;
using TaxCalculator.Services;

namespace TaxCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" Tax Calculator Demo!");

            var endCustomer = new EndCustomer(); // EndCustomer Uses TaxJar


            TaxServiceFactory taxServiceFactory = new TaxServiceFactory();
            var service = taxServiceFactory.CreateTaxService(endCustomer);

            // Calculate taxes by Location
            Console.WriteLine(service.CalculateTax("94111"));

            TaxOrderDTO testOrder = getTestOrder();

            // Calculate taxes by Order
            Console.WriteLine(service.CalculateTax(testOrder));


        }

        /// <summary>
        /// Create a Test order
        /// </summary>
        /// <returns> Returns a Test Order </returns>
        private static TaxOrderDTO getTestOrder()
        {
            TaxOrderDTO testOrder = new TaxOrderDTO();

            testOrder.from_country = "US";
            testOrder.from_zip = "07001";
            testOrder.from_state = "NJ";
            testOrder.to_country = "US";
            testOrder.to_zip = "07446";
            testOrder.to_state = "NJ";
            testOrder.amount = (decimal)16.50;
            testOrder.shipping = (decimal)1.50;

            LineItemTaxDTO lineItemTaxDTO = new LineItemTaxDTO();
            lineItemTaxDTO.quantity = 1;
            lineItemTaxDTO.unit_price = (decimal)15;
            lineItemTaxDTO.product_tax_code = "31000";

            testOrder.lineItems = new List<LineItemTaxDTO>();
            testOrder.lineItems.Add(lineItemTaxDTO);

            return testOrder;

        }
    }
}
