using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application;

namespace WebApi
{
    public class ProductsController : BaseController
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductViewModel), 200)]
        public async Task<IEnumerable<ProductViewModel>> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = await MediatR.Send(new GetProductsQuary 
            { 
                PageNumber = pageNumber,
                PageSize = pageSize
            });
            
            return result;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 201)]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            var result = await MediatR.Send(command);

            return Created("Products", result);
        }
    }
}
