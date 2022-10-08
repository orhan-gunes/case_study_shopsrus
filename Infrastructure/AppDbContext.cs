using shopsruscase.Domain;
using shopsruscase.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace shopsruscase.Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {

        public DbSet<CustomerAdress> CustomerAdresses { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<InvoiceLines> InvoiceLines { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomerAdress>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Customers>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Products>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Users>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<InvoiceLines>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Invoices>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }


        public async Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken())
        {
            return await SaveChangesAsync();
        }

    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory().Replace("Infrastructure", "shopsruscase.api"), "appsettings.json"))
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            string connectionString = config[$"ConnectionStrings:Default"];
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new AppDbContext(builder.Options);
        }
    }
}
