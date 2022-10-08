using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Domain.Entityes
{
    [Table("T_Products")]
    public class Products:EntityBase
    {
        public ProductKategories ProductKategories { get; set; } = ProductKategories.Groceries;
        [StringLength(10)]
        public string ProductCode { get; set; } = string.Empty;
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;
        public ICollection<InvoiceLines>? InvoiceLines { get; set; } 
    }
}
