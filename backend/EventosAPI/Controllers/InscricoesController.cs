using Microsoft.AspNetCore.Mvc;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricoesController : ControllerBase
    {
        private readonly InscricaoService _service;

        public InscricoesController(InscricaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Inscricao>> Listar(
            [FromQuery] string? cpf,
            [FromQuery] int? atividadeId)
        {
            if (!string.IsNullOrEmpty(cpf))
                return Ok(_service.BuscarPorCpf(cpf));

            if (atividadeId.HasValue)
                return Ok(_service.BuscarPorAtividade(atividadeId.Value));

            return Ok(_service.LerTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Inscricao> BuscarPorId(int id)
        {
            var inscricao = _service.BuscarPorId(id);
            if (inscricao == null)
                return NotFound(new { mensagem = $"Inscrição com Id {id} não encontrada." });
            return Ok(inscricao);
        }

        /// <summary>
        /// Endpoint de inscrição. Gera notificação automática de confirmação.
        /// </summary>
        [HttpPost]
        public ActionResult<Inscricao> Criar([FromBody] Inscricao inscricao)
        {
            try
            {
                var resultado = _service.Salvar(inscricao);
                return CreatedAtAction(nameof(BuscarPorId), new { id = resultado.Id }, resultado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Cancela uma inscrição e libera a vaga na atividade.
        /// </summary>
        [HttpPatch("{id}/cancelar")]
        public ActionResult Cancelar(int id)
        {
            try
            {
                _service.CancelarInscricao(id);
                return Ok(new { mensagem = "Inscrição cancelada com sucesso." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Conclui uma inscrição (participante compareceu à atividade).
        /// </summary>
        [HttpPatch("{id}/concluir")]
        public ActionResult Concluir(int id)
        {
            try
            {
                var inscricao = _service.BuscarPorId(id)
                    ?? throw new KeyNotFoundException("Inscrição não encontrada.");

                inscricao.Concluir();
                _service.Atualizar(inscricao);
                return Ok(new { mensagem = "Inscrição concluída com sucesso." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Retorna quantas inscrições solicitaram Libras para uma atividade.
        /// Disciplina: Libras — relatório de demanda.
        /// </summary>
        [HttpGet("demanda-libras/{atividadeId}")]
        public ActionResult ContarDemandaLibras(int atividadeId)
        {
            var quantidade = _service.ContarSolicitacoesLibras(atividadeId);
            return Ok(new { atividadeId, solicitacoesLibras = quantidade });
        }
    }
}
