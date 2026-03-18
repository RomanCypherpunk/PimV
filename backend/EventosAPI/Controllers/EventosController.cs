using Microsoft.AspNetCore.Mvc;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly EventoService _service;

        public EventosController(EventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Evento>> Listar()
        {
            return Ok(_service.LerTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> BuscarPorId(int id)
        {
            var evento = _service.BuscarPorId(id);
            if (evento == null)
                return NotFound(new { mensagem = $"Evento com Id {id} não encontrado." });
            return Ok(evento);
        }

        [HttpPost]
        public ActionResult<Evento> Criar([FromBody] Evento evento)
        {
            try
            {
                _service.Salvar(evento);
                return CreatedAtAction(nameof(BuscarPorId), new { id = evento.Id }, evento);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, [FromBody] Evento evento)
        {
            try
            {
                evento.Id = id;
                _service.Atualizar(evento);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
