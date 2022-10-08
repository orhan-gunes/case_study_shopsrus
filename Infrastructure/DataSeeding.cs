using shopsruscase.Domain;
using shopsruscase.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace shopsruscase.Infrastructure
{
    public static class DataSeeding
    {

        public static async Task Seed(IAppDbContext app)
        {

            if (app.Invoices.Count() == 0)
            {

                var Invoice0 = new Invoices
                {
                    CreatedDate = DateTime.Now,
                    CreatedUser = "-1",
                    CurrencyCode = "USD",
                    Customer = new Customers
                    { 
                        CreatedDate=new DateTime(2020,01,01), 
                        Adress=new List<CustomerAdress> { new CustomerAdress { Adress= "Deneme Soğağı Deneme Adresi C001", IsInvoiceAdres=true, Title="Fatura" } } ,
                        CustomerType=  CustomerType.Branch,
                        CustomerName= "Sube Müşterisi",
                        CustoerCode= "C001"
                    },
                       GrossTotal=0,
                       InvoiceDate=DateTime.Now, 
                       NetTotal=0,
                       TotalDiscount=0,
                       InvoiceNo="I00000001",
                       InvoiceLines=new List<InvoiceLines> 
                       {
                       new  InvoiceLines 
                       {
                         DiscountAmount=0,
                         LineNo=0,
                         NetAmount=0, 
                         Price=0,
                         Product= new Products{ ProductCode="P001", ProductKategories=ProductKategories.Groceries, ProductName="Spagetti Makarna" },
                         Quantity=1,
                         TotalAmount=0, 
                       } 
                       ,
                        new  InvoiceLines
                       {
                         DiscountAmount=0,
                         LineNo=1,
                         NetAmount=0,
                         Price=0,
                         Product= new Products{ ProductCode="P002", ProductKategories=ProductKategories.Other, ProductName="Kışlık Bot Ayakkabı" },
                         Quantity=1,
                         TotalAmount=0,
                       }

                       },
                };


                var Invoice1 = new Invoices
                {
                    CreatedDate = DateTime.Now,
                    CreatedUser = "-1",
                    CurrencyCode = "USD",
                    Customer = new Customers
                    {
                        CreatedDate = new DateTime(2020, 01, 01),
                        Adress = new List<CustomerAdress> { new CustomerAdress { Adress = "Deneme Soğağı Deneme Adresi C002", IsInvoiceAdres = true, Title = "Fatura" } },
                        CustomerType = CustomerType.Other,
                        CustomerName = "Diğer Tip Müşterisi",
                        CustoerCode = "C002"
                    },
                    GrossTotal = 0,
                    InvoiceDate = DateTime.Now,
                    NetTotal = 0,
                    TotalDiscount = 0,
                    InvoiceNo = "I00000002",
                    InvoiceLines = new List<InvoiceLines>
                       {
                       new  InvoiceLines
                       {
                         DiscountAmount=0,
                         LineNo=0,
                         NetAmount=0,
                         Price=0,
                         Product= Invoice0.InvoiceLines.Single(x=>x.LineNo==0).Product,
                         Quantity=1,
                         TotalAmount=0,
                       }
                       ,
                        new  InvoiceLines
                       {
                         DiscountAmount=0,
                         LineNo=1,
                         NetAmount=0,
                         Price=0,
                         Product= Invoice0.InvoiceLines.Single(x=>x.LineNo==1).Product,
                         Quantity=1,
                         TotalAmount=0,
                       }

                       },
                };


                var Invoice2 = new Invoices
                {
                    CreatedDate = DateTime.Now,
                    CreatedUser = "-1",
                    CurrencyCode = "USD",
                    Customer = new Customers
                    {
                        CreatedDate = new DateTime(2020, 01, 01),
                        Adress = new List<CustomerAdress> { new CustomerAdress { Adress = "Deneme Sokğağı Deneme Adresi C003", IsInvoiceAdres = true, Title = "Fatura" } },
                        CustomerType = CustomerType.Emoloyee,
                        CustomerName = "Çalışan Personel  Müşterisi",
                        CustoerCode = "C003"
                    },
                    GrossTotal = 0,
                    InvoiceDate = DateTime.Now,
                    NetTotal = 0,
                    TotalDiscount = 0,
                    InvoiceNo = "I00000003",
                    InvoiceLines = new List<InvoiceLines>
                       {
                       new  InvoiceLines
                       {
                         DiscountAmount=0,
                         LineNo=0,
                         NetAmount=0,
                         Price=0,
                         Product=Invoice0.InvoiceLines.Single(x=>x.LineNo==0).Product,
                         Quantity=1,
                         TotalAmount=0,
                       }
                       ,
                        new  InvoiceLines
                       {
                         DiscountAmount=0,
                         LineNo=1,
                         NetAmount=0,
                         Price=0,
                         Product= Invoice0.InvoiceLines.Single(x=>x.LineNo==1).Product,
                         Quantity=1,
                         TotalAmount=0,
                       }

                       },
                };


                app.Invoices.Add(Invoice0);
                app.Invoices.Add(Invoice1);
                app.Invoices.Add(Invoice2);
                await app.SaveChanges();
            }



        }


    }
}
