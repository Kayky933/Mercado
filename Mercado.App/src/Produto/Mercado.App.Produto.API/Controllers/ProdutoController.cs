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
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoDbContext _context;
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(ProdutoDbContext context, IMapper mapper, IProdutoService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoModel(int id)
        {
            var produtoModel = await _context.Produtos.FindAsync(id);

            if (produtoModel == null)
            {
                return NotFound();
            }

            return produtoModel;
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoModel(int id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<dynamic> PostProdutoModel(ProdutoViewModel produtoModel)
        {
            var newProd = _mapper.Map<ProdutoModel>(produtoModel);
            return await _service.CreateProduct(newProd);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoModel(int id)
        {
            var produtoModel = await _context.Produtos.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoModelExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
