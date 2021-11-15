using Mercado.App.entity.Infrastructure.Data.Repository;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mercado.App.Produto.Infrastructure.Data.ConectionData
{
    public static class DatabaseConnection
    {
        public static IServiceCollection AddConnectionDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProdutoDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("Sql_Connection")));

            services.AddScoped(typeof(IProdutoRepository), typeof(ProdutoRepository));
            return services;

        }

    }
}
