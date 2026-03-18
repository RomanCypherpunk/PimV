using EventosAPI.Data;
using EventosAPI.Enums;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço de gerenciamento de atividades.
    /// Demonstra uso intensivo de LINQ para filtros e ordenações.
    /// </summary>
    public class AtividadeService : ICsvPersistivel<Atividade>
    {
        private readonly string _caminhoArquivo;

        public AtividadeService(string pastaData)
        {
            _caminhoArquivo = Path.Combine(pastaData, "atividades.csv");
        }

        public List<Atividade> LerTodos()
        {
            return CsvHelper<Atividade>.LerCsv(_caminhoArquivo);
        }

        public Atividade? BuscarPorId(int id)
        {
            return LerTodos().FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// Filtra atividades por evento usando LINQ Where.
        /// </summary>
        public List<Atividade> BuscarPorEvento(int eventoId)
        {
            return LerTodos()
                .Where(a => a.EventoId == eventoId)
                .OrderBy(a => a.DataHora)
                .ToList();
        }

        /// <summary>
        /// Filtra atividades por tipo usando LINQ Where + enum.
        /// </summary>
        public List<Atividade> BuscarPorTipo(int eventoId, TipoAtividade tipo)
        {
            return LerTodos()
                .Where(a => a.EventoId == eventoId && a.Tipo == tipo)
                .OrderBy(a => a.DataHora)
                .ToList();
        }

        /// <summary>
        /// Filtra atividades que possuem intérprete de Libras.
        /// Disciplina: Libras — recurso de filtro para acessibilidade.
        /// </summary>
        public List<Atividade> BuscarComLibras(int eventoId)
        {
            return LerTodos()
                .Where(a => a.EventoId == eventoId && a.TemInterpreteLibras)
                .OrderBy(a => a.DataHora)
                .ToList();
        }

        /// <summary>
        /// Filtra atividades com vagas disponíveis usando LINQ.
        /// </summary>
        public List<Atividade> BuscarComVagas(int eventoId)
        {
            return LerTodos()
                .Where(a => a.EventoId == eventoId && a.TemVaga())
                .OrderBy(a => a.DataHora)
                .ToList();
        }

        /// <summary>
        /// Busca atividades por data específica usando LINQ.
        /// </summary>
        public List<Atividade> BuscarPorData(int eventoId, DateTime data)
        {
            return LerTodos()
                .Where(a => a.EventoId == eventoId && a.DataHora.Date == data.Date)
                .OrderBy(a => a.DataHora)
                .ToList();
        }

        public void Salvar(Atividade atividade)
        {
            var atividades = LerTodos();
            atividade.Id = atividades.Count > 0 ? atividades.Max(a => a.Id) + 1 : 1;
            atividades.Add(atividade);
            CsvHelper<Atividade>.EscreverCsv(_caminhoArquivo, atividades);
        }

        public void Atualizar(Atividade atividade)
        {
            var atividades = LerTodos();
            var index = atividades.FindIndex(a => a.Id == atividade.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Atividade com Id {atividade.Id} não encontrada.");
            atividades[index] = atividade;
            CsvHelper<Atividade>.EscreverCsv(_caminhoArquivo, atividades);
        }

        public void Remover(int id)
        {
            var atividades = LerTodos();
            int removidos = atividades.RemoveAll(a => a.Id == id);
            if (removidos == 0)
                throw new KeyNotFoundException($"Atividade com Id {id} não encontrada.");
            CsvHelper<Atividade>.EscreverCsv(_caminhoArquivo, atividades);
        }

        /// <summary>
        /// Incrementa vagas ocupadas ao registrar uma inscrição.
        /// </summary>
        public void IncrementarVaga(int atividadeId)
        {
            var atividade = BuscarPorId(atividadeId)
                ?? throw new KeyNotFoundException($"Atividade {atividadeId} não encontrada.");

            if (!atividade.TemVaga())
                throw new InvalidOperationException($"Atividade '{atividade.Titulo}' não possui vagas disponíveis.");

            atividade.VagasOcupadas++;
            Atualizar(atividade);
        }

        /// <summary>
        /// Decrementa vagas ocupadas ao cancelar uma inscrição.
        /// </summary>
        public void DecrementarVaga(int atividadeId)
        {
            var atividade = BuscarPorId(atividadeId)
                ?? throw new KeyNotFoundException($"Atividade {atividadeId} não encontrada.");

            if (atividade.VagasOcupadas > 0)
                atividade.VagasOcupadas--;

            Atualizar(atividade);
        }
    }
}
