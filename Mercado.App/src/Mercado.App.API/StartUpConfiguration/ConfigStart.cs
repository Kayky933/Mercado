using Mercado.App.API.Interfaces.Service;
using Mercado.App.API.Mapper;
using Mercado.App.API.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Mercado.App.API.StartUpConfiguration
{
    public class ConfigStart
    {
        public static void SwaggerConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mercadinho.Prateleira.API",
                    Description = "API CRUD para gestão de prateleira do Mercadinho",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Kayky Matos Santana",
                        Email = "kayky7277@gmail.com",
                        Url = new Uri("https://github.com/Kayky933"),
                    }
                });
            });
        }

        public static void ConfigInterfaces(IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IVendaService, VendaService>();
        }
        public static void ConfigAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperClass));
        }
        public static void ConfigCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", config =>
                     config.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .Build()
                );
            });
        }
    }
}
