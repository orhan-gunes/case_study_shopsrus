using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Domain.Entityes
{
    [Table("T_Customers")]
    public class Customers:EntityBase
    {
        public CustomerType CustomerType { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }=string.Empty;
        [StringLength(10)]
        public string CustoerCode { get; set; } = string.Empty;
        public ICollection<CustomerAdress>? Adress { get; set; }
        public ICollection<Invoices>? CustomerInvoices { get; set; }
     
    }
}
