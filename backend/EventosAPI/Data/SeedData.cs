using EventosAPI.Enums;
using EventosAPI.Models;

namespace EventosAPI.Data
{
    /// <summary>
    /// Classe responsável por popular os arquivos CSV com dados iniciais
    /// do evento fictício "Semana de TI Inclusiva UNIP 2026".
    /// </summary>
    public static class SeedData
    {
        public static void Inicializar(string pastaData)
        {
            if (!Directory.Exists(pastaData))
                Directory.CreateDirectory(pastaData);

            SeedEventos(pastaData);
            SeedAtividades(pastaData);
            SeedGlossarioLibras(pastaData);
        }

        private static void SeedEventos(string pastaData)
        {
            var caminho = Path.Combine(pastaData, "eventos.csv");
            if (File.Exists(caminho)) return;

            var eventos = new List<Evento>
            {
                new Evento
                {
                    Id = 1,
                    Nome = "Semana de TI Inclusiva UNIP 2026",
                    Descricao = "Evento acadêmico de Tecnologia da Informação com foco em " +
                                "inclusão digital e acessibilidade. Palestras, minicursos, " +
                                "workshops e hackathon abertos à comunidade acadêmica. " +
                                "Todas as atividades principais contam com intérprete de Libras.",
                    DataInicio = new DateTime(2026, 4, 14),
                    DataFim = new DateTime(2026, 4, 18),
                    Local = "Auditório Virtual UNIP + Transmissão ao vivo",
                    SuporteLibras = true,
                    EmailContato = "semana.ti@unip.br"
                }
            };

            CsvHelper<Evento>.EscreverCsv(caminho, eventos);
        }

