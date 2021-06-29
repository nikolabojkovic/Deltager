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
        public async Task<IEnumerable<ContainerViewModel>> GetAll()
        {
            var result = await MediatR.Send(new GetContainersQuary());

            return result;
        }
    }
}
