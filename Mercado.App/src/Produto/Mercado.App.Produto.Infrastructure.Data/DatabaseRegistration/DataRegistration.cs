using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Mercado.App.Produto.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.App.Produto.Infrastructure.Data.DatabaseRegistration
{
    public static class DataRegsitration
    {
        public static IServiceCollection AddDataRegistration(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DbContext, ProdutoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Sql_Connection"));
            });
            services.AddScoped(typeof(IProdutoRepository<>), typeof(ProdutoRepository<>));
            return services;
        }
    }
}
