﻿using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity, TEntityId> : IQueryable<TEntity>
        where TEntity : Entity<TEntityId>
        //Entityden inherit edilmesi ve geliştirinin kafasına göre buraya domain nesnesi dışında başka bir şey yazmaması için sınırlandırıyoruz
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? inlude = null,
            bool withDleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);


        Task<IPaginate<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
            );

        Task<IPaginate<TEntity>> GetListByDynamicAsync(
            DynamicQuery dynamic,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
);

        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);


        Task<TEntity> AddAsync(TEntity entity);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entity);

        Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);

        Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entity, bool permanent = false);

    }
}