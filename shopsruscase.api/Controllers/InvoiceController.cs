using Microsoft.AspNetCore.Mvc;
using shopsruscase.Applications;
using shopsruscase.Domain;
using shopsruscase.Domain.Dtos;
using shopsruscase.Domain.Entityes;

namespace shopsruscase.api.Controllers
{
    public class InvoiceController : ControllersBase
    {
        private readonly IinvoiceService invoiceService;
        public InvoiceController(IServiceProvider provider, IinvoiceService _invoiceService) : base(provider)
        {
            invoiceService = _invoiceService;

        }

        [HttpPut("ApplyDiscountInvoice")]
        public Task<InvoiceDto> ApplyDiscountInvoice([FromBody] ApplyDiscountInput input) 
        {
          return invoiceService.ApplyDiscountInvoices(input);    
        }
    }
}
