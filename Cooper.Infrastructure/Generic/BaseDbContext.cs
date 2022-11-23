using Cooper.Core.Entities.Generic;
using Cooper.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Cooper.Infrastructure.Generic
{
    public class BaseDbContext : DbContext
    {
        protected BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        private void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        if (entry.Entity.Id > 0)
                        {
                            entry.State = EntityState.Modified;
                        }

                        entry.Entity.Deleted = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Deleted = true;
                        break;
                }
            }
        }
        private async Task<int> BeforeSaveAsync(Func<Task<int>> action)
        {
            SetAuditEntities();
            return await action.Invoke();
        }
        private int BeforeSave(Func<int> action)
        {
            SetAuditEntities();
            return action.Invoke();
        }
        public override int SaveChanges()
        {
            return BeforeSave(() => base.SaveChanges());
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return BeforeSave(() => base.SaveChanges(acceptAllChangesOnSuccess));
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await BeforeSaveAsync(() => base.SaveChangesAsync(cancellationToken));
        }

        public override ChangeTracker ChangeTracker => base.ChangeTracker;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }

    }
}
