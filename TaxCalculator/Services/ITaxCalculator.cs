using System;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public interface ITaxCalculator
    {

        double GetTaxRateByLocation(string zipCode);
        double CalculateOrderTaxes(TaxOrderDTO order);

    
    }
}
