using Microsoft.AspNetCore.Mvc;

namespace shopsruscase.api.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet("HealthCheck")]
        public DateTime HealthCheck()
        {
            return DateTime.Now;
        }
    }
}
