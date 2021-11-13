using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.Repository
{
    public class ProdutoRepository<TEntity> : IProdutoRepository<TEntity> where TEntity:class
    {
    }
}
