using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application;

namespace WebApi
{
    public class ContainersController : BaseController
    {
        private readonly ILogger<ContainersController> _logger;

        public ContainersController(ILogger<ContainersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ContainerViewModel), 200)]
        public async Task<IEnumerable<ContainerViewModel>> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = await MediatR.Send(new GetContainersQuary 
            { 
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return result;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IActionResult), 204)]
        public async Task<IActionResult> Post(int id, [FromBody] UpdateContainerCommand command)
        {
            command.ContainerId = id;
            await MediatR.Send(command);

            return NoContent();
        }
    }
}
