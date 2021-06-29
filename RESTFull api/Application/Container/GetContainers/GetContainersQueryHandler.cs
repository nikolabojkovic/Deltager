using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Application
{
    class GetContainersQuaryHandler : IRequestHandler<GetContainersQuary, IEnumerable<ContainerViewModel>>
    {
        private readonly ISqlDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMapper _mapper;

        public GetContainersQuaryHandler(IDateTimeProvider dateTimeProvider, IMapper mapper, ISqlDbContext dbContext)
        {
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ContainerViewModel>> Handle(GetContainersQuary request, CancellationToken cancellationToken)
        {
            // TODO: Add paging
            var containers = await _dbContext.Containers.ToListAsync();
            var response = _mapper.Map<IEnumerable<ContainerViewModel>>(containers);

            return response;
        }
    }
}
