
namespace shopsruscase.Infrastructure
{
    public interface IAppDbContext
    {
       
        Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken());
    }
}
