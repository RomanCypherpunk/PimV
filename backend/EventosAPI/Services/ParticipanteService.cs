using EventosAPI.Data;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço de gerenciamento de participantes.
    /// </summary>
    public class ParticipanteService : ICsvPersistivel<Participante>
    {
        private readonly string _caminhoArquivo;

        public ParticipanteService(string pastaData)
        {
            _caminhoArquivo = Path.Combine(pastaData, "participantes.csv");
        }

        public List<Participante> LerTodos()
        {
            return CsvHelper<Participante>.LerCsv(_caminhoArquivo);
        }

        public Participante? BuscarPorId(int id)
        {
            return LerTodos().FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Busca participante por CPF. LINQ: FirstOrDefault com predicado.
        /// </summary>
        public Participante? BuscarPorCpf(string cpf)
        {
            var cpfLimpo = cpf.Replace(".", "").Replace("-", "").Trim();
            return LerTodos().FirstOrDefault(p => p.Cpf == cpfLimpo);
        }

        /// <summary>
        /// Busca participante por e-mail. LINQ com comparação case-insensitive.
        /// </summary>
        public Participante? BuscarPorEmail(string email)
        {
            return LerTodos().FirstOrDefault(p =>
                p.Email.Equals(email.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Lista participantes que necessitam intérprete de Libras.
        /// Disciplina: Libras — relatório de demanda de acessibilidade.
        /// </summary>
        public List<Participante> ListarComNecessidadeLibras()
        {
            return LerTodos()
                .Where(p => p.NecessitaInterpreteLibras)
                .OrderBy(p => p.Nome)
                .ToList();
        }

        public void Salvar(Participante participante)
        {
            var participantes = LerTodos();

            // Validação: CPF único
            if (participantes.Any(p => p.Cpf == participante.Cpf))
                throw new InvalidOperationException("Já existe um participante cadastrado com este CPF.");

            // Validação: e-mail único
            if (participantes.Any(p => p.Email.Equals(participante.Email, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Já existe um participante cadastrado com este e-mail.");

            participante.Id = participantes.Count > 0 ? participantes.Max(p => p.Id) + 1 : 1;
            participante.DataCadastro = DateTime.Now;
            participantes.Add(participante);
            CsvHelper<Participante>.EscreverCsv(_caminhoArquivo, participantes);
        }

        public void Atualizar(Participante participante)
        {
            var participantes = LerTodos();
            var index = participantes.FindIndex(p => p.Id == participante.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Participante com Id {participante.Id} não encontrado.");
            participantes[index] = participante;
            CsvHelper<Participante>.EscreverCsv(_caminhoArquivo, participantes);
        }

        public void Remover(int id)
        {
            var participantes = LerTodos();
            int removidos = participantes.RemoveAll(p => p.Id == id);
            if (removidos == 0)
                throw new KeyNotFoundException($"Participante com Id {id} não encontrado.");
            CsvHelper<Participante>.EscreverCsv(_caminhoArquivo, participantes);
        }
    }
}
