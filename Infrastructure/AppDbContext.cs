using shopsruscase.Domain;
using shopsruscase.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace shopsruscase.Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
       
     
 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public  async Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken())
        {
            return await SaveChangesAsync();
        }
      
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
      
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory().Replace("Infrastructure", "shopsrus-case-api"), "appsettings.json"))
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            string connectionString = config[$"ConnectionStrings:Default"];
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new AppDbContext(builder.Options);
        }
    }
}
