using System;
using TaxCalculator.Services;

namespace TaxCalculator.Models
{
    public class Dealer : ICustomer
    {
         Enum ICustomer.GetType()
        {
            return CustomerEnum.Dealer;
        }
    }
}
