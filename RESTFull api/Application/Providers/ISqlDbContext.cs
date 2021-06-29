using System;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;

namespace Application
{
    public interface ISqlDbContext
    {
        DbSet<Container> Containers { get; set; }
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();

    }
}