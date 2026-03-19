# Semana de TI Inclusiva UNIP 2026

Ambiente virtual responsivo para eventos acadêmicos inclusivos na área de Tecnologia da Informação, com foco em **acessibilidade** e inclusão de pessoas surdas por meio da **Língua Brasileira de Sinais (Libras)**.

Este projeto foi desenvolvido como **Projeto Integrado Multidisciplinar V (PIM V)** do curso de Análise e Desenvolvimento de Sistemas da UNIP EaD, integrando quatro disciplinas em uma solução web completa.

---

## Sobre o Projeto

O sistema é um site completo para a **"Semana de TI Inclusiva UNIP 2026"** — um evento acadêmico fictício de 5 dias com palestras, minicursos, workshops e hackathon. O diferencial é o foco em **inclusão digital**: suporte a intérprete de Libras nas atividades, glossário de termos técnicos em Libras, e interface totalmente acessível.

### Disciplinas Integradas

| Disciplina | O que foi entregue |
|---|---|
| **Desenvolvimento Web Responsivo** | Frontend HTML/CSS/JS responsivo (mobile-first, 375px a 1280px) |
| **Programação Orientada a Objetos com C#** | API REST com ASP.NET Core — herança, interfaces, enums, encapsulamento |
| **Comunicação, Liderança e Negociação** | Documento acadêmico ABNT com fundamentação teórica sobre inclusão |
| **Libras** | Glossário de termos de TI em Libras, suporte a intérprete, relatório de demanda |

---

## Funcionalidades

### Página Inicial
- Hero section com informações do evento
- Seção "Sobre" com detalhes e destaques
- Cards das atividades em destaque
- Contador de estatísticas do evento

### Programação Completa
- Grade de atividades organizadas por dia (abas por data)
- Filtros por tipo de atividade (palestra, minicurso, workshop, hackathon, etc.)
- Indicador visual de atividades com intérprete de Libras
- Exibição de vagas disponíveis em tempo real

### Inscrição Multi-Step
- Formulário em 3 etapas: dados pessoais, escolha de atividade, confirmação
- Opção para solicitar intérprete de Libras
- Validação de CPF e e-mail únicos
- Controle automático de vagas

### Área do Participante
- Login por CPF (sem senha — escopo acadêmico)
- Dashboard com estatísticas pessoais
- Lista de inscrições com opção de cancelamento
- Central de notificações (confirmações, lembretes)
- Envio de feedback sobre as atividades

### Certificados
- Validação de certificado por código único
- Busca de certificados por CPF
- Exibição dos dados do certificado (participante, atividade, carga horária)

### Glossário de Libras
- 15 termos técnicos de TI com descrição do sinal em Libras
- Busca por texto e filtro por categoria
- Contexto de uso de cada termo
- Cards com relatório de demanda por intérprete

---

## Stack Tecnológica

