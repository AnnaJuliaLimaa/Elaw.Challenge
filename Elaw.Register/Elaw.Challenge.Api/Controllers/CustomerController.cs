using Microsoft.AspNetCore.Mvc;
using Elaw.Challenge.Application;


namespace Elaw.Challenge.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _application;
        private readonly ILogger<CustomerController> logger;

        public CustomerController(ICustomerApplication application, ILogger<CustomerController> logger)
        {
            this.logger = logger;
            _application = application;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _application.Get();

            logger.LogInformation("Listing customer: {@Model}", customers);

            return Ok(customers);
        }
    }
}