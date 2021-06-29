using System.Collections.Generic;
using MediatR;

namespace Application
{
    public class UpdateContainerCommand : IRequest
    {
        public int ContainerId { get; set; }
        public IEnumerable<int> ProductsToAdd { get; set; }
        public IEnumerable<int> ProductPackagesToRemove { get; set; }
    }
}
