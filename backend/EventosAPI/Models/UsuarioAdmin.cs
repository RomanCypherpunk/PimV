namespace EventosAPI.Models
{
    /// <summary>
    /// Herda de Pessoa. Representa um membro da comissão organizadora.
    /// Disciplina: Comunicação, Liderança e Negociação — papéis de liderança.
    /// </summary>
    public class UsuarioAdmin : Pessoa
    {
        /// <summary>
        /// Cargo na comissão organizadora (ex: Coordenador Geral,
        /// Líder de Comunicação, Responsável por Acessibilidade).
        /// </summary>
        public string Cargo { get; set; } = string.Empty;

        /// <summary>
        /// Lista de permissões do administrador no sistema.
        /// Demonstra uso de coleções genéricas (List).
        /// </summary>
        public List<string> Permissoes { get; set; } = new List<string>();

        public override string ObterDescricao()
        {
            return $"Admin: {Nome} - {Cargo} | Permissões: {string.Join(", ", Permissoes)}";
        }

        /// <summary>
        /// Verifica se o administrador possui determinada permissão.
        /// </summary>
        public bool TemPermissao(string permissao)
        {
            return Permissoes.Any(p =>
                p.Equals(permissao, StringComparison.OrdinalIgnoreCase));
        }
    }
}
