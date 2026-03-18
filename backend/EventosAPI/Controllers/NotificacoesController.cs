using Microsoft.AspNetCore.Mvc;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    /// <summary>
    /// Controller de notificações.
    /// Disciplina: Comunicação, Liderança e Negociação.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacoesController : ControllerBase
    {
        private readonly NotificacaoService _service;

        public NotificacoesController(NotificacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Notificacao>> Listar([FromQuery] int? participanteId)
        {
            if (participanteId.HasValue)
                return Ok(_service.BuscarPorParticipante(participanteId.Value));

            return Ok(_service.LerTodos());
        }

        [HttpGet("nao-lidas/{participanteId}")]
        public ActionResult ContarNaoLidas(int participanteId)
        {
            var quantidade = _service.ContarNaoLidas(participanteId);
            return Ok(new { participanteId, naoLidas = quantidade });
        }

        [HttpPatch("{id}/lida")]
        public ActionResult MarcarComoLida(int id)
        {
            try
            {
                _service.MarcarComoLida(id);
                return Ok(new { mensagem = "Notificação marcada como lida." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
