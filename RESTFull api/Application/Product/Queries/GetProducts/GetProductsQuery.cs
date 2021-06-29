using System;
using System.Collections.Generic;
using MediatR;

namespace Application
{
    public class GetProductsQuary : IRequest<IEnumerable<ProductViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
