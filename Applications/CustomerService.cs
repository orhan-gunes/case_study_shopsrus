using shopsruscase.Domain.Interfaces;


namespace shopsruscase.Applications
{
    public interface ICustomerService:IScopedDependency 
    {
        string getdeneme();
    }
    public class CustomerService : ICustomerService
    {
        public string getdeneme()
        {
            return "deneme";
        }
    }
}
