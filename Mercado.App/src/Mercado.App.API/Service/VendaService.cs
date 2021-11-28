using AutoMapper;
using Mercado.App.API.Interfaces.Service;
using Mercado.App.Domain.Models.Venda;
using Mercado.App.Domain.Models.Venda.VendaViewModels;
using Mercado.App.Infrastructure.Data.Interfaces.Repository;
using Mercado.App.Validation.ValidationFunctions;
using Mercado.App.Validation.ValidationProject.ValidationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.API.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _repositoryProduct;
        private readonly IMapper _mapper;
        public VendaService(IVendaRepository repository, IMapper mapper, IProdutoRepository repositoryProduct)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryProduct = repositoryProduct;
        }

        public async Task<object> CreateVenda(VendaViewModel venda)
        {
            var vendaMap = _mapper.Map<VendaModel>(venda);
            var validation = await new VendaModelValidation().ValidateAsync(vendaMap);

            if (!validation.IsValid)
                return ErrorFunctions.MostrarErros(validation);

            var produto = await _repositoryProduct.GetOneById(vendaMap.IdProduto);
            vendaMap.ValorPago = vendaMap.Quantidade * produto.PrecoUnidade;
            _repository.Create(vendaMap);
            return vendaMap;
        }

        public async Task<object> Delet(int id)
        {
            var venda = await _repository.GetOneById(id);
            if (venda == null)
                return "Venda inexistente!";

            _repository.Delete(venda);
            return "Venda deletada com sucesso!";
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<VendaModel>> GetAllWithId()
        {
            return await _repository.GetAllWithId();
        }

        public async Task<VendaModel> GetOneById(int id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<object> PutVenda(int id, VendaViewModel venda)
        {
            var vendaMap = _mapper.Map<VendaModel>(venda);
            var validation = await new VendaModelValidation().ValidateAsync(vendaMap);

            if (!validation.IsValid)
                return ErrorFunctions.MostrarErros(validation);
            vendaMap.Id = id;
            var produto = await _repositoryProduct.GetOneById(vendaMap.IdProduto);
            vendaMap.ValorPago = vendaMap.Quantidade * produto.PrecoUnidade;

            _repository.Update(vendaMap);
            return vendaMap;
        }
    }
}
