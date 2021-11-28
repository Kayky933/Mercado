using Mercado.App.API.Interfaces.Service;
using Mercado.App.Domain.Models.Prateleira;
using Mercado.App.Domain.Models.Prateleira.PrateleiraViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.API.Controllers
{
    [Route("api/Podutos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        #region Gets
        [HttpGet("GetDescription")]
        public async Task<ActionResult<ProdutoModel>> GetDescription(string description)
        {
            return Ok(await _service.GetByDescriptionProduct(description));
        }

        // GET: api/Produto
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutos()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("GetAllProductsWithCode")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutosId()
        {
            return Ok(await _service.GetAllWithId());
        }

        [HttpGet("GetByCategory")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetByCategory(int id)
        {
            return Ok(await _service.GettAllProductsBycategory(id));
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoModel(int id)
        {
            return await _service.GetOneById(id);
        }
        #endregion

        #region Post, put, delet
        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<dynamic> PostProdutoModel(ProdutoViewModel produtoModel)
        {
            var produtoNovo = await _service.CreateProduct(produtoModel);
            if (produtoNovo.GetType() == typeof(ProdutoModel))
                return Ok(produtoNovo);
            return BadRequest(produtoNovo);
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<dynamic> PutProdutoModel(int id, ProdutoViewModel produtoModel)
        {
            var produtoModificado = await _service.PutProduct(id, produtoModel);
            var verificationProd = _service.GetOneById(id);

            if (verificationProd == null)
                return NotFound("Produto não encontrado!");

            if (produtoModificado.GetType() == typeof(ProdutoModel))
                return Ok(produtoModificado);

            return BadRequest(produtoModificado);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<dynamic> DeleteProdutoModel(int id)
        {
            return await _service.Delet(id);
        }

        #endregion
    }
}
