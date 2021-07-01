using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application
{
      public class UpdateContainerCommandHandler : IRequestHandler<UpdateContainerCommand, Unit>
    {
        private readonly IDbContext _dbContext;

        public UpdateContainerCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateContainerCommand request, CancellationToken cancellationToken)
        {
            var container = await _dbContext.Containers
                                            .Include(x => x.Products)
                                            .SingleOrDefaultAsync(c => c.Id == request.ContainerId, cancellationToken);

            if (container == null)
                throw new NotFoundException(nameof(Container), request.ContainerId);

            var productsToRemove = container.Products.Where(x => request.ProductPackagesToRemove.Contains(x.Id));
            container.RemoveProducts(productsToRemove);

            var productsToAdd = await _dbContext.Products.Where(x => request.ProductsToAdd.Contains(x.Id))
                                                         .ToListAsync();

            // Support adding the same product to container multiple times
            productsToAdd = request.ProductsToAdd.Select(id => productsToAdd.Find(p => p.Id == id))
                                                 .ToList();

            container.AddProducts(productsToAdd);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}