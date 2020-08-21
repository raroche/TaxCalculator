using System;
using System.Collections.Generic;

namespace TaxCalculator.Models

{
    public class TaxOrderDTO
    {
        public string from_country { get; set; }
        public string from_zip   { get; set; }
        public string from_state { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string shipping { get; set; }
        public string line_items { get; set; }

        public List<LineItemTaxDTO> lineItems { get; set; }

    }
}
