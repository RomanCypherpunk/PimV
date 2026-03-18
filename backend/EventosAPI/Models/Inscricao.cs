using EventosAPI.Enums;

namespace EventosAPI.Models
{
    /// <summary>
    /// Representa a inscrição de um participante em uma atividade.
    /// </summary>
    public class Inscricao
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public int AtividadeId { get; set; }
        public DateTime DataInscricao { get; set; } = DateTime.Now;
        public StatusInscricao Status { get; set; } = StatusInscricao.Confirmada;

        /// <summary>
        /// Indica se o participante solicitou intérprete de Libras para esta atividade.
        /// Disciplina: Libras.
        /// </summary>
        public bool SolicitouInterpreteLibras { get; set; }

        /// <summary>
        /// Verifica se a inscrição está ativa (não cancelada).
        /// </summary>
        public bool EstaAtiva()
        {
            return Status != StatusInscricao.Cancelada;
        }

        /// <summary>
        /// Cancela a inscrição alterando o status.
        /// </summary>
        public void Cancelar()
        {
            if (Status == StatusInscricao.Cancelada)
                throw new InvalidOperationException("Inscrição já está cancelada.");
            Status = StatusInscricao.Cancelada;
        }

        /// <summary>
        /// Marca a inscrição como concluída (participou da atividade).
        /// </summary>
        public void Concluir()
        {
            if (Status == StatusInscricao.Cancelada)
                throw new InvalidOperationException("Não é possível concluir uma inscrição cancelada.");
            Status = StatusInscricao.Concluida;
        }
    }
}
