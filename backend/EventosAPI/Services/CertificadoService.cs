using EventosAPI.Data;
using EventosAPI.Enums;
using EventosAPI.Interfaces;
using EventosAPI.Models;

namespace EventosAPI.Services
{
    /// <summary>
    /// Serviço de emissão e validação de certificados.
    /// Implementa ICertificavel e ICsvPersistivel.
    /// </summary>
    public class CertificadoService : ICsvPersistivel<Certificado>, ICertificavel
    {
        private readonly string _caminhoArquivo;
        private readonly InscricaoService _inscricaoService;
        private readonly ParticipanteService _participanteService;
        private readonly AtividadeService _atividadeService;
        private readonly EventoService _eventoService;

        public CertificadoService(
            string pastaData,
            InscricaoService inscricaoService,
            ParticipanteService participanteService,
            AtividadeService atividadeService,
            EventoService eventoService)
        {
            _caminhoArquivo = Path.Combine(pastaData, "certificados.csv");
            _inscricaoService = inscricaoService;
            _participanteService = participanteService;
            _atividadeService = atividadeService;
            _eventoService = eventoService;
        }

        public List<Certificado> LerTodos()
        {
            return CsvHelper<Certificado>.LerCsv(_caminhoArquivo);
        }

        public Certificado? BuscarPorId(int id)
        {
            return LerTodos().FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Busca certificados por CPF do participante.
        /// LINQ: Where com join lógico.
        /// </summary>
        public List<Certificado> BuscarPorCpf(string cpf)
        {
            var participante = _participanteService.BuscarPorCpf(cpf);
            if (participante == null)
                return new List<Certificado>();

            return LerTodos()
                .Where(c => c.ParticipanteId == participante.Id)
                .OrderByDescending(c => c.DataEmissao)
                .ToList();
        }

        /// <summary>
        /// Gera certificado para uma inscrição concluída.
        /// Implementação da interface ICertificavel.
        /// </summary>
        public Certificado GerarCertificado(int inscricaoId)
        {
            var inscricao = _inscricaoService.BuscarPorId(inscricaoId)
                ?? throw new KeyNotFoundException("Inscrição não encontrada.");

            if (inscricao.Status != StatusInscricao.Concluida)
                throw new InvalidOperationException(
                    "Certificado só pode ser emitido para inscrições com status 'Concluída'.");

            // Verificar se já existe certificado para esta inscrição
            var existente = LerTodos().FirstOrDefault(c => c.InscricaoId == inscricaoId);
            if (existente != null)
                return existente; // Retorna o certificado já existente

            var participante = _participanteService.BuscarPorId(inscricao.ParticipanteId)
                ?? throw new KeyNotFoundException("Participante não encontrado.");

            var atividade = _atividadeService.BuscarPorId(inscricao.AtividadeId)
                ?? throw new KeyNotFoundException("Atividade não encontrada.");

            var evento = _eventoService.BuscarPorId(atividade.EventoId)
                ?? throw new KeyNotFoundException("Evento não encontrado.");

            var certificados = LerTodos();

            var certificado = new Certificado
            {
                Id = certificados.Count > 0 ? certificados.Max(c => c.Id) + 1 : 1,
                InscricaoId = inscricaoId,
                ParticipanteId = participante.Id,
                AtividadeId = atividade.Id,
                CodigoValidacao = Certificado.GerarCodigoValidacao(),
                NomeParticipante = participante.Nome,
                TituloAtividade = atividade.Titulo,
                CargaHoraria = atividade.DuracaoMinutos / 60,
                DataEmissao = DateTime.Now,
                NomeEvento = evento.Nome
            };

            certificados.Add(certificado);
            CsvHelper<Certificado>.EscreverCsv(_caminhoArquivo, certificados);

            return certificado;
        }

        /// <summary>
        /// Valida um certificado pelo código de validação.
        /// Implementação da interface ICertificavel.
        /// </summary>
        public Certificado? ValidarCertificado(string codigoValidacao)
        {
            if (!Certificado.ValidarFormato(codigoValidacao))
                throw new ArgumentException("Formato do código de validação inválido. Use CERT-XXXXXXXX.");

            // LINQ: FirstOrDefault com comparação case-insensitive
            return LerTodos().FirstOrDefault(c =>
                c.CodigoValidacao.Equals(codigoValidacao, StringComparison.OrdinalIgnoreCase));
        }

        public void Salvar(Certificado certificado)
        {
            var certificados = LerTodos();
            certificado.Id = certificados.Count > 0 ? certificados.Max(c => c.Id) + 1 : 1;
            certificados.Add(certificado);
            CsvHelper<Certificado>.EscreverCsv(_caminhoArquivo, certificados);
        }

        public void Atualizar(Certificado certificado)
        {
            var certificados = LerTodos();
            var index = certificados.FindIndex(c => c.Id == certificado.Id);
            if (index == -1)
                throw new KeyNotFoundException($"Certificado com Id {certificado.Id} não encontrado.");
            certificados[index] = certificado;
            CsvHelper<Certificado>.EscreverCsv(_caminhoArquivo, certificados);
        }

        public void Remover(int id)
        {
            var certificados = LerTodos();
            certificados.RemoveAll(c => c.Id == id);
            CsvHelper<Certificado>.EscreverCsv(_caminhoArquivo, certificados);
        }
    }
}
