using Mercado.App.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Infrastructure.Data.ProdutoDatabase;
using Mercado.App.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mercado.App.Infrastructure.Data.ConectionData
{
    public static class DatabaseConnection
    {
        public static IServiceCollection AddConnectionDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProdutoDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("Sql_Connection")));

            services.AddScoped(typeof(IProdutoRepository), typeof(ProdutoRepository));
            services.AddScoped(typeof(ICategoriaRepository), typeof(CategoriaRepository));
            return services;

        }

    }
}
