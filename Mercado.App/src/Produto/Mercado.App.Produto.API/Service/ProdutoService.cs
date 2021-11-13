using FluentValidation.Results;
using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ValidationResult> CreateProduct(ProdutoModel produto)
        {
            _repository.CreateProduct(produto);
            return null;
        }

        public async Task<ValidationResult> DeletProduct(int id)
        {
            var produto = await _repository.GetOneProductById(id);
            _repository.DeletProduct(produto);
            return null;
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }

        public async Task<ProdutoModel> GetOneProductById(int id)
        {
            return await _repository.GetOneProductById(id);
        }

        public async Task<IEnumerable<ProdutoModel>> GettAllProductBycategory(int id)
        {
            return await _repository.GettAllProductBycategory(id);
        }

        public async Task<ValidationResult> PutProduct(int id, ProdutoModel produto)
        {
            _repository.PutProduct(produto);
            return null;
        }
    }
}
