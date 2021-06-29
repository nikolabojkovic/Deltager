using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Linq;

namespace Application
{
    class GetContainersQuaryHandler : IRequestHandler<GetContainersQuary, IEnumerable<ContainerViewModel>>
    {
        private readonly IDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMapper _mapper;

        public GetContainersQuaryHandler(IDateTimeProvider dateTimeProvider, IMapper mapper, IDbContext dbContext)
        {
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ContainerViewModel>> Handle(GetContainersQuary request, CancellationToken cancellationToken)
        {
            // TODO: Add paging
            var containers = await _dbContext.Containers
                                             .Include(x => x.Products)
                                                .ThenInclude(x => x.Product)
                                             .Skip((request.PageNumber - 1) * request.PageSize)
                                             .Take(request.PageSize)
                                             .ToListAsync();
            var response = _mapper.Map<IEnumerable<ContainerViewModel>>(containers);

            return response;
        }
    }
}
