using EventosAPI.Data;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço do glossário de termos em Libras.
    /// Disciplina: Língua Brasileira de Sinais – Libras.
    /// Gerencia o glossário interativo de termos de TI em Libras.
    /// </summary>
    public class TermoLibrasService : ICsvPersistivel<TermoLibras>
    {
        private readonly string _caminhoArquivo;

        public TermoLibrasService(string pastaData)
        {
            _caminhoArquivo = Path.Combine(pastaData, "glossario_libras.csv");
        }

        public List<TermoLibras> LerTodos()
        {
            return CsvHelper<TermoLibras>.LerCsv(_caminhoArquivo);
        }

        public TermoLibras? BuscarPorId(int id)
        {
            return LerTodos().FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Busca termos por texto (busca parcial case-insensitive).
        /// LINQ: Where + Contains para busca textual.
        /// </summary>
        public List<TermoLibras> Buscar(string busca)
        {
            return LerTodos()
                .Where(t => t.TermoPortugues.Contains(busca, StringComparison.OrdinalIgnoreCase)
                    || t.DescricaoSinal.Contains(busca, StringComparison.OrdinalIgnoreCase)
                    || t.ContextoUso.Contains(busca, StringComparison.OrdinalIgnoreCase))
                .OrderBy(t => t.TermoPortugues)
                .ToList();
        }

        /// <summary>
        /// Filtra termos por categoria (ex: "Evento", "Documento").
        /// LINQ: Where com comparação de string.
        /// </summary>
        public List<TermoLibras> BuscarPorCategoria(string categoria)
        {
            return LerTodos()
                .Where(t => t.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .OrderBy(t => t.TermoPortugues)
                .ToList();
        }

        /// <summary>
        /// Lista todas as categorias disponíveis.
        /// LINQ: Select + Distinct para valores únicos.
        /// </summary>
        public List<string> ListarCategorias()
        {
            return LerTodos()
                .Select(t => t.Categoria)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public void Salvar(TermoLibras termo)
        {
            var termos = LerTodos();
            termo.Id = termos.Count > 0 ? termos.Max(t => t.Id) + 1 : 1;
            termos.Add(termo);
            CsvHelper<TermoLibras>.EscreverCsv(_caminhoArquivo, termos);
        }

        public void Atualizar(TermoLibras termo)
        {
            var termos = LerTodos();
            var index = termos.FindIndex(t => t.Id == termo.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Termo com Id {termo.Id} não encontrado.");
            termos[index] = termo;
            CsvHelper<TermoLibras>.EscreverCsv(_caminhoArquivo, termos);
        }

        public void Remover(int id)
        {
            var termos = LerTodos();
            termos.RemoveAll(t => t.Id == id);
            CsvHelper<TermoLibras>.EscreverCsv(_caminhoArquivo, termos);
        }
    }
}
