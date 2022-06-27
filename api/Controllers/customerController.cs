using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace challengeAPI
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private CustomerDBHandler dbHandler = new CustomerDBHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/customers")]
        public IEnumerable<Customer> Get()
        {
            return dbHandler.GetAllCustomers();
        }
    }
}