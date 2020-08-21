using System;
using TaxCalculator.Services;

namespace TaxCalculator.Models
{
    public class EndCustomer : ICustomer
    {
        Enum ICustomer.GetType()
        {
            return CustomerEnum.EndCustomer;
        }
    }
}
