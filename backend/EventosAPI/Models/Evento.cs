namespace EventosAPI.Models
{
    /// <summary>
    /// Representa um evento acadêmico de TI.
    /// </summary>
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; } = string.Empty;

        /// <summary>
        /// Indica se o evento oferece suporte geral a Libras.
        /// Disciplina: Libras.
        /// </summary>
        public bool SuporteLibras { get; set; }

        /// <summary>
        /// Informações de contato da comissão organizadora.
        /// Disciplina: Comunicação, Liderança e Negociação.
        /// </summary>
        public string EmailContato { get; set; } = string.Empty;

        /// <summary>
        /// Verifica se o evento está em andamento na data atual.
        /// </summary>
        public bool EstaEmAndamento()
        {
            var hoje = DateTime.Now.Date;
            return hoje >= DataInicio.Date && hoje <= DataFim.Date;
        }

        /// <summary>
        /// Verifica se as inscrições ainda estão abertas (até a data de início).
        /// </summary>
        public bool InscricoesAbertas()
        {
            return DateTime.Now.Date <= DataInicio.Date;
        }
    }
}
