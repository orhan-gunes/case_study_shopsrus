using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Domain.Dtos
{
    public class InvoiceDto
    {
        public string InvoiceNo { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetTotal { get; set; }
        public decimal GrossTotal { get; set; }
        public string CurrencyCode { get; set; } = "USD";
        public long CustomerId { get; set; }
        public CustomerDto? Customer {get;set;}
        public List<InvoiceLinesDto>? InvoiceLine { get; set; }

    }

    public class InvoiceLinesDto
    {
        public int LineNo { get; set; }
        public long InvoiceId { get; set; }

        public long ProducteId { get; set; }

        public decimal NetAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        public ProductDto? Product{ get; set; }
    }

    public class CustomerDto
    {
        public CustomerType CustomerType { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustoerCode { get; set; } = string.Empty;
        public List<CustomerAdresDto>? customerAdress { get; set; }
    }

    public class CustomerAdresDto 
    {
        public bool IsInvoiceAdres { get; set; }
        public string Title { get; set; } = "";
        public string Adress { get; set; } = "";
    }

    public class ProductDto 
    {
        public ProductKategories ProductKategories { get; set; } = ProductKategories.Groceries;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
    }
}
