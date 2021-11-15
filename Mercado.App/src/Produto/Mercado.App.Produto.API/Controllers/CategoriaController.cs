using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Controllers
{
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ProdutoDbContext _context;

        public CategoriaController(ProdutoDbContext context)
        {
            _context = context;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> GetCategoriaModel(int id)
        {
            var categoriaModel = await _context.Categorias.FindAsync(id);

            if (categoriaModel == null)
            {
                return NotFound();
            }

            return categoriaModel;
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaModel(int id, CategoriaModel categoriaModel)
        {
            if (id != categoriaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaModelExists(id))
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

        // POST: api/Categoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaModel>> PostCategoriaModel(CategoriaModel categoriaModel)
        {
            _context.Categorias.Add(categoriaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaModel", new { id = categoriaModel.Id }, categoriaModel);
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaModel(int id)
        {
            var categoriaModel = await _context.Categorias.FindAsync(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoriaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaModelExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
