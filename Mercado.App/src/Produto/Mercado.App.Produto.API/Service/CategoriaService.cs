using AutoMapper;
using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Validation.Validation.ValidationModels;
using Mercado.App.Produto.Validation.ValidationFunctions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepository repository, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        #region Post, Put, Delet
        public async Task<object> CreateCategory(CategoriaViewModel produto)
        {
            var mappingModel = _mapper.Map<CategoriaModel>(produto);
            var validation = await new CategoriaModelValidation(_repository).ValidateAsync(mappingModel);
            if (!validation.IsValid)
                return ErrorFunctions.MostrarErros(validation);

            _repository.Create(mappingModel);
            return mappingModel;

        }
        public async Task<object> PutCategory(int id, CategoriaViewModel produto)
        {
            var mappingModel = _mapper.Map<CategoriaModel>(produto);
            var validation = await new CategoriaModelValidation(_repository).ValidateAsync(mappingModel);
            if (!validation.IsValid)
                return ErrorFunctions.MostrarErros(validation);

            mappingModel.Id = id;
            _repository.Update(mappingModel);
            return mappingModel;
        }
        public async Task<object> Delet(int id)
        {
            var category = await _repository.GetOneById(id);
            
            if (category == null)
                return "Categoria inexistente!";
            var produtoRelacionado = await _produtoRepository.CategoryExists(category.Id);
            if (produtoRelacionado)
                return "A catedoria selecionada para a exclusão tem produtos vinculados a ela!";

            _repository.Delete(category);
            return category;
        }
        public void DeletAll()
        {
            _repository.DeletAll();
        }
        #endregion

        #region Gets
        public async Task<IEnumerable<object>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<CategoriaModel>> GetAllWithId()
        {
            return await _repository.GetAllWithId();
        }

        public async Task<CategoriaModel> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<object> GetByDescriptionCategory(string description)
        {
            var descricao = await _repository.GetByDescriptionCategory(description);
            if (descricao == null)
                return "Categoria não encontrada!";
            return descricao;
        }

        
        #endregion
    }
}
