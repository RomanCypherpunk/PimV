using EventosAPI.Enums;

namespace EventosAPI.Models
{
    /// <summary>
    /// Representa uma atividade dentro de um evento (palestra, minicurso, etc).
    /// </summary>
    public class Atividade
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TipoAtividade Tipo { get; set; }
        public string Palestrante { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public int DuracaoMinutos { get; set; }
        public int VagasTotal { get; set; }
        public int VagasOcupadas { get; set; }

        /// <summary>
        /// Indica se esta atividade terá intérprete de Libras.
        /// Disciplina: Libras — marcação no sistema para filtro e badge visual.
        /// </summary>
        public bool TemInterpreteLibras { get; set; }

        /// <summary>
        /// Local/sala específica da atividade.
        /// </summary>
        public string Sala { get; set; } = string.Empty;

        /// <summary>
        /// Calcula as vagas restantes usando propriedade derivada.
        /// </summary>
        public int VagasDisponiveis => VagasTotal - VagasOcupadas;

        /// <summary>
        /// Verifica se a atividade ainda aceita inscrições.
        /// </summary>
        public bool TemVaga()
        {
            return VagasDisponiveis > 0;
        }
    }
}
