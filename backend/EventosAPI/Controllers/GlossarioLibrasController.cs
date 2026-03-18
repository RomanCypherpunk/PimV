using Microsoft.AspNetCore.Mvc;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    /// <summary>
    /// Controller do glossário de Libras.
    /// Disciplina: Língua Brasileira de Sinais – Libras.
    /// </summary>
    [ApiController]
    [Route("api/glossario-libras")]
    public class GlossarioLibrasController : ControllerBase
    {
        private readonly TermoLibrasService _service;

        public GlossarioLibrasController(TermoLibrasService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<TermoLibras>> Listar(
            [FromQuery] string? busca,
            [FromQuery] string? categoria)
        {
            if (!string.IsNullOrEmpty(busca))
                return Ok(_service.Buscar(busca));

            if (!string.IsNullOrEmpty(categoria))
                return Ok(_service.BuscarPorCategoria(categoria));

            return Ok(_service.LerTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<TermoLibras> BuscarPorId(int id)
        {
            var termo = _service.BuscarPorId(id);
            if (termo == null)
                return NotFound(new { mensagem = $"Termo com Id {id} não encontrado." });
            return Ok(termo);
        }

        [HttpGet("categorias")]
        public ActionResult<List<string>> ListarCategorias()
        {
            return Ok(_service.ListarCategorias());
        }

        [HttpPost]
        public ActionResult<TermoLibras> Criar([FromBody] TermoLibras termo)
        {
            try
            {
                _service.Salvar(termo);
                return CreatedAtAction(nameof(BuscarPorId), new { id = termo.Id }, termo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
