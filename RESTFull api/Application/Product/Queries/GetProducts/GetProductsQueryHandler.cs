using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application
{
    class GetProductsQuaryHandler : IRequestHandler<GetProductsQuary, IEnumerable<ProductViewModel>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductsQuaryHandler(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductsQuary request, CancellationToken cancellationToken)
        {
            // TODO: Add paging
            var products = await _dbContext.Products
                                           .Skip((request.PageNumber - 1) * request.PageSize)
                                           .Take(request.PageSize)
                                           .ToListAsync();
            var response = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            return response;
        }
    }
}
