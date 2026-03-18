namespace EventosAPI.Models
{
    /// <summary>
    /// Feedback do participante sobre uma atividade.
    /// Disciplina: Comunicação, Liderança e Negociação.
    /// Mecanismo de retorno que permite ajustar o evento de forma transparente.
    /// </summary>
    public class Feedback
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public int AtividadeId { get; set; }

        private int _nota;

        /// <summary>
        /// Nota de 1 a 5. Encapsulamento com validação.
        /// </summary>
        public int Nota
        {
            get => _nota;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentException("Nota deve ser entre 1 e 5.");
                _nota = value;
            }
        }

        public string Comentario { get; set; } = string.Empty;

        /// <summary>
        /// Sugestão de melhoria (canal direto de comunicação participante → comissão).
        /// </summary>
        public string Sugestao { get; set; } = string.Empty;

        public DateTime DataEnvio { get; set; } = DateTime.Now;
    }
}
