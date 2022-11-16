using Cooper.Core.Entities.Generic;

namespace Cooper.Application.Generic.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class, IBaseEntity
    {
        IQueryable<TEntity> Query();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task Delete(int id);
    }
}