        private static void SeedAtividades(string pastaData)
        {
            var caminho = Path.Combine(pastaData, "atividades.csv");
            if (File.Exists(caminho)) return;

            var atividades = new List<Atividade>
            {
                // Dia 1 — 14/04
                new Atividade
                {
                    Id = 1, EventoId = 1,
                    Titulo = "Abertura: IA e Acessibilidade Digital",
                    Descricao = "Palestra de abertura sobre como a Inteligência Artificial pode " +
                                "ser aliada na promoção da acessibilidade digital.",
                    Tipo = TipoAtividade.Palestra,
                    Palestrante = "Prof. Dr. Marcos Lima",
                    DataHora = new DateTime(2026, 4, 14, 9, 0, 0),
                    DuracaoMinutos = 120,
                    VagasTotal = 200, VagasOcupadas = 0,
                    TemInterpreteLibras = true,
                    Sala = "Auditório Principal"
                },
                new Atividade
                {
                    Id = 2, EventoId = 1,
                    Titulo = "Introdução a C# para Iniciantes",
                    Descricao = "Minicurso prático sobre os fundamentos da linguagem C# " +
                                "com foco em orientação a objetos.",
                    Tipo = TipoAtividade.Minicurso,
                    Palestrante = "Ana Costa",
                    DataHora = new DateTime(2026, 4, 14, 14, 0, 0),
                    DuracaoMinutos = 180,
                    VagasTotal = 50, VagasOcupadas = 0,
                    TemInterpreteLibras = true,
                    Sala = "Laboratório 1"
                },
                // Dia 2 — 15/04
                new Atividade
                {
                    Id = 3, EventoId = 1,
                    Titulo = "Inclusão Digital no Mercado de TI",
                    Descricao = "Mesa-redonda com profissionais que discutem " +
                                "a inclusão de pessoas com deficiência no mercado de tecnologia.",
                    Tipo = TipoAtividade.MesaRedonda,
                    Palestrante = "Diversos convidados",
                    DataHora = new DateTime(2026, 4, 15, 9, 0, 0),
                    DuracaoMinutos = 120,
                    VagasTotal = 200, VagasOcupadas = 0,
                    TemInterpreteLibras = true,
                    Sala = "Auditório Principal"
                },
                new Atividade
                {
                    Id = 4, EventoId = 1,
                    Titulo = "Design Responsivo com CSS Grid e Flexbox",
                    Descricao = "Workshop prático sobre criação de layouts responsivos " +
                                "usando CSS Grid e Flexbox com foco em acessibilidade.",
                    Tipo = TipoAtividade.Workshop,
                    Palestrante = "Pedro Souza",
                    DataHora = new DateTime(2026, 4, 15, 14, 0, 0),
                    DuracaoMinutos = 180,
                    VagasTotal = 40, VagasOcupadas = 0,
                    TemInterpreteLibras = false,
                    Sala = "Laboratório 2"
                },
                // Dia 3 — 16/04
                new Atividade
                {
                    Id = 5, EventoId = 1,
                    Titulo = "Libras e Tecnologia Assistiva",
                    Descricao = "Palestra ministrada por professora surda sobre a relação " +
                                "entre Libras e as tecnologias assistivas no contexto acadêmico.",
                    Tipo = TipoAtividade.Palestra,
                    Palestrante = "Profa. Carla Dias",
                    DataHora = new DateTime(2026, 4, 16, 9, 0, 0),
                    DuracaoMinutos = 120,
                    VagasTotal = 200, VagasOcupadas = 0,
                    TemInterpreteLibras = true,
                    Sala = "Auditório Principal"
                },
                new Atividade
                {
                    Id = 6, EventoId = 1,
                    Titulo = "Desafio de Acessibilidade Web",
                    Descricao = "Hackathon de 6 horas: equipes criam soluções web acessíveis " +
                                "para problemas reais de inclusão digital.",
                    Tipo = TipoAtividade.Hackathon,
                    Palestrante = "Comissão Organizadora",
                    DataHora = new DateTime(2026, 4, 16, 13, 0, 0),
                    DuracaoMinutos = 360,
                    VagasTotal = 60, VagasOcupadas = 0,
                    TemInterpreteLibras = true,
                    Sala = "Laboratórios 1, 2 e 3"
                },
                // Dia 4 — 17/04
                new Atividade
                {
                    Id = 7, EventoId = 1,
                    Titulo = "APIs REST com ASP.NET Core",
                    Descricao = "Minicurso sobre construção de APIs RESTful com ASP.NET Core " +
                                "e persistência de dados.",
                    Tipo = TipoAtividade.Minicurso,
                    Palestrante = "Lucas Alves",
                    DataHora = new DateTime(2026, 4, 17, 9, 0, 0),
                    DuracaoMinutos = 180,
                    VagasTotal = 50, VagasOcupadas = 0,
                    TemInterpreteLibras = false,
                    Sala = "Laboratório 1"
                },
                new Atividade
                {
                    Id = 8, EventoId = 1,
                    Titulo = "Carreira em TI: Soft Skills e Liderança",
                    Descricao = "Palestra sobre habilidades interpessoais, comunicação " +
                                "e liderança no mercado de tecnologia.",
                    Tipo = TipoAtividade.Palestra,
                    Palestrante = "Dra. Julia Ramos",
                    DataHora = new DateTime(2026, 4, 17, 14, 0, 0),
                    DuracaoMinutos = 120,
                    VagasTotal = 200, VagasOcupadas = 0,
                    TemInterpreteLibras = true,
                    Sala = "Auditório Principal"
                },
                // Dia 5 — 18/04
                new Atividade
                {
                    Id = 9, EventoId = 1,
                    Titulo = "Encerramento: Premiação e Certificados",
                    Descricao = "Cerimônia de encerramento com premiação do Hackathon, " +
                                "entrega de certificados e confraternização.",
                    Tipo = TipoAtividade.Encerramento,
                    Palestrante = "Comissão Organizadora",
                    DataHora = new DateTime(2026, 4, 18, 16, 0, 0),
                    DuracaoMinutos = 120,
                    VagasTotal = 300, VagasOcupadas = 0,
                    TemInterpreteLibras = true,
                    Sala = "Auditório Principal"
                }
            };

            CsvHelper<Atividade>.EscreverCsv(caminho, atividades);
        }

