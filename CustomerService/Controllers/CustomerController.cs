using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KeepNote.Controllers
{
    [ApiController]
    [Route("api/customer")] // Base route for UserController
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("register")]
        public IActionResult AddCustomer(Customer customer)
        {
            var addedCustomer = _customerService.AddCustomer(customer); 

            if (addedCustomer != null) 
            {
                return Created("", addedCustomer); // 201 Created
            }

            return Conflict(); // 409 Conflict
        }



        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            
            return Ok(_customerService.GetAllCustomers());
        }

    }
}
