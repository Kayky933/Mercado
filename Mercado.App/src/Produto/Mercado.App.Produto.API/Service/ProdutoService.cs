using FluentValidation.Results;
using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Validation.Validation.ValidationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository<ProdutoModel> _repository;
        public ProdutoService(IProdutoRepository<ProdutoModel> repository)
        {
            _repository = repository;
        }
        public async Task<string> CreateProduct(ProdutoModel produto)
        {
            var validation = await new ProdutoModelValidation().ValidateAsync(produto);
            if (validation.IsValid)
               await _repository.AddAsync(produto);

            return validation.Errors.Select(x => x.ErrorMessage).ToString();
        }
      
        public async Task<bool> DeletProduct(int id)
        {
            var produto = await _repository.GetOneById(id);
            if (produto == null)
                throw new Exception("Produto não encontrado");

            _repository.Delete(produto);
            return true;
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllProducts()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProdutoModel> GetOneProductById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<IEnumerable<object>> GettAllProductBycategory(int id)
        {
            return  _repository.GetAllByCategory(id);
        }

        public async Task<ValidationResult> PutProduct(int id, ProdutoModel produto)
        {
            var validation = await new ProdutoModelValidation().ValidateAsync(produto);
            if (validation.IsValid)
                _repository.Update(produto) ;

            return validation;
        }
    }
}
