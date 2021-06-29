using System.Collections.Generic;
using MediatR;

namespace Application
{
    public class GetContainersQuary : IRequest<IEnumerable<ContainerViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
