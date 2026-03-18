using EventosAPI.Data;
using EventosAPI.Enums;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço de notificações para comunicação com participantes.
    /// Disciplina: Comunicação, Liderança e Negociação.
    /// Implementa os templates de mensagens e o fluxo de comunicação.
    /// </summary>
    public class NotificacaoService : ICsvPersistivel<Notificacao>
    {
        private readonly string _caminhoArquivo;

        public NotificacaoService(string pastaData)
        {
            _caminhoArquivo = Path.Combine(pastaData, "notificacoes.csv");
        }

        public List<Notificacao> LerTodos()
        {
            return CsvHelper<Notificacao>.LerCsv(_caminhoArquivo);
        }

        public Notificacao? BuscarPorId(int id)
        {
            return LerTodos().FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// Busca notificações de um participante.
        /// LINQ: Where + OrderByDescending para mostrar mais recentes primeiro.
        /// </summary>
        public List<Notificacao> BuscarPorParticipante(int participanteId)
        {
            return LerTodos()
                .Where(n => n.ParticipanteId == participanteId)
                .OrderByDescending(n => n.DataEnvio)
                .ToList();
        }

        /// <summary>
        /// Conta notificações não lidas de um participante. LINQ: Count.
        /// </summary>
        public int ContarNaoLidas(int participanteId)
        {
            return LerTodos()
                .Count(n => n.ParticipanteId == participanteId && !n.Lida);
        }

        /// <summary>
        /// Marca uma notificação como lida.
        /// </summary>
        public void MarcarComoLida(int notificacaoId)
        {
            var notificacoes = LerTodos();
            var notificacao = notificacoes.FirstOrDefault(n => n.Id == notificacaoId)
                ?? throw new KeyNotFoundException("Notificação não encontrada.");

            notificacao.Lida = true;
            CsvHelper<Notificacao>.EscreverCsv(_caminhoArquivo, notificacoes);
        }

        public void Salvar(Notificacao notificacao)
        {
            var notificacoes = LerTodos();
            notificacao.Id = notificacoes.Count > 0 ? notificacoes.Max(n => n.Id) + 1 : 1;
            notificacao.DataEnvio = DateTime.Now;
            notificacoes.Add(notificacao);
            CsvHelper<Notificacao>.EscreverCsv(_caminhoArquivo, notificacoes);
        }

        /// <summary>
        /// Envia notificação em massa para todos os inscritos em uma atividade.
        /// Disciplina: Comunicação — comunicação de mudanças na programação.
        /// </summary>
        public void NotificarInscritosAtividade(
            List<int> participanteIds,
            TipoNotificacao tipo,
            string titulo,
            string mensagem)
        {
            foreach (var participanteId in participanteIds)
            {
                var notificacao = new Notificacao
                {
                    ParticipanteId = participanteId,
                    Tipo = tipo,
                    Titulo = titulo,
                    Mensagem = mensagem
                };
                Salvar(notificacao);
            }
        }

        public void Atualizar(Notificacao notificacao)
        {
            var notificacoes = LerTodos();
            var index = notificacoes.FindIndex(n => n.Id == notificacao.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Notificação com Id {notificacao.Id} não encontrada.");
            notificacoes[index] = notificacao;
            CsvHelper<Notificacao>.EscreverCsv(_caminhoArquivo, notificacoes);
        }

        public void Remover(int id)
        {
            var notificacoes = LerTodos();
            notificacoes.RemoveAll(n => n.Id == id);
            CsvHelper<Notificacao>.EscreverCsv(_caminhoArquivo, notificacoes);
        }
    }
}
