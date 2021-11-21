using Mercado.App.Produto.API.Interfaces.Service;
using Mercado.App.Produto.Domain.Models.Prateleira;
using Mercado.App.Produto.Domain.Models.Prateleira.PrateleiraViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercado.App.Produto.API.Controllers
{
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        #region Gets
        [HttpGet("GetDescription")]
        public async Task<ActionResult<CategoriaModel>> GetDescription(string description)
        {
            var descricao = await _service.GetByDescriptionCategory(description);
            return descricao.GetType() != typeof(CategoriaModel) ? BadRequest(descricao) : Ok(descricao);
        }
        [HttpGet("GetAllCategoryWithCode")]
        public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetCategorysId()
        {
            return Ok(await _service.GetAllWithId());
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetCategorias()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> GetCategoriaModel(int id)
        {
            return Ok(await _service.GetOneById(id));
        }
        #endregion

        #region Post, put, delet
        // POST: api/Categoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaModel>> PostCategoriaModel(CategoriaViewModel categoriaModel)
        {
            var categoriaNovo = await _service.CreateCategory(categoriaModel);
            return categoriaNovo.GetType() == typeof(CategoriaModel) ? Ok(categoriaNovo) : BadRequest(categoriaNovo);
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaModel(int id, CategoriaViewModel categoriaModel)
        {
            var categoriaModificada = await _service.PutCategory(id, categoriaModel);
            var verificationCategory = _service.GetOneById(id);

            if (verificationCategory == null)
                return NotFound("Categoria não encontrada!");

            return categoriaModificada.GetType() == typeof(CategoriaModel) ? Ok(categoriaModificada) : BadRequest(categoriaModificada);
        }
        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<dynamic> DeleteCategoriaModel(int id)
        {
            var categoria = await _service.Delet(id);
            if (categoria.GetType() != typeof(CategoriaModel))
                return BadRequest(categoria);
            return Ok(categoria);
        }
        #endregion
    }
}
