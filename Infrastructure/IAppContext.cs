
using Microsoft.EntityFrameworkCore;
using shopsruscase.Domain.Entityes;

namespace shopsruscase.Infrastructure
{
    public interface IAppDbContext
    {
        DbSet<CustomerAdress> CustomerAdresses { get; set; }
        DbSet<Customers> Customers { get; set; }
        DbSet<Invoices> Invoices { get; set; }
        DbSet<InvoiceLines> InvoiceLines { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<Users> Users { get; set; }

        Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken());
    }
}
