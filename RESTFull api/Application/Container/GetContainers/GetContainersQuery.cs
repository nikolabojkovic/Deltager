using System;
using System.Collections.Generic;
using MediatR;

namespace Application
{
    public class GetContainersQuary : IRequest<IEnumerable<ContainerViewModel>>
    {
    
    }
}
