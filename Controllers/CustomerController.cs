using EgeriaTaskBackend.Business.Customers;
using EgeriaTaskBackend.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgeriaTaskBackend.Controllers
{
    [Route("Get/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }


        [HttpGet("All")]
        public IActionResult GetCustomers()
        {
            var customers=_customerService.GetCustomers();
            return Ok(customers);
        }
    }
}
