namespace EventosAPI.Models
{
    /// <summary>
    /// Representa um termo do glossário de Libras para eventos de TI.
    /// Disciplina: Língua Brasileira de Sinais – Libras.
    /// </summary>
    public class TermoLibras
    {
        public int Id { get; set; }

        /// <summary>
        /// O termo em português (ex: "Certificado", "Palestra").
        /// </summary>
        public string TermoPortugues { get; set; } = string.Empty;

        /// <summary>
        /// Descrição textual de como o sinal é realizado em Libras.
        /// </summary>
        public string DescricaoSinal { get; set; } = string.Empty;

        /// <summary>
        /// Contexto de uso do termo dentro de eventos acadêmicos de TI.
        /// </summary>
        public string ContextoUso { get; set; } = string.Empty;

        /// <summary>
        /// Categoria do termo (ex: "Evento", "Documento", "Atividade").
        /// </summary>
        public string Categoria { get; set; } = string.Empty;

        /// <summary>
        /// URL do vídeo demonstrativo do sinal (placeholder/storyboard).
        /// </summary>
        public string VideoUrl { get; set; } = string.Empty;
    }
}
