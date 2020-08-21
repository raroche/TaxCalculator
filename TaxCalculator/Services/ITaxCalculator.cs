using System;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public interface ITaxCalculator
    {

        decimal GetTaxRateByLocation(string zipCode);
        decimal CalculateOrderTaxes(TaxOrderDTO order);

    
    }
}
