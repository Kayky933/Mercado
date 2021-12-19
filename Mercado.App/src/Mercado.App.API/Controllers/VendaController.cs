using Mercado.App.API.Interfaces.Service;
using Mercado.App.Domain.Models.Venda;
using Mercado.App.Domain.Models.Venda.VendaViewModels;
using Mercado.App.Infrastructure.Data.ProdutoDatabase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendaController(ProdutoDbContext context, IVendaService service)
        {
            _service = service;
        }

        [HttpGet("GetAllWithCode")]
        public async Task<ActionResult<IEnumerable<VendaModel>>> GetAllWithCode()
        {
            return Ok(await _service.GetAllWithId());
        }

        // GET: api/Venda
        [HttpGet("GetAllVendas")]
        public async Task<ActionResult<IEnumerable<VendaModel>>> GetVendas()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/Venda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendaModel>> GetVendaModel(int id)
        {
            var venda = await _service.GetOneById(id);
            if (venda.GetType() != typeof(VendaModel))
                return NotFound("Venda não encontrado");
            return Ok(venda);
        }

        // PUT: api/Venda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<dynamic> PutVendaModel(int id, VendaViewModel vendaModel)
        {
            var venda = await _service.GetOneById(id);
            var vendaPut = await _service.PutVenda(id, vendaModel);
            if (venda == null)
                return NotFound("Venda não encontrado!");

            if (vendaPut.GetType() == typeof(VendaModel))
                return Ok(vendaPut);

            return BadRequest(vendaPut);
        }

        // POST: api/Venda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<dynamic>> PostVendaModel(VendaViewModel vendaModel)
        {
            var vendaCriada = await _service.CreateVenda(vendaModel);
            if (vendaCriada.GetType() == typeof(VendaModel))               
            return Ok(vendaCriada);

            return BadRequest(vendaCriada);
        }

        // DELETE: api/Venda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendaModel(int id)
        {
            var vendaModel = await _service.GetOneById(id);
            if (vendaModel == null)
            {
                return NotFound();
            }
            await _service.Delet(id);
            return NoContent();
        }

    }
}
