using Mercado.App.entity.Infrastructure.Data.Repository;
using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.API.Mapper;
using Mercado.App.Produto.API.Service;
using Mercado.App.Produto.API.StartUpConfiguration;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Mercado.App.Produto.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigStart.ConfigCors(services);
            ConfigStart.ConfigAutoMapper(services);

            services.AddDbContext<ProdutoDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("Sql_Connection")));

            ConfigStart.ConfigInterfaces(services);
            ConfigStart.SwaggerConfig(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prateleira API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
