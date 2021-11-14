using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mercado.App.entity.Infrastructure.Data.Repository
{
    public class ProdutoRepository<TEntity> : IProdutoRepository<TEntity>, IAsyncDisposable where TEntity : class
    {
        private readonly ProdutoDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entityEntry = await _context.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            return entityEntry.Entity;
        }
        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default) =>
           await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        public void Delete(TEntity entity) => _context.Entry(entity).State = EntityState.Deleted;

        public async ValueTask DisposeAsync() =>
             await _context.DisposeAsync().ConfigureAwait(false);

        public IEnumerable<object> GetAllByCategory(int id)
        {
            return _context.Produtos.Where(x => x.CategoriaId == id).OrderBy(x=>x.CategoriaId).Select(x => new { x.Descricao, x.Categoria, x.Informacoes_Produto}).ToList();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "", bool noTracking = false, int? take = null,
          int? skip = null)
        {
            IQueryable<TEntity> query = this._dbSet;

            if (noTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query.Take(take.Value);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false,
            int? take = null,
            int? skip = null,
            CancellationToken cancellationToken = default) =>
                await GetAll(filter, orderBy, includeProperties, noTracking, take, skip)
                    .ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task<ProdutoModel> GetOneById(int id)
        {
            return await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(TEntity entity) =>
            _context.Entry(entity).State = EntityState.Modified;
    }
}
