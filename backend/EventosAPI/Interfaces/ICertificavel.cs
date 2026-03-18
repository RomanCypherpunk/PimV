using EventosAPI.Models;

namespace EventosAPI.Interfaces
{
    /// <summary>
    /// Interface que define o contrato para geração de certificados.
    /// Entidades que podem gerar certificados implementam esta interface.
    /// </summary>
    public interface ICertificavel
    {
        Certificado GerarCertificado(int inscricaoId);
        Certificado? ValidarCertificado(string codigoValidacao);
    }
}
