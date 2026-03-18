using EventosAPI.Data;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço de feedback dos participantes.
    /// Disciplina: Comunicação, Liderança e Negociação.
    /// Canal de retorno para melhoria contínua do evento.
    /// </summary>
    public class FeedbackService : ICsvPersistivel<Feedback>
    {
        private readonly string _caminhoArquivo;

        public FeedbackService(string pastaData)
        {
            _caminhoArquivo = Path.Combine(pastaData, "feedbacks.csv");
        }

        public List<Feedback> LerTodos()
        {
            return CsvHelper<Feedback>.LerCsv(_caminhoArquivo);
        }

        public Feedback? BuscarPorId(int id)
        {
            return LerTodos().FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// Busca feedbacks de uma atividade específica.
        /// </summary>
        public List<Feedback> BuscarPorAtividade(int atividadeId)
        {
            return LerTodos()
                .Where(f => f.AtividadeId == atividadeId)
                .OrderByDescending(f => f.DataEnvio)
                .ToList();
        }

        /// <summary>
        /// Calcula a média de notas de uma atividade usando LINQ Average.
        /// </summary>
        public double CalcularMediaAtividade(int atividadeId)
        {
            var feedbacks = BuscarPorAtividade(atividadeId);
            if (feedbacks.Count == 0)
                return 0;

            // LINQ: Average para calcular média
            return feedbacks.Average(f => f.Nota);
        }

        /// <summary>
        /// Gera relatório resumido de feedbacks por atividade.
        /// LINQ: GroupBy + Select para agregação.
        /// </summary>
        public List<object> GerarRelatorio()
        {
            return LerTodos()
                .GroupBy(f => f.AtividadeId)
                .Select(grupo => new
                {
                    AtividadeId = grupo.Key,
                    TotalFeedbacks = grupo.Count(),
                    MediaNota = Math.Round(grupo.Average(f => f.Nota), 2),
                    MelhorNota = grupo.Max(f => f.Nota),
                    PiorNota = grupo.Min(f => f.Nota)
                })
                .Cast<object>()
                .ToList();
        }

        public void Salvar(Feedback feedback)
        {
            var feedbacks = LerTodos();

            // Validar feedback duplicado
            bool jaAvaliou = feedbacks.Any(f =>
                f.ParticipanteId == feedback.ParticipanteId
                && f.AtividadeId == feedback.AtividadeId);

            if (jaAvaliou)
                throw new InvalidOperationException("Participante já enviou feedback para esta atividade.");

            feedback.Id = feedbacks.Count > 0 ? feedbacks.Max(f => f.Id) + 1 : 1;
            feedback.DataEnvio = DateTime.Now;
            feedbacks.Add(feedback);
            CsvHelper<Feedback>.EscreverCsv(_caminhoArquivo, feedbacks);
        }

        public void Atualizar(Feedback feedback)
        {
            var feedbacks = LerTodos();
            var index = feedbacks.FindIndex(f => f.Id == feedback.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Feedback com Id {feedback.Id} não encontrado.");
            feedbacks[index] = feedback;
            CsvHelper<Feedback>.EscreverCsv(_caminhoArquivo, feedbacks);
        }

        public void Remover(int id)
        {
            var feedbacks = LerTodos();
            feedbacks.RemoveAll(f => f.Id == id);
            CsvHelper<Feedback>.EscreverCsv(_caminhoArquivo, feedbacks);
        }
    }
}
