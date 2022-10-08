using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shopsruscase.Domain;
using shopsruscase.Domain.Dtos;
using shopsruscase.Domain.Entityes;
using shopsruscase.Domain.Interfaces;
using shopsruscase.Infrastructure;

namespace shopsruscase.Applications
{
    public interface IinvoiceService : IScopedDependency 
    {
        Task<InvoiceDto> ApplyDiscountInvoices(ApplyDiscountInput input);
    }
    public class InvoiceService : IinvoiceService
    {
        private readonly  IAppDbContext _context;
        private readonly IMapper _mapper;
        public InvoiceService(IAppDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
                
        }
        public async Task<InvoiceDto> ApplyDiscountInvoices(ApplyDiscountInput input)
        {
            bool IsAppliedDiscount = false;
             var Invoice= await  _context.Invoices.Include(x=>x.Customer).ThenInclude(x=>x.Adress).Include(x=>x.InvoiceLines).ThenInclude(x=>x.Product).SingleAsync(f=>f.InvoiceNo.Equals(input.InvoiceNo));
            Invoice.GrossTotal = input.TotalAmount;
            Invoice?.InvoiceLines?.ToList().ForEach(x => { 
              x.Price = input.TotalAmount / Invoice.InvoiceLines.Count;
              x.TotalAmount = x.Price * x.Quantity.TryParseDecimal();

                if (!IsAppliedDiscount && Invoice?.Customer?.CustomerType == Domain.CustomerType.Branch && x.Product?.ProductKategories != Domain.ProductKategories.Groceries)
                { 
                    x.DiscountAmount = (x.TotalAmount * 10) / 100;
                    IsAppliedDiscount = true;
                }

                if (!IsAppliedDiscount && Invoice?.Customer?.CustomerType == Domain.CustomerType.Emoloyee && x.Product?.ProductKategories != Domain.ProductKategories.Groceries)
                {
                    x.DiscountAmount = (x.TotalAmount * 30) / 100;
                    IsAppliedDiscount = true;
                }

                if (!IsAppliedDiscount && Invoice?.Customer?.CustomerType == Domain.CustomerType.Other && x.Product?.ProductKategories != Domain.ProductKategories.Groceries)
                {
                    var oldyear = DateTime.Now.Year - Invoice?.Customer?.CreatedDate.Year;
                    if (oldyear >= 2) { 
                      x.DiscountAmount = (x.TotalAmount * 5) / 100;
                      IsAppliedDiscount = true;
                    }
                }
                x.NetAmount = x.TotalAmount - x.DiscountAmount;

            });

            var perDiscount =  (((int)(input.TotalAmount / 100)) * 5);

            var TotalDiscount = (Invoice?.InvoiceLines?.Sum(x => x.DiscountAmount) ?? 0)+ perDiscount;
            Invoice.NetTotal = input.TotalAmount - TotalDiscount;

            _context.Invoices.Update(Invoice);
             await   _context.SaveChanges(); 
            var result=_mapper.Map<InvoiceDto>(Invoice);
            result.Customer=_mapper.Map<CustomerDto>(Invoice?.Customer);
            result.Customer.customerAdress = _mapper.Map<List<CustomerAdresDto>>(Invoice?.Customer?.Adress);
            result.InvoiceLine = _mapper.Map<List<InvoiceLinesDto>>(Invoice?.InvoiceLines);
            result.InvoiceLine.ForEach(x => { x.Product = _mapper.Map<ProductDto>(x.Product);  });
            return result;
        }
    }
}
