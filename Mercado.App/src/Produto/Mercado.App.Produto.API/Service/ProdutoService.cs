﻿using AutoMapper;
using FluentValidation.Results;
using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;
using Mercado.App.Produto.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Produto.Validation.Validation.ValidationModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Service
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
                return MostrarErros(validation);

            _repository.Create(prodMap);
            return prodMap;


        }
        public async Task<object> PutProduct(int id, ProdutoViewModel produto)
        {
            var putObject = _mapper.Map<ProdutoModel>(produto);
            var validation = await new ProdutoModelValidation().ValidateAsync(putObject);

            if (!validation.IsValid)
                return MostrarErros(validation);

            putObject.Id = id;
            _repository.Update(putObject);
            return putObject;

        }
        public async Task<bool> DeletProduct(int id)
        {
            var produto = await _repository.GetOneById(id);
            if (produto == null)
                return false;

            _repository.Delete(produto);
            return true;
        }

        #endregion

        #region Gets
        public async Task<IEnumerable<ProdutoModel>> GetAllProductsWithId()
        {
            return await _repository.GetAllProdWithId();
        }

        public async Task<IEnumerable<object>> GetAllProducts()
        {
            return await _repository.GetAll();
        }
        public async Task<IEnumerable<ProdutoModel>> GetAllProdWithId()
        {
            return await _repository.GetAllProdWithId();
        }
        public async Task<ProdutoModel> GetOneProductById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<IEnumerable<object>> GettAllProductBycategory(int id)
        {
            return await _repository.GetOneByCategoey(id);
        }
        #endregion

        public object MostrarErros(ValidationResult res)
        {
            return res.Errors.Select(a => a.ErrorMessage).ToList();
        }
    }
}
