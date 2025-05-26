using Microsoft.AspNetCore.Mvc;
using Elaw.Challenge.Application;


namespace Elaw.Challenge.Api.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/clientes")]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _application;
        private readonly ILogger<CustomerController> logger;

        public CustomerController(ICustomerApplication application, ILogger<CustomerController> logger)
        {
            this.logger = logger;
            _application = application;
        }

        [HttpGet, MapToApiVersion("1.0")]
        public IActionResult Index()
        {
            var customers = _application.Get();

            logger.LogInformation("Listing customer: {@Model}", customers);

            return Ok(customers);
        }
    }
}