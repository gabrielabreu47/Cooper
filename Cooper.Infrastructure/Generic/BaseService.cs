using AutoMapper;
using Cooper.Application.Generic.Interfaces;
using Cooper.Core.Entities.Generic;
using Cooper.Core.Extensions;
using Cooper.Infrastructure.Context;
using Cooper.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace Cooper.Infrastructure.Generic
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly ICooperDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(ICooperDbContext dbContext, IMapper mapper)
        {
            _dbSet = dbContext.GetDbSet<TEntity>();
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) throw new Exception(ErrorMessages.EntityNotFound.GetDescription());

            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsNoTrackingAsync(int id)
        {
            return await Query().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
