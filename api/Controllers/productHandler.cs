using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace challengeAPI
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductDBHandler dbHandler = new ProductDBHandler();

        [HttpGet]
        [Route("/products")]
        public IEnumerable<Product> Get()
        {
            return dbHandler.GetAllProducts();
        }
    }
}