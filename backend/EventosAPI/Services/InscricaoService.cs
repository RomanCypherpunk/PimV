using EventosAPI.Data;
using EventosAPI.Enums;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço de gerenciamento de inscrições.
    /// Orquestra a lógica entre Participante, Atividade e Notificação.
    /// </summary>
    public class InscricaoService : ICsvPersistivel<Inscricao>
    {
        private readonly string _caminhoArquivo;
        private readonly AtividadeService _atividadeService;
        private readonly ParticipanteService _participanteService;
        private readonly NotificacaoService _notificacaoService;

        public InscricaoService(
            string pastaData,
            AtividadeService atividadeService,
            ParticipanteService participanteService,
            NotificacaoService notificacaoService)
        {
            _caminhoArquivo = Path.Combine(pastaData, "inscricoes.csv");
            _atividadeService = atividadeService;
            _participanteService = participanteService;
            _notificacaoService = notificacaoService;
        }

        public List<Inscricao> LerTodos()
        {
            return CsvHelper<Inscricao>.LerCsv(_caminhoArquivo);
        }

        public Inscricao? BuscarPorId(int id)
        {
            return LerTodos().FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Busca todas as inscrições de um participante por CPF.
        /// LINQ: Where + Join lógico com ParticipanteService.
        /// </summary>
        public List<Inscricao> BuscarPorCpf(string cpf)
        {
            var participante = _participanteService.BuscarPorCpf(cpf);
            if (participante == null)
                return new List<Inscricao>();

            return LerTodos()
                .Where(i => i.ParticipanteId == participante.Id && i.EstaAtiva())
                .OrderByDescending(i => i.DataInscricao)
                .ToList();
        }

        /// <summary>
        /// Busca inscrições por atividade. LINQ: Where + OrderBy.
        /// </summary>
        public List<Inscricao> BuscarPorAtividade(int atividadeId)
        {
            return LerTodos()
                .Where(i => i.AtividadeId == atividadeId && i.EstaAtiva())
                .OrderBy(i => i.DataInscricao)
                .ToList();
        }

        /// <summary>
        /// Conta inscrições que solicitaram Libras para uma atividade.
        /// Disciplina: Libras — levantamento de demanda.
        /// </summary>
        public int ContarSolicitacoesLibras(int atividadeId)
        {
            return LerTodos()
                .Count(i => i.AtividadeId == atividadeId
                    && i.SolicitouInterpreteLibras
                    && i.EstaAtiva());
        }

        /// <summary>
        /// Realiza a inscrição com validações e gera notificação.
        /// Tratamento de exceções para regras de negócio.
        /// </summary>
        public Inscricao Salvar(Inscricao inscricao)
        {
            // Validar participante
            var participante = _participanteService.BuscarPorId(inscricao.ParticipanteId)
                ?? throw new KeyNotFoundException("Participante não encontrado.");

            // Validar atividade
            var atividade = _atividadeService.BuscarPorId(inscricao.AtividadeId)
                ?? throw new KeyNotFoundException("Atividade não encontrada.");

            // Verificar vagas
            if (!atividade.TemVaga())
                throw new InvalidOperationException($"A atividade '{atividade.Titulo}' não possui vagas disponíveis.");

            // Verificar inscrição duplicada (LINQ: Any)
            var inscricoes = LerTodos();
            bool jaCadastrado = inscricoes.Any(i =>
                i.ParticipanteId == inscricao.ParticipanteId
                && i.AtividadeId == inscricao.AtividadeId
                && i.EstaAtiva());

            if (jaCadastrado)
                throw new InvalidOperationException("Participante já está inscrito nesta atividade.");

            // Salvar inscrição
            inscricao.Id = inscricoes.Count > 0 ? inscricoes.Max(i => i.Id) + 1 : 1;
            inscricao.DataInscricao = DateTime.Now;
            inscricao.Status = StatusInscricao.Confirmada;
            inscricoes.Add(inscricao);
            CsvHelper<Inscricao>.EscreverCsv(_caminhoArquivo, inscricoes);

            // Incrementar vagas ocupadas
            _atividadeService.IncrementarVaga(inscricao.AtividadeId);

            // Gerar notificação de confirmação (Disciplina: Comunicação)
            var notificacao = Notificacao.CriarConfirmacaoInscricao(
                inscricao.ParticipanteId,
                atividade.Titulo,
                atividade.DataHora);
            _notificacaoService.Salvar(notificacao);

            return inscricao;
        }

        /// <summary>
        /// Cancela uma inscrição e gera notificação.
        /// </summary>
        public void CancelarInscricao(int inscricaoId)
        {
            var inscricoes = LerTodos();
            var inscricao = inscricoes.FirstOrDefault(i => i.Id == inscricaoId)
                ?? throw new KeyNotFoundException("Inscrição não encontrada.");

            inscricao.Cancelar(); // Método do Model com validação

            CsvHelper<Inscricao>.EscreverCsv(_caminhoArquivo, inscricoes);

            // Liberar vaga
            _atividadeService.DecrementarVaga(inscricao.AtividadeId);
        }

        void ICsvPersistivel<Inscricao>.Salvar(Inscricao item) => Salvar(item);

        public void Atualizar(Inscricao inscricao)
        {
            var inscricoes = LerTodos();
            var index = inscricoes.FindIndex(i => i.Id == inscricao.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Inscrição com Id {inscricao.Id} não encontrada.");
            inscricoes[index] = inscricao;
            CsvHelper<Inscricao>.EscreverCsv(_caminhoArquivo, inscricoes);
        }

        public void Remover(int id)
        {
            var inscricoes = LerTodos();
            inscricoes.RemoveAll(i => i.Id == id);
            CsvHelper<Inscricao>.EscreverCsv(_caminhoArquivo, inscricoes);
        }
    }
}
