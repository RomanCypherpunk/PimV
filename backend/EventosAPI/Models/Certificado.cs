namespace EventosAPI.Models
{
    /// <summary>
    /// Representa o certificado emitido a um participante.
    /// Implementa a interface ICertificavel.
    /// </summary>
    public class Certificado
    {
        public int Id { get; set; }
        public int InscricaoId { get; set; }
        public int ParticipanteId { get; set; }
        public int AtividadeId { get; set; }

        /// <summary>
        /// Código único de validação do certificado (formato: CERT-XXXXXXXX).
        /// </summary>
        public string CodigoValidacao { get; set; } = string.Empty;

        public string NomeParticipante { get; set; } = string.Empty;
        public string TituloAtividade { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
        public DateTime DataEmissao { get; set; } = DateTime.Now;
        public string NomeEvento { get; set; } = string.Empty;

        /// <summary>
        /// Gera um código de validação único para o certificado.
        /// </summary>
        public static string GerarCodigoValidacao()
        {
            return $"CERT-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }

        /// <summary>
        /// Valida se um código de certificado tem o formato correto.
        /// </summary>
        public static bool ValidarFormato(string codigo)
        {
            return !string.IsNullOrWhiteSpace(codigo)
                && codigo.StartsWith("CERT-")
                && codigo.Length == 13;
        }
    }
}
