using System;
using TaxCalculator.Models;


namespace TaxCalculator.Services
{
    public class TaxService
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public decimal CalculateTax(TaxOrderDTO order)
        {
            return _taxCalculator.CalculateOrderTaxes(order);
        }

        public decimal CalculateTax(string zipCode)
        {
            return _taxCalculator.GetTaxRateByLocation(zipCode);
        }

    }
}
