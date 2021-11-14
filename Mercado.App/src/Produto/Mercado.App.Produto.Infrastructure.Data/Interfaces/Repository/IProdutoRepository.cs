using Mercado.App.Produto.Domain.Models.Prateleira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository
{
    public interface IProdutoRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<ProdutoModel> GetOneById(int id);
        public IEnumerable<object> GetAllByCategory(int id);
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null, int? skip = null);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null, int? skip = null,
            CancellationToken cancellationToken = default);
    }
}
