using AutoMapper;
using shopsruscase.Domain.Dtos;
using shopsruscase.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsruscase.Applications.Repostory
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAdress, CustomerAdresDto>();
            CreateMap<Invoices, InvoiceDto>();
            CreateMap<InvoiceLines, InvoiceLinesDto>();
            CreateMap<Customers, CustomerDto>();
            CreateMap<Products, ProductDto>();
        }
    }
}