| Camada | Tecnologia |
|---|---|
| **Backend** | ASP.NET Core 9 (C#) — API REST |
| **Frontend** | HTML5 + CSS3 + JavaScript vanilla (sem frameworks) |
| **Dados** | Arquivos CSV (sem banco de dados) |
| **Documentação** | Swagger (OpenAPI) |

---

## Como Rodar

### Pré-requisitos

- [.NET SDK 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Python 3](https://www.python.org/downloads/) (para servir o frontend)
- [Git](https://git-scm.com/)

### 1. Clone o repositório

```bash
git clone https://github.com/RomanCypherpunk/PimV.git
cd PimV
```

### 2. Suba o Backend (API)

```bash
cd backend/EventosAPI
dotnet run
```

A API estará disponível em `http://localhost:5000`.
A documentação interativa (Swagger) estará em `http://localhost:5000/swagger`.

### 3. Suba o Frontend

Em outro terminal:

```bash
cd frontend
python -m http.server 8080
```

O site estará disponível em `http://localhost:8080`.

### 4. Pronto!

Acesse `http://localhost:8080` no navegador. A API e o frontend precisam estar rodando simultaneamente.

Para encerrar, pressione `Ctrl+C` em cada terminal.

---

## Testando o Fluxo Completo

Siga estes passos para testar todas as funcionalidades do sistema:

1. **Acesse a página inicial** (`http://localhost:8080`) — veja o evento e as atividades em destaque
2. **Veja a programação** — navegue pelas abas dos dias e filtre por tipo de atividade
3. **Faça uma inscrição** — preencha os dados, escolha uma atividade e confirme
4. **Acesse a área do participante** — entre com o CPF cadastrado e veja suas inscrições e notificações
5. **Envie um feedback** — avalie a atividade em que se inscreveu
6. **Consulte certificados** — busque por CPF na página de certificados
7. **Explore o glossário de Libras** — pesquise termos técnicos e veja as descrições dos sinais

### Testando a API pelo Swagger

Acesse `http://localhost:5000/swagger` para testar os endpoints diretamente:

```
GET  /api/eventos                          → Lista o evento
GET  /api/atividades                       → Lista as 9 atividades
POST /api/participantes                    → Cadastra participante (enviar JSON)
POST /api/inscricoes                       → Inscreve em uma atividade
GET  /api/inscricoes?cpf=12345678901       → Inscrições por CPF
GET  /api/notificacoes/participante/{id}   → Notificações do participante
GET  /api/certificados/participante/{cpf}  → Certificados por CPF
GET  /api/certificados/validar/{codigo}    → Valida certificado por código
POST /api/feedbacks                        → Envia feedback
GET  /api/glossario-libras                 → Glossário completo de Libras
GET  /api/glossario-libras/busca?termo=... → Busca no glossário
```

---

## Arquitetura do Backend

### Estrutura de Pastas

```
backend/EventosAPI/
├── Controllers/     → Endpoints da API (recebem requisições HTTP)
├── Models/          → Classes que definem a estrutura dos dados
├── Services/        → Lógica de negócio (validações, regras, CRUD)
├── Interfaces/      → Contratos (ICertificavel, ICsvPersistivel)
├── Enums/           → Tipos enumerados (TipoAtividade, StatusInscricao)
├── Data/            → Persistência em CSV e dados iniciais (seed)
└── Program.cs       → Configuração da aplicação (DI, CORS, Swagger)
```

### Conceitos de Programação Orientada a Objetos

| Conceito | Implementação |
|---|---|
| **Herança** | `Pessoa` (abstrata) → `Participante`, `UsuarioAdmin` |
| **Classe Abstrata** | `Pessoa` define a estrutura base, não pode ser instanciada diretamente |
| **Encapsulamento** | Campos privados com validação nos setters (CPF, e-mail, nome) |
| **Polimorfismo** | Método `ObterDescricao()` — cada subclasse implementa sua versão |
| **Interfaces** | `ICsvPersistivel<T>` (persistência genérica), `ICertificavel` (emissão de certificados) |
| **Enums** | `TipoAtividade` (Palestra, Minicurso, Workshop...), `StatusInscricao`, `TipoNotificacao` |

### Diagrama Simplificado

```
Pessoa (abstrata)
├── Participante    → se inscreve em atividades, recebe certificados
└── UsuarioAdmin    → administra o evento

Evento
└── Atividade       → pertence a um evento, tem vagas e tipo
    └── Inscricao   → vincula participante a atividade
        ├── Certificado  → emitido ao concluir
        ├── Feedback     → avaliação do participante
        └── Notificacao  → alertas automáticos

TermoLibras         → glossário independente de termos técnicos em Libras
```

---

## Frontend

### Estrutura

```
frontend/
├── index.html              → Página inicial (hero, sobre, destaques)
├── pages/
│   ├── programacao.html    → Grade de atividades com filtros e abas
│   ├── inscricao.html      → Formulário multi-step de inscrição
│   ├── area-participante.html → Dashboard do participante
│   ├── certificados.html   → Validação e busca de certificados
│   └── libras.html         → Glossário de Libras com busca
└── assets/
    ├── css/
    │   ├── reset.css       → Reset CSS
    │   ├── variables.css   → Design tokens (cores, fontes, espaçamento)
    │   └── style.css       → Estilos principais
    └── js/
        ├── utils.js        → Helpers de API, formatação, sessão
        └── main.js         → Lógica de todas as páginas
```

### Design e Responsividade

- **Mobile-first** — projetado a partir de 375px (iPhone SE) até 1280px (desktop)
- **Estilo Glassmorphism** — cards com `backdrop-filter: blur()`, transparências e bordas sutis
- **Paleta Oliva + Dourado** — tons terrosos com acentos dourados para CTAs
- **Tipografia** — Sora (headings) + Poppins (corpo de texto)
- **Sem frameworks CSS** — todo o estilo escrito do zero

### Acessibilidade

- `focus-visible` em todos os elementos interativos
- `prefers-reduced-motion` — desabilita animações para quem prefere
- Touch targets mínimos de 44px
- Inputs com `min-height: 48px` (evita zoom automático no iOS)
- Hierarquia de headings sequencial (h1 → h2 → h3)
- `aria-label` em botões de ícone e navegação
- Contraste de texto acima de 4.5:1

---

## Endpoints da API

| Método | Endpoint | Descrição |
|---|---|---|
| `GET` | `/api/eventos` | Lista todos os eventos |
| `GET` | `/api/eventos/{id}` | Busca evento por ID |
| `GET` | `/api/atividades` | Lista todas as atividades |
| `GET` | `/api/atividades/{id}` | Busca atividade por ID |
| `GET` | `/api/atividades/evento/{eventoId}` | Atividades de um evento |
| `POST` | `/api/participantes` | Cadastra novo participante |
| `GET` | `/api/participantes/cpf/{cpf}` | Busca participante por CPF |
| `POST` | `/api/inscricoes` | Cria inscrição em atividade |
| `PATCH` | `/api/inscricoes/{id}/cancelar` | Cancela inscrição |
| `PATCH` | `/api/inscricoes/{id}/concluir` | Conclui inscrição (presença) |
| `GET` | `/api/inscricoes?cpf={cpf}` | Inscrições por CPF |
| `GET` | `/api/notificacoes/participante/{id}` | Notificações do participante |
| `GET` | `/api/certificados/participante/{cpf}` | Certificados por CPF |
| `GET` | `/api/certificados/validar/{codigo}` | Valida certificado por código |
| `POST` | `/api/feedbacks` | Envia feedback de atividade |
| `GET` | `/api/glossario-libras` | Lista todos os termos de Libras |
| `GET` | `/api/glossario-libras/categoria/{cat}` | Termos por categoria |
| `GET` | `/api/glossario-libras/busca?termo={texto}` | Busca termos de Libras |

---

## Autor

**Enzo Xavier Santos**
Análise e Desenvolvimento de Sistemas — UNIP EaD — 2026