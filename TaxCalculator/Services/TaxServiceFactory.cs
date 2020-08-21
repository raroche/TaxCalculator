using System;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public class TaxServiceFactory
    {
        public TaxService CreateTaxService(ICustomer customer)
        {
            switch(customer.GetType()){

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
