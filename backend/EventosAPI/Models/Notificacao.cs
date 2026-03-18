using EventosAPI.Enums;

namespace EventosAPI.Models
{
    /// <summary>
    /// Representa uma notificação enviada a um participante.
    /// Disciplina: Comunicação, Liderança e Negociação.
    /// Modela o fluxo de comunicação entre comissão e participantes.
    /// </summary>
    public class Notificacao
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public TipoNotificacao Tipo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; } = DateTime.Now;
        public bool Lida { get; set; } = false;

        /// <summary>
        /// Gera a mensagem de confirmação de inscrição.
        /// Template de comunicação usado pelo sistema.
        /// </summary>
        public static Notificacao CriarConfirmacaoInscricao(
            int participanteId, string nomeAtividade, DateTime dataAtividade)
        {
            return new Notificacao
            {
                ParticipanteId = participanteId,
                Tipo = TipoNotificacao.Confirmacao,
                Titulo = "Inscrição confirmada!",
                Mensagem = $"Sua inscrição na atividade \"{nomeAtividade}\" foi confirmada. " +
                           $"Data: {dataAtividade:dd/MM/yyyy HH:mm}. " +
                           "Fique atento às notificações para eventuais alterações na programação."
            };
        }

        /// <summary>
        /// Gera notificação de alteração de programação.
        /// </summary>
        public static Notificacao CriarAlteracaoProgramacao(
            int participanteId, string nomeAtividade, string detalhes)
        {
            return new Notificacao
            {
                ParticipanteId = participanteId,
                Tipo = TipoNotificacao.AlteracaoProgramacao,
                Titulo = "Alteração na programação",
                Mensagem = $"A atividade \"{nomeAtividade}\" sofreu alterações: {detalhes}. " +
                           "Pedimos desculpas pelo inconveniente. " +
                           "Em caso de dúvidas, entre em contato com a comissão organizadora."
            };
        }

        /// <summary>
        /// Gera notificação de cancelamento.
        /// </summary>
        public static Notificacao CriarCancelamento(
            int participanteId, string nomeAtividade, string motivo)
        {
            return new Notificacao
            {
                ParticipanteId = participanteId,
                Tipo = TipoNotificacao.Cancelamento,
                Titulo = "Atividade cancelada",
                Mensagem = $"Infelizmente a atividade \"{nomeAtividade}\" foi cancelada. " +
                           $"Motivo: {motivo}. " +
                           "Você pode se inscrever em outras atividades disponíveis na programação."
            };
        }

        /// <summary>
        /// Gera lembrete pré-evento.
        /// </summary>
        public static Notificacao CriarLembrete(
            int participanteId, string nomeAtividade, DateTime dataAtividade)
        {
            return new Notificacao
            {
                ParticipanteId = participanteId,
                Tipo = TipoNotificacao.Lembrete,
                Titulo = "Lembrete: atividade amanhã!",
                Mensagem = $"Olá! Lembramos que a atividade \"{nomeAtividade}\" acontecerá " +
                           $"em {dataAtividade:dd/MM/yyyy} às {dataAtividade:HH:mm}. " +
                           "Não se esqueça de participar!"
            };
        }
    }
}
