using AutoMapper;
using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.ViewModels;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Controllers
{
    [Route("api/Podutos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;        

        public ProdutoController(ProdutoDbContext context, IProdutoService service)
        {
            _service = service;
        }

        // GET: api/Produto
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutos()
        {
            return Ok(await _service.GetAllProducts());
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoModel(int id)
        {
            return await _service.GetOneProductById(id);
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<dynamic> PutProdutoModel(int id, ProdutoModel produtoModel)
        {            
            return await _service.PutProduct(id, produtoModel);
        }

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<dynamic> PostProdutoModel(ProdutoViewModel produtoModel)
        {           
            var produtoNovo = await _service.CreateProduct(produtoModel);
            return produtoNovo.GetType() == typeof(ProdutoModel) ? Ok(produtoNovo) : BadRequest(produtoNovo); 
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<dynamic> DeleteProdutoModel(int id)
        {
            return _service.DeletProduct(id);
        }
    }
}