        /// <summary>
        /// Popula o glossário de Libras com termos de TI.
        /// Disciplina: Língua Brasileira de Sinais – Libras.
        /// </summary>
        private static void SeedGlossarioLibras(string pastaData)
        {
            var caminho = Path.Combine(pastaData, "glossario_libras.csv");
            if (File.Exists(caminho)) return;

            var termos = new List<TermoLibras>
            {
                new TermoLibras
                {
                    Id = 1,
                    TermoPortugues = "Inscrição",
                    DescricaoSinal = "Mão dominante em configuração de 'I' realiza movimento " +
                                     "circular no espaço neutro à frente do corpo seguido de " +
                                     "toque na palma da mão de apoio representando registro.",
                    ContextoUso = "Processo de cadastro do participante em uma atividade do evento.",
                    Categoria = "Evento",
                    VideoUrl = "/assets/libras/inscricao.mp4"
                },
                new TermoLibras
                {
                    Id = 2,
                    TermoPortugues = "Certificado",
                    DescricaoSinal = "Ambas as mãos em configuração aberta simulam segurar " +
                                     "um documento e realizando movimento de apresentação à frente do corpo.",
                    ContextoUso = "Documento emitido ao participante que comprova sua participação na atividade.",
                    Categoria = "Documento",
                    VideoUrl = "/assets/libras/certificado.mp4"
                },
                new TermoLibras
                {
                    Id = 3,
                    TermoPortugues = "Palestra",
                    DescricaoSinal = "Mão dominante em configuração de 'P' realiza movimento " +
                                     "para frente e para cima partindo da lateral da boca " +
                                     "indicando fala direcionada a um público.",
                    ContextoUso = "Apresentação oral de um especialista sobre tema específico de TI.",
                    Categoria = "Atividade",
                    VideoUrl = "/assets/libras/palestra.mp4"
                },
                new TermoLibras
                {
                    Id = 4,
                    TermoPortugues = "Minicurso",
                    DescricaoSinal = "Sinal composto: sinal de PEQUENO (polegar e indicador próximos) " +
                                     "seguido do sinal de CURSO (mão dominante desliza sobre mão de apoio " +
                                     "aberta representando aprendizado contínuo).",
                    ContextoUso = "Curso de curta duração sobre tema prático oferecido durante o evento.",
                    Categoria = "Atividade",
                    VideoUrl = "/assets/libras/minicurso.mp4"
                },
                new TermoLibras
                {
                    Id = 5,
                    TermoPortugues = "Mesa-redonda",
                    DescricaoSinal = "Ambas as mãos em configuração circular descrevem o contorno " +
                                     "de uma mesa redonda no espaço à frente do corpo seguido do " +
                                     "sinal de CONVERSAR (mãos alternando movimento para frente).",
                    ContextoUso = "Debate entre vários especialistas sobre um tema com mediador.",
                    Categoria = "Atividade",
                    VideoUrl = "/assets/libras/mesa-redonda.mp4"
                },
                new TermoLibras
                {
                    Id = 6,
                    TermoPortugues = "Hackathon",
                    DescricaoSinal = "Soletração manual H-A-C-K seguida do sinal de MARATONA " +
                                     "(mãos simulando digitação rápida com expressão facial de esforço).",
                    ContextoUso = "Competição de programação em equipe com tempo limitado.",
                    Categoria = "Atividade",
                    VideoUrl = "/assets/libras/hackathon.mp4"
                },
                new TermoLibras
                {
                    Id = 7,
                    TermoPortugues = "Credenciamento",
                    DescricaoSinal = "Mão dominante em configuração de 'C' toca o peito " +
                                     "(identificação) seguido de movimento de entregar crachá " +
                                     "com ambas as mãos.",
                    ContextoUso = "Processo de registro e identificação do participante na chegada ao evento.",
                    Categoria = "Evento",
                    VideoUrl = "/assets/libras/credenciamento.mp4"
                },
                new TermoLibras
                {
                    Id = 8,
                    TermoPortugues = "Cancelamento",
                    DescricaoSinal = "Mão dominante em configuração de 'X' realiza movimento " +
                                     "cruzado à frente do corpo indicando anulação.",
                    ContextoUso = "Quando uma atividade é cancelada ou o participante desiste da inscrição.",
                    Categoria = "Evento",
                    VideoUrl = "/assets/libras/cancelamento.mp4"
                },
                new TermoLibras
                {
                    Id = 9,
                    TermoPortugues = "Programação (de evento)",
                    DescricaoSinal = "Ambas as mãos em configuração aberta com dedos estendidos " +
                                     "simulam uma lista organizada movendo-se de cima para baixo " +
                                     "representando itens sequenciais de uma agenda.",
                    ContextoUso = "Grade horária com todas as atividades do evento organizadas por dia e hora.",
                    Categoria = "Evento",
                    VideoUrl = "/assets/libras/programacao.mp4"
                },
                new TermoLibras
                {
                    Id = 10,
                    TermoPortugues = "Palestrante",
                    DescricaoSinal = "Sinal de PALESTRA seguido do sinal de PESSOA " +
                                     "(mão dominante em 'P' desce à frente do corpo).",
                    ContextoUso = "Profissional convidado que ministra uma palestra no evento.",
                    Categoria = "Pessoa",
                    VideoUrl = "/assets/libras/palestrante.mp4"
                },
                new TermoLibras
                {
                    Id = 11,
                    TermoPortugues = "Workshop",
                    DescricaoSinal = "Soletração W-S seguida do sinal de OFICINA " +
                                     "(mãos simulando trabalho manual/prático).",
                    ContextoUso = "Atividade prática onde os participantes realizam exercícios guiados.",
                    Categoria = "Atividade",
                    VideoUrl = "/assets/libras/workshop.mp4"
                },
                new TermoLibras
                {
                    Id = 12,
                    TermoPortugues = "Acessibilidade",
                    DescricaoSinal = "Sinal de ACESSO (mão dominante passa por abertura formada " +
                                     "pela mão de apoio) seguido de POSSÍVEL (polegar para cima) " +
                                     "indicando que todos podem acessar.",
                    ContextoUso = "Garantia de que pessoas com deficiência possam participar plenamente do evento.",
                    Categoria = "Inclusão",
                    VideoUrl = "/assets/libras/acessibilidade.mp4"
                },
                new TermoLibras
                {
                    Id = 13,
                    TermoPortugues = "Intérprete",
                    DescricaoSinal = "Ambas as mãos em configuração de 'I' alternam " +
                                     "movimentos de rotação à frente do corpo " +
                                     "representando a tradução entre duas línguas.",
                    ContextoUso = "Profissional que traduz entre Libras e Português durante as atividades.",
                    Categoria = "Pessoa",
                    VideoUrl = "/assets/libras/interprete.mp4"
                },
                new TermoLibras
                {
                    Id = 14,
                    TermoPortugues = "Feedback",
                    DescricaoSinal = "Sinal de RESPOSTA (mão dominante parte da boca em direção " +
                                     "ao interlocutor) combinado com RETORNO (movimento de volta).",
                    ContextoUso = "Avaliação e opinião do participante sobre a atividade para melhoria contínua.",
                    Categoria = "Comunicação",
                    VideoUrl = "/assets/libras/feedback.mp4"
                },
                new TermoLibras
                {
                    Id = 15,
                    TermoPortugues = "Encerramento",
                    DescricaoSinal = "Ambas as mãos abertas se fecham simultaneamente " +
                                     "em movimento para baixo indicando finalização.",
                    ContextoUso = "Cerimônia final do evento com premiações e entrega de certificados.",
                    Categoria = "Evento",
                    VideoUrl = "/assets/libras/encerramento.mp4"
                }
            };

            CsvHelper<TermoLibras>.EscreverCsv(caminho, termos);
        }
    }
}
