using Microsoft.AspNetCore.Mvc;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantesController : ControllerBase
    {
        private readonly ParticipanteService _service;

        public ParticipantesController(ParticipanteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Participante>> Listar([FromQuery] bool? necessitaLibras)
        {
            if (necessitaLibras == true)
                return Ok(_service.ListarComNecessidadeLibras());

            return Ok(_service.LerTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Participante> BuscarPorId(int id)
        {
            var participante = _service.BuscarPorId(id);
            if (participante == null)
                return NotFound(new { mensagem = $"Participante com Id {id} não encontrado." });
            return Ok(participante);
        }

        [HttpGet("cpf/{cpf}")]
        public ActionResult<Participante> BuscarPorCpf(string cpf)
        {
            var participante = _service.BuscarPorCpf(cpf);
            if (participante == null)
                return NotFound(new { mensagem = "Participante não encontrado com este CPF." });
            return Ok(participante);
        }

        [HttpPost]
        public ActionResult<Participante> Criar([FromBody] Participante participante)
        {
            try
            {
                _service.Salvar(participante);
                return CreatedAtAction(nameof(BuscarPorId), new { id = participante.Id }, participante);
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

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, [FromBody] Participante participante)
        {
            try
            {
                participante.Id = id;
                _service.Atualizar(participante);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
