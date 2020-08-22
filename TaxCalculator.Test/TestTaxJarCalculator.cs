using System;
using Xunit;
using System;
using System.Collections.Generic;
using TaxCalculator.Models;
using TaxCalculator.Services;

namespace TaxCalculator.Test
{
    public class TestTaxJarCalculator
    {
        ICustomer endCustomer;

        TaxService service;

        public TestTaxJarCalculator()
        {
            endCustomer = new EndCustomer(); // EndCustomer Uses TaxJar

            TaxServiceFactory taxServiceFactory = new TaxServiceFactory();
            service = taxServiceFactory.CreateTaxService(endCustomer);
        }

        [Fact]
        public void TestTaxCalculatorByLocation001()
        {
            string testZipCode = "94111";
            double expectedValue = 0.085;

            Assert.Equal(expectedValue, service.CalculateTax(testZipCode)); 
        }

        [Fact]
        public void TestTaxCalculatorByLocation002()
        {
            string testZipCode = "33156"; 
            double expectedValue = 0.07;

            Assert.Equal(expectedValue, service.CalculateTax(testZipCode));
        }

        [Fact]
        public void TestTaxCalculatorByLocation003()
        {
            string testZipCode = "2000"; 
            double expectedValue = 0.06;

            Assert.Equal(expectedValue, service.CalculateTax(testZipCode));
        }


        [Fact]
        public void TestTaxCalculatorByOrder001()
        {
            TaxOrderDTO testOrder = new TaxOrderDTO();

            testOrder.from_country = "US";
            testOrder.from_zip = "07001";
            testOrder.from_state = "NJ";
            testOrder.to_country = "US";
            testOrder.to_zip = "07446";
            testOrder.to_state = "NJ";
            testOrder.amount = (decimal)16.50;
            testOrder.shipping = (decimal)1.5;

            LineItemTaxDTO lineItemTaxDTO = new LineItemTaxDTO();
            lineItemTaxDTO.quantity = 1;
            lineItemTaxDTO.unit_price = (decimal)15.0;
            lineItemTaxDTO.product_tax_code = "31000";

            testOrder.lineItems = new List<LineItemTaxDTO>();
            testOrder.lineItems.Add(lineItemTaxDTO);

            
            double expectedValue = 1.19;


            Assert.Equal(expectedValue, service.CalculateTax(testOrder));
        }

        [Fact]
        public void TestTaxCalculatorByOrder002()
        {
            TaxOrderDTO testOrder = new TaxOrderDTO();

            testOrder.from_country = "CA";
            testOrder.from_zip = "V6G 3E";
            testOrder.from_state = "BC";
            testOrder.to_country = "CA";
            testOrder.to_zip = "M5V 2T6";
            testOrder.to_state = "ON";
            testOrder.amount = (decimal)16.95;
            testOrder.shipping = (decimal)10;

            LineItemTaxDTO lineItemTaxDTO = new LineItemTaxDTO();
            lineItemTaxDTO.quantity = 1;
            lineItemTaxDTO.unit_price = (decimal)16.98;
            lineItemTaxDTO.product_tax_code = "31000";

            testOrder.lineItems = new List<LineItemTaxDTO>();
            testOrder.lineItems.Add(lineItemTaxDTO);


            double expectedValue = 3.5;


            Assert.Equal(expectedValue, service.CalculateTax(testOrder));
        }
    }
}
