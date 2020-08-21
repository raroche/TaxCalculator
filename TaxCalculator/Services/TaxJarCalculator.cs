using System;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public class TaxJarCalculator : ITaxCalculator
    {
        public decimal CalculateOrderTaxes(TaxOrderDTO order)
        {
            return 1;
        }

        public decimal GetTaxRateByLocation(string zipCode)
        {
            return 1;
        }
    }
}
