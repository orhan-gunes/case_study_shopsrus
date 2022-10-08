using Microsoft.AspNetCore.Mvc;
using shopsruscase.Applications;

namespace shopsruscase.api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService customerService;
        public HomeController(ICustomerService _customerService)
        {
                customerService = _customerService; 
        }

        [HttpGet("GetUserName")]
        public Task<string> GetUserName() 
        {
            return Task.FromResult(customerService.getdeneme());
        }
    }
}
