using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Domain
{
    public class ApplyDiscountInput
    {
       public string InvoiceNo { get; set; }=String.Empty;
        public decimal TotalAmount { get; set; } = decimal.Zero;
    }
}
