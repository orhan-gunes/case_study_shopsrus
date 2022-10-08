using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Domain.Entityes
{
    [Table("T_CustomerAdress")]
    public class CustomerAdress:EntityBase
    {
        public bool IsInvoiceAdres { get; set; }
        public long CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customers? Customers { get; set; }

        [StringLength(100)]
        public string Title { get; set; } = "";
        [StringLength(300)]
        public string Adress { get; set; } = "";


    }
}
