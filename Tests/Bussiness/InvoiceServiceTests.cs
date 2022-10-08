using AutoFixture;
using AutoMapper;
using Moq;
using shopsruscase.Applications;
using shopsruscase.Applications.Repostory;
using shopsruscase.Domain;
using shopsruscase.Domain.Entityes;
using shopsruscase.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestHelpers;
using Xunit;

namespace shopsrus.Tests.Bussiness
{
    public class InvoiceServiceTests
    {
        private readonly Fixture _fixture;
        private Mock<IAppDbContext> _dbMock;
        private Mock<IRedisService> _redisMock;
        private IMapper _mapper;
        private readonly IinvoiceService _invoiceService;


        public InvoiceServiceTests()
        {
            _fixture = new Fixture();
            _dbMock = new Mock<IAppDbContext>();
            _redisMock = new Mock<IRedisService>();
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper();
            _invoiceService = new InvoiceService(_dbMock.Object, _mapper);

        }

        [Fact]
        public async Task GetAppDinemsions_Product_Categories_Groceries_and_Customer_type_Employee_test()
        {

            

            var productList = _fixture.Build<Products>()
                .With(x => x.Id, 1)
                .With(x => x.ProductKategories, ProductKategories.Groceries)
                .With(x => x.InvoiceLines,new List<InvoiceLines>())
                .CreateMany(1)
                .ToList();
            var dbsetsProduct = DbMockHelper.CreateMockDbSet(productList);
            _dbMock.Setup(x => x.Products).Returns(dbsetsProduct);

            _dbMock.Setup(x => x.Customers).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<Customers>()
               .With(x => x.Id, 1)
               .With(x=>x.CustomerType,CustomerType.Emoloyee)
               .With(x => x.CustomerInvoices, new List<Invoices>())
                   .With(x => x.Adress, new List<CustomerAdress>())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.CustomerAdresses).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<CustomerAdress>()
               .With(x => x.Id, 1)
                .With(x => x.CustomerId, 1)
                   .With(x => x.Customers, _dbMock.Object.Customers.First())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.InvoiceLines).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<InvoiceLines>()
              .With(x => x.Id, 1)
              .With(x => x.ProducteId, 1)
                .With(x => x.InvoiceId, 1)
                 .With(x=>x.Product,_dbMock.Object.Products.First())
                 .With(x=>x.Invoice,new Invoices())
                 .CreateMany(1)
                .ToList()
                    ));


            _dbMock.Setup(x => x.Invoices).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<Invoices>()
             .With(x => x.Id, 1)
              .With(x => x.InvoiceNo, "001")
             .With(x => x.CustomerId, 1)
             .With(x=>x.Customer,_dbMock.Object.Customers.First())
             .With(x => x.InvoiceLines, _dbMock.Object.InvoiceLines.ToList())    
             .With(x=>x.CurrencyCode,"USD")
             .CreateMany(1)
             .ToList()
             ));

            //Assert
            var result =  await _invoiceService.ApplyDiscountInvoices(new shopsruscase.Domain.ApplyDiscountInput { InvoiceNo="001", TotalAmount=1000 });
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAppDinemsions_Product_Categories_Other_and_Customer_type_Employee_test()
        {



            var productList = _fixture.Build<Products>()
                .With(x => x.Id, 1)
                .With(x => x.ProductKategories, ProductKategories.Other)
                .With(x => x.InvoiceLines, new List<InvoiceLines>())
                .CreateMany(1)
                .ToList();
            var dbsetsProduct = DbMockHelper.CreateMockDbSet(productList);
            _dbMock.Setup(x => x.Products).Returns(dbsetsProduct);

            _dbMock.Setup(x => x.Customers).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<Customers>()
               .With(x => x.Id, 1)
               .With(x => x.CustomerType, CustomerType.Emoloyee)
               .With(x => x.CustomerInvoices, new List<Invoices>())
                   .With(x => x.Adress, new List<CustomerAdress>())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.CustomerAdresses).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<CustomerAdress>()
               .With(x => x.Id, 1)
                .With(x => x.CustomerId, 1)
                   .With(x => x.Customers, _dbMock.Object.Customers.First())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.InvoiceLines).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<InvoiceLines>()
              .With(x => x.Id, 1)
              .With(x => x.ProducteId, 1)
                .With(x => x.InvoiceId, 1)
                 .With(x => x.Product, _dbMock.Object.Products.First())
                 .With(x => x.Invoice, new Invoices())
                 .CreateMany(1)
                .ToList()
                    ));


            _dbMock.Setup(x => x.Invoices).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<Invoices>()
             .With(x => x.Id, 1)
              .With(x => x.InvoiceNo, "001")
             .With(x => x.CustomerId, 1)
             .With(x => x.Customer, _dbMock.Object.Customers.First())
             .With(x => x.InvoiceLines, _dbMock.Object.InvoiceLines.ToList())
             .With(x => x.CurrencyCode, "USD")
             .CreateMany(1)
             .ToList()
             ));

            //Assert
            var result = await _invoiceService.ApplyDiscountInvoices(new shopsruscase.Domain.ApplyDiscountInput { InvoiceNo = "001", TotalAmount = 1000 });
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAppDinemsions_Product_Categories_Other_and_Customer_type_Branch_test()
        {



            var productList = _fixture.Build<Products>()
                .With(x => x.Id, 1)
                .With(x => x.ProductKategories, ProductKategories.Other)
                .With(x => x.InvoiceLines, new List<InvoiceLines>())
                .CreateMany(1)
                .ToList();
            var dbsetsProduct = DbMockHelper.CreateMockDbSet(productList);
            _dbMock.Setup(x => x.Products).Returns(dbsetsProduct);

            _dbMock.Setup(x => x.Customers).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<Customers>()
               .With(x => x.Id, 1)
               .With(x => x.CustomerType, CustomerType.Branch)
               .With(x => x.CustomerInvoices, new List<Invoices>())
                   .With(x => x.Adress, new List<CustomerAdress>())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.CustomerAdresses).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<CustomerAdress>()
               .With(x => x.Id, 1)
                .With(x => x.CustomerId, 1)
                   .With(x => x.Customers, _dbMock.Object.Customers.First())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.InvoiceLines).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<InvoiceLines>()
              .With(x => x.Id, 1)
              .With(x => x.ProducteId, 1)
                .With(x => x.InvoiceId, 1)
                 .With(x => x.Product, _dbMock.Object.Products.First())
                 .With(x => x.Invoice, new Invoices())
                 .CreateMany(1)
                .ToList()
                    ));


            _dbMock.Setup(x => x.Invoices).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<Invoices>()
             .With(x => x.Id, 1)
              .With(x => x.InvoiceNo, "001")
             .With(x => x.CustomerId, 1)
             .With(x => x.Customer, _dbMock.Object.Customers.First())
             .With(x => x.InvoiceLines, _dbMock.Object.InvoiceLines.ToList())
             .With(x => x.CurrencyCode, "USD")
             .CreateMany(1)
             .ToList()
             ));

            //Assert
            var result = await _invoiceService.ApplyDiscountInvoices(new shopsruscase.Domain.ApplyDiscountInput { InvoiceNo = "001", TotalAmount = 1000 });
            result.ShouldNotBeNull();
        }


        [Fact]
        public async Task GetAppDinemsions_Product_Categories_Other_and_Customer_type_Other_test()
        {



            var productList = _fixture.Build<Products>()
                .With(x => x.Id, 1)
                .With(x => x.ProductKategories, ProductKategories.Other)
                .With(x => x.InvoiceLines, new List<InvoiceLines>())
                .CreateMany(1)
                .ToList();
            var dbsetsProduct = DbMockHelper.CreateMockDbSet(productList);
            _dbMock.Setup(x => x.Products).Returns(dbsetsProduct);

            _dbMock.Setup(x => x.Customers).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<Customers>()
               .With(x => x.Id, 1)
               .With(x => x.CustomerType, CustomerType.Other)
               .With(x => x.CustomerInvoices, new List<Invoices>())
                   .With(x => x.Adress, new List<CustomerAdress>())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.CustomerAdresses).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<CustomerAdress>()
               .With(x => x.Id, 1)
                .With(x => x.CustomerId, 1)
                   .With(x => x.Customers, _dbMock.Object.Customers.First())
               .CreateMany(1)
               .ToList()
               ));

            _dbMock.Setup(x => x.InvoiceLines).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<InvoiceLines>()
              .With(x => x.Id, 1)
              .With(x => x.ProducteId, 1)
                .With(x => x.InvoiceId, 1)
                 .With(x => x.Product, _dbMock.Object.Products.First())
                 .With(x => x.Invoice, new Invoices())
                 .CreateMany(1)
                .ToList()
                    ));


            _dbMock.Setup(x => x.Invoices).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<Invoices>()
             .With(x => x.Id, 1)
              .With(x => x.InvoiceNo, "001")
             .With(x => x.CustomerId, 1)
             .With(x => x.Customer, _dbMock.Object.Customers.First())
             .With(x => x.InvoiceLines, _dbMock.Object.InvoiceLines.ToList())
             .With(x => x.CurrencyCode, "USD")
             .CreateMany(1)
             .ToList()
             ));

            //Assert
            var result = await _invoiceService.ApplyDiscountInvoices(new shopsruscase.Domain.ApplyDiscountInput { InvoiceNo = "001", TotalAmount = 1000 });
            result.ShouldNotBeNull();
        }


        [Fact]
        public async Task GetAppDinemsions_Product_Categories_Other_and_Customer_type_Other_and_oldCustomer_discount_test()
        {
            var productList = _fixture.Build<Products>()
                .With(x => x.Id, 1)
                .With(x => x.ProductKategories, ProductKategories.Other)
                .With(x => x.InvoiceLines, new List<InvoiceLines>())
                .CreateMany(1)
                .ToList();
            var dbsetsProduct = DbMockHelper.CreateMockDbSet(productList);
            _dbMock.Setup(x => x.Products).Returns(dbsetsProduct);
            _dbMock.Setup(x => x.Customers).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<Customers>()
               .With(x => x.Id, 1)
               .With(x => x.CreatedDate, new DateTime(2019,01,01))
               .With(x => x.CustomerType, CustomerType.Other)
               .With(x => x.CustomerInvoices, new List<Invoices>())
                   .With(x => x.Adress, new List<CustomerAdress>())
               .CreateMany(1)
               .ToList()
               ));
            _dbMock.Setup(x => x.CustomerAdresses).Returns(DbMockHelper.CreateMockDbSet(
               _fixture.Build<CustomerAdress>()
               .With(x => x.Id, 1)
                .With(x => x.CustomerId, 1)
                   .With(x => x.Customers, _dbMock.Object.Customers.First())
               .CreateMany(1)
               .ToList()
               ));
            _dbMock.Setup(x => x.InvoiceLines).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<InvoiceLines>()
              .With(x => x.Id, 1)
              .With(x => x.ProducteId, 1)
                .With(x => x.InvoiceId, 1)
                 .With(x => x.Product, _dbMock.Object.Products.First())
                 .With(x => x.Invoice, new Invoices())
                 .CreateMany(1)
                .ToList()
                    ));
            _dbMock.Setup(x => x.Invoices).Returns(DbMockHelper.CreateMockDbSet(
             _fixture.Build<Invoices>()
             .With(x => x.Id, 1)
              .With(x => x.InvoiceNo, "001")
             .With(x => x.CustomerId, 1)
             .With(x => x.Customer, _dbMock.Object.Customers.First())
             .With(x => x.InvoiceLines, _dbMock.Object.InvoiceLines.ToList())
             .With(x => x.CurrencyCode, "USD")
             .CreateMany(1)
             .ToList()
             ));

            //Assert
            var result = await _invoiceService.ApplyDiscountInvoices(new shopsruscase.Domain.ApplyDiscountInput { InvoiceNo = "001", TotalAmount = 1000 });
            result.ShouldNotBeNull();
        }

    }
}
