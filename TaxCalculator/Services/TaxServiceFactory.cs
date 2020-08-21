using System;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Models;
using TaxCalculator;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TaxCalculator.Services
{
    public class TaxServiceFactory
    {
        public TaxService CreateTaxService(ICustomer customer)
        {
            

            switch (customer.GetType()){

                case CustomerEnum.EndCustomer:
                    return new TaxService(new TaxJarCalculator());

                case CustomerEnum.Dealer:
                    return null;  //TODO: Return another type of TaxService

                default:
                    throw new Exception("Invalid Argument");


            }
        }

      


    }
}
