using EventosAPI.Data;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço de gerenciamento de eventos. Implementa ICsvPersistivel.
    /// </summary>
    public class EventoService : ICsvPersistivel<Evento>
    {
        private readonly string _caminhoArquivo;

        public EventoService(string pastaData)
        {
            _caminhoArquivo = Path.Combine(pastaData, "eventos.csv");
        }

        public List<Evento> LerTodos()
        {
            return CsvHelper<Evento>.LerCsv(_caminhoArquivo);
        }

        public Evento? BuscarPorId(int id)
        {
            // Uso de LINQ: FirstOrDefault para busca por Id
            return LerTodos().FirstOrDefault(e => e.Id == id);
        }

        public void Salvar(Evento evento)
        {
            var eventos = LerTodos();
            // LINQ: calcula próximo Id com Max
            evento.Id = eventos.Count > 0 ? eventos.Max(e => e.Id) + 1 : 1;
            eventos.Add(evento);
            CsvHelper<Evento>.EscreverCsv(_caminhoArquivo, eventos);
        }

        public void Atualizar(Evento evento)
        {
            var eventos = LerTodos();
            var index = eventos.FindIndex(e => e.Id == evento.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Evento com Id {evento.Id} não encontrado.");
            eventos[index] = evento;
            CsvHelper<Evento>.EscreverCsv(_caminhoArquivo, eventos);
        }

        public void Remover(int id)
        {
            var eventos = LerTodos();
            // LINQ: RemoveAll filtra e remove
            int removidos = eventos.RemoveAll(e => e.Id == id);
            if (removidos == 0)
                throw new KeyNotFoundException($"Evento com Id {id} não encontrado.");
            CsvHelper<Evento>.EscreverCsv(_caminhoArquivo, eventos);
        }
    }
}
