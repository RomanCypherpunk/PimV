using Microsoft.AspNetCore.Mvc;
using EventosAPI.Models;
using EventosAPI.Services;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificadosController : ControllerBase
    {
        private readonly CertificadoService _service;

        public CertificadosController(CertificadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Certificado>> Listar([FromQuery] string? cpf)
        {
            if (!string.IsNullOrEmpty(cpf))
                return Ok(_service.BuscarPorCpf(cpf));

            return Ok(_service.LerTodos());
        }

        /// <summary>
        /// Gera certificado para uma inscrição concluída.
        /// </summary>
        [HttpPost("gerar")]
        public ActionResult<Certificado> Gerar([FromBody] GerarCertificadoRequest request)
        {
            try
            {
                var certificado = _service.GerarCertificado(request.InscricaoId);
                return Ok(certificado);
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
        /// Valida autenticidade de um certificado pelo código.
        /// </summary>
        [HttpGet("validar/{codigo}")]
        public ActionResult Validar(string codigo)
        {
            try
            {
                var certificado = _service.ValidarCertificado(codigo);
                if (certificado == null)
                    return NotFound(new { valido = false, mensagem = "Certificado não encontrado." });

                return Ok(new
                {
                    valido = true,
                    certificado.CodigoValidacao,
                    certificado.NomeParticipante,
                    certificado.TituloAtividade,
                    certificado.NomeEvento,
                    certificado.CargaHoraria,
                    dataEmissao = certificado.DataEmissao.ToString("dd/MM/yyyy")
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }

    /// <summary>
    /// DTO para requisição de geração de certificado.
    /// </summary>
    public class GerarCertificadoRequest
    {
        public int InscricaoId { get; set; }
    }
}
