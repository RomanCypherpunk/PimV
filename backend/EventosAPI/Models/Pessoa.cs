namespace EventosAPI.Models
{
    /// <summary>
    /// Classe abstrata base que demonstra HERANÇA e ENCAPSULAMENTO.
    /// Pessoa é a superclasse de Participante e UsuarioAdmin.
    /// </summary>
    public abstract class Pessoa
    {
        // Encapsulamento: campos privados com propriedades públicas
        private int _id;
        private string _nome = string.Empty;
        private string _email = string.Empty;
        private string _cpf = string.Empty;

        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id não pode ser negativo.");
                _id = value;
            }
        }

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser vazio.");
                _nome = value.Trim();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
                    throw new ArgumentException("E-mail inválido.");
                _email = value.Trim().ToLower();
            }
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                var cpfLimpo = value?.Replace(".", "").Replace("-", "").Trim() ?? "";
                if (cpfLimpo.Length != 11 || !cpfLimpo.All(char.IsDigit))
                    throw new ArgumentException("CPF deve conter exatamente 11 dígitos numéricos.");
                _cpf = cpfLimpo;
            }
        }

        /// <summary>
        /// Método abstrato que força subclasses a implementarem sua descrição.
        /// Demonstra polimorfismo.
        /// </summary>
        public abstract string ObterDescricao();

        public override string ToString()
        {
            return $"{Nome} ({Email})";
        }
    }
}
