using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Domain.Entityes
{
    [Table("T_Invoices")]
    public class Invoices:EntityBase
    {
        public string InvoiceNo { get; set; }=string.Empty; 
        public DateTime InvoiceDate { get; set; }
        public decimal TotalDiscount { get; set; }  
        public decimal NetTotal { get; set; }
        public decimal GrossTotal { get; set; }
        public string CurrencyCode {get; set; }="USD";
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers? Customer { get; set; }
        public ICollection<InvoiceLines>? InvoiceLines { get; set; }
    }
}
