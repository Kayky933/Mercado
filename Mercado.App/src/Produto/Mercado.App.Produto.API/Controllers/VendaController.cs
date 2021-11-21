using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mercado.App.Produto.Domain.Models.Venda;
using Mercado.App.Produto.Infrastructure.Data.ProdutoDatabase;

namespace Mercado.App.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly ProdutoDbContext _context;

        public VendaController(ProdutoDbContext context)
        {
            _context = context;
        }

        // GET: api/Venda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaModel>>> GetVendas()
        {
            return await _context.Vendas.ToListAsync();
        }

        // GET: api/Venda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendaModel>> GetVendaModel(int id)
        {
            var vendaModel = await _context.Vendas.FindAsync(id);

            if (vendaModel == null)
            {
                return NotFound();
            }

            return vendaModel;
        }

        // PUT: api/Venda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendaModel(int id, VendaModel vendaModel)
        {
            if (id != vendaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaModelExists(id))
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

        // POST: api/Venda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendaModel>> PostVendaModel(VendaModel vendaModel)
        {
            _context.Vendas.Add(vendaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendaModel", new { id = vendaModel.Id }, vendaModel);
        }

        // DELETE: api/Venda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendaModel(int id)
        {
            var vendaModel = await _context.Vendas.FindAsync(id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            _context.Vendas.Remove(vendaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaModelExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
