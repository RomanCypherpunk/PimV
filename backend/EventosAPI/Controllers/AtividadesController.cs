using Microsoft.AspNetCore.Mvc;
using EventosAPI.Enums;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadesController : ControllerBase
    {
        private readonly AtividadeService _service;

        public AtividadesController(AtividadeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista atividades com filtros opcionais: eventoId, tipo, libras, data.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Atividade>> Listar(
            [FromQuery] int? eventoId,
            [FromQuery] string? tipo,
            [FromQuery] bool? libras,
            [FromQuery] DateTime? data)
        {
            var atividades = _service.LerTodos();

            // Filtros LINQ encadeados
            if (eventoId.HasValue)
                atividades = atividades.Where(a => a.EventoId == eventoId.Value).ToList();

            if (!string.IsNullOrEmpty(tipo) && Enum.TryParse<TipoAtividade>(tipo, true, out var tipoEnum))
                atividades = atividades.Where(a => a.Tipo == tipoEnum).ToList();

            if (libras == true)
                atividades = atividades.Where(a => a.TemInterpreteLibras).ToList();

            if (data.HasValue)
                atividades = atividades.Where(a => a.DataHora.Date == data.Value.Date).ToList();

            return Ok(atividades.OrderBy(a => a.DataHora).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Atividade> BuscarPorId(int id)
        {
            var atividade = _service.BuscarPorId(id);
            if (atividade == null)
                return NotFound(new { mensagem = $"Atividade com Id {id} não encontrada." });
            return Ok(atividade);
        }

        [HttpPost]
        public ActionResult<Atividade> Criar([FromBody] Atividade atividade)
        {
            try
            {
                _service.Salvar(atividade);
                return CreatedAtAction(nameof(BuscarPorId), new { id = atividade.Id }, atividade);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, [FromBody] Atividade atividade)
        {
            try
            {
                atividade.Id = id;
                _service.Atualizar(atividade);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
