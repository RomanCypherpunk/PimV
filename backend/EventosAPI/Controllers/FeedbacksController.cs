using Microsoft.AspNetCore.Mvc;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    /// <summary>
    /// Controller de feedbacks.
    /// Disciplina: Comunicação, Liderança e Negociação.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbackService _service;

        public FeedbacksController(FeedbackService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Feedback>> Listar([FromQuery] int? atividadeId)
        {
            if (atividadeId.HasValue)
                return Ok(_service.BuscarPorAtividade(atividadeId.Value));

            return Ok(_service.LerTodos());
        }

        [HttpGet("media/{atividadeId}")]
        public ActionResult Media(int atividadeId)
        {
            var media = _service.CalcularMediaAtividade(atividadeId);
            return Ok(new { atividadeId, mediaNotas = media });
        }

        [HttpGet("relatorio")]
        public ActionResult Relatorio()
        {
            return Ok(_service.GerarRelatorio());
        }

        [HttpPost]
        public ActionResult<Feedback> Criar([FromBody] Feedback feedback)
        {
            try
            {
                _service.Salvar(feedback);
                return CreatedAtAction(nameof(Listar), new { atividadeId = feedback.AtividadeId }, feedback);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
        }
    }
}
