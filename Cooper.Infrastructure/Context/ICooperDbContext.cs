using Cooper.Core.Entities.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cooper.Infrastructure.Context
{
    public interface ICooperDbContext : IDisposable
    {
        DbSet<T> GetDbSet<T>() where T : class, IBaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
