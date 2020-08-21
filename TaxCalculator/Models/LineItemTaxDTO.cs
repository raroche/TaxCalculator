using System;
namespace TaxCalculator.Models
{
    public class LineItemTaxDTO
    {
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
        public string product_tax_code { get; set; }
    }
}
