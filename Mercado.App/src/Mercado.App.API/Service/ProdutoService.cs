using AutoMapper;
using Mercado.App.API.Interfaces.Service;
using Mercado.App.Domain.Models.Prateleira;
using Mercado.App.Domain.Models.Prateleira.PrateleiraViewModels;
using Mercado.App.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Validation.ValidationFunctions;
using Mercado.App.Validation.ValidationProject.ValidationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.API.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Post, Put, Delet
        public async Task<object> CreateProduct(ProdutoViewModel produto)
        {
            var prodMap = _mapper.Map<ProdutoModel>(produto);
            var validation = await new ProdutoModelValidation().ValidateAsync(prodMap);

            if (!validation.IsValid)
                return ErrorFunctions.MostrarErros(validation);

            _repository.Create(prodMap);
            return prodMap;
        }
        public async Task<object> PutProduct(int id, ProdutoViewModel produto)
        {
            var putObject = _mapper.Map<ProdutoModel>(produto);
            var validation = await new ProdutoModelValidation().ValidateAsync(putObject);

            if (!validation.IsValid)
                return ErrorFunctions.MostrarErros(validation);

            putObject.Id = id;
            _repository.Update(putObject);
            return putObject;
        }
        public async Task<object> Delet(int id)
        {
            var produto = await _repository.GetOneById(id);
            if (produto == null)
                return "Produto inexistente!";

            _repository.Delete(produto);
            return "Produto deletado com sucesso!";
        }
        #endregion

        #region Gets
        public async Task<IEnumerable<ProdutoModel>> GetAllWithId()
        {
            return await _repository.GetAllWithId();
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<object>> GettAllProductsBycategory(int id)
        {
            return await _repository.GetAllByCategory(id);
        }

        public async Task<ProdutoModel> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<ProdutoModel> GetByDescriptionProduct(string description)
        {
            return await _repository.GetByDescriptionProduct(description);
        }

        #endregion

    }
}
