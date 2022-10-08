using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Domain.Entityes
{
    [Table("T_InvoiceLines")]
    public class InvoiceLines:EntityBase
    {
        public int LineNo { get; set; }
        public long InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoices? Invoice { get; set; }
        public long ProducteId { get; set; }
        [ForeignKey("ProductId")]
        public Products? Product { get; set; }
        public decimal NetAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
    }
}
