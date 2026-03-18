namespace EventosAPI.Models
{
    /// <summary>
    /// Herda de Pessoa. Representa um participante do evento.
    /// Contém campo de necessidade especial para integração com Libras.
    /// </summary>
    public class Participante : Pessoa
    {
        public string Instituicao { get; set; } = string.Empty;

        /// <summary>
        /// Indica se o participante necessita de intérprete de Libras.
        /// Disciplina: Libras — acessibilidade no sistema.
        /// </summary>
        public bool NecessitaInterpreteLibras { get; set; }

        public string Telefone { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        /// <summary>
        /// Polimorfismo: cada subclasse implementa sua própria descrição.
        /// </summary>
        public override string ObterDescricao()
        {
            var libras = NecessitaInterpreteLibras ? " | Necessita intérprete Libras" : "";
            return $"Participante: {Nome} - {Instituicao}{libras}";
        }
    }
}
