using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Controllers
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
        // GET: api/Produto
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutos()
        {
            return Ok(await _service.GetAllProducts());
        }

        [HttpGet("GetAllProductsCode")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutosId()
        {
            return Ok(await _service.GetAllProductsWithId());
        }

        [HttpGet("GetByCategory")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetByCategory(int id)
        {
            return Ok(await _service.GettAllProductBycategory(id));
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoModel(int id)
        {
            return await _service.GetOneProductById(id);
        }
        #endregion

        #region Post, put, delet
        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<dynamic> PostProdutoModel(ProdutoViewModel produtoModel)
        {
            var produtoNovo = await _service.CreateProduct(produtoModel);
            return produtoNovo.GetType() == typeof(ProdutoModel) ? Ok(produtoNovo) : BadRequest(produtoNovo);
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<dynamic> PutProdutoModel(int id, ProdutoViewModel produtoModel)
        {
            var produtoModificado = await _service.PutProduct(id, produtoModel);
            var verificationProd = _service.GetOneProductById(id);

            if (verificationProd == null)
                return NotFound("Produto não encontrado!");

            return produtoModificado.GetType() == typeof(ProdutoModel) ? Ok(produtoModificado) : BadRequest(produtoModificado);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<dynamic> DeleteProdutoModel(int id)
        {
            return await _service.DeletProduct(id);
        }
        #endregion
    }
}
