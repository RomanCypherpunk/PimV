# CLAUDE.md — Instruções do Projeto PIM V

> **Atualizado em:** 2026-03-18
> **Autor:** Enzo Xavier Santos (RA: 2620639)
> **Curso:** Análise e Desenvolvimento de Sistemas — UNIP EaD — 2o semestre

---

## Objetivo do Projeto

**PIM V (Projeto Integrado Multidisciplinar V)** — Criação de um **ambiente virtual responsivo para eventos acadêmicos inclusivos** na área de Tecnologia da Informação, com foco em acessibilidade e inclusão de pessoas surdas por meio da Língua Brasileira de Sinais (Libras).

O projeto é um **site completo** para a **"Semana de TI Inclusiva UNIP 2026"**, composto por:
- **Backend:** API REST em ASP.NET Core (C#) com persistência em arquivos CSV
- **Frontend:** Site responsivo em HTML/CSS/JS vanilla (sem frameworks)
- **Documentação:** Documento acadêmico em formato ABNT (15-20 páginas)

### Disciplinas Integradas

| Disciplina | Entrega Principal |
|---|---|
| **Desenvolvimento Web Responsivo** | Frontend HTML/CSS/JS responsivo (mobile-first, 375px → 1280px) |
| **POO com C#** | API REST com ASP.NET Core, models, services, herança, interfaces, enums |
| **Comunicação, Liderança e Negociação** | Documento acadêmico ABNT — fundamentação teórica sobre inclusão |
| **Libras** | Glossário de termos de TI em Libras, suporte a intérprete, demanda de intérpretes |

### Prazo de Entrega

**23 de março de 2026** — entrega final do PIM V (código + documentação).

---

## Stack Tecnológica

| Camada | Tecnologia | Porta |
|---|---|---|
| Backend | ASP.NET Core 9 Web API (C#) | `localhost:5000` |
| Frontend | HTML5 + CSS3 + JavaScript vanilla | `localhost:8080` (python http.server) |
| Dados | Arquivos CSV (sem banco de dados) | `./data/*.csv` |
| Documentação | ABNT — PDF/DOCX | `./docs/` |

### Como Rodar

```bash
# Backend (API)
cd backend/EventosAPI
dotnet run
# → http://localhost:5000 (Swagger: /swagger)

# Frontend (servidor estático)
cd frontend
python -m http.server 8080
# → http://localhost:8080
```

---

## Estrutura de Pastas

```
PIM_V/
├── backend/
│   └── EventosAPI/
│       ├── Controllers/        # 8 controllers REST
│       │   ├── AtividadesController.cs
│       │   ├── CertificadosController.cs
│       │   ├── EventosController.cs
│       │   ├── FeedbacksController.cs
│       │   ├── GlossarioLibrasController.cs
│       │   ├── InscricoesController.cs
│       │   ├── NotificacoesController.cs
│       │   └── ParticipantesController.cs
│       ├── Models/             # 9 models (herança Pessoa → Participante)
│       │   ├── Pessoa.cs       # Classe base abstrata
│       │   ├── Participante.cs # Herda de Pessoa
│       │   ├── UsuarioAdmin.cs # Herda de Pessoa
│       │   ├── Evento.cs
│       │   ├── Atividade.cs
│       │   ├── Inscricao.cs
│       │   ├── Certificado.cs
│       │   ├── Feedback.cs
│       │   ├── Notificacao.cs
│       │   └── TermoLibras.cs
│       ├── Services/           # 8 services (lógica de negócio)
│       ├── Interfaces/         # ICertificavel, ICsvPersistivel
│       ├── Enums/              # StatusInscricao, TipoAtividade, TipoNotificacao
│       ├── Data/
│       │   ├── CsvHelper.cs    # Leitura/escrita CSV genérica
│       │   ├── SeedData.cs     # Dados iniciais (evento, atividades, glossário)
│       │   └── csv/            # CSVs em runtime (gitignored)
│       └── Program.cs          # Entry point, DI, CORS, Swagger
├── frontend/
│   ├── index.html              # Página inicial (hero, about, atividades destaque)
│   ├── pages/
│   │   ├── programacao.html    # Programação completa (filtros por tipo + abas por dia)
│   │   ├── inscricao.html      # Inscrição multi-step (dados → atividade → confirmação)
│   │   ├── area-participante.html # Dashboard (stats, notificações, inscrições, feedback)
│   │   ├── certificados.html   # Validação por código + busca por CPF
│   │   └── libras.html         # Glossário com busca/filtro + cards de demanda
│   └── assets/
│       ├── css/
│       │   ├── reset.css       # Reset CSS
│       │   ├── variables.css   # Tokens de design (cores, fontes, sombras, espaçamento)
│       │   └── style.css       # Estilos principais (~1200 linhas)
│       └── js/
│           ├── utils.js        # API helpers (fetch), formatação, alertas, sessão localStorage
│           └── main.js         # Lógica de todas as páginas (renderização, filtros, forms)
├── data/                       # CSVs gerados pela API (gitignored)
├── docs/
│   ├── Manual PIMV.pdf         # Manual oficial do PIM V
│   ├── Slide de Aula (Orientações_PIM).pdf
│   ├── brand_kit_dominio_visual.md   # Brand kit completo
│   └── brand_kit_dominio_visual.pdf
├── .gitignore
└── CLAUDE.md                   # ← Este arquivo
```

---

## Brand Kit — "Domínio Visual"

**Referência completa:** `docs/brand_kit_dominio_visual.md`

### Cores Principais

| Token CSS | Hex | Uso |
|---|---|---|
| `--olive-dark` | `#3B4211` | Fundos hero, seções principais |
| `--olive-mid` | `#4D5520` | Transições |
| `--olive` | `#60682D` | Cards, destaques |
| `--olive-light` | `#7C8A1E` | Ícones, checks |
| `--gold-pale` | `#FDF383` | Headlines destacadas |
| `--gold` | `#EAAF21` | CTAs, botões primários |
| `--gold-deep` | `#C98F0A` | Gradiente CTA |
| `--dark` | `#1D1F1C` | Body background |
| `--dark-footer` | `#0F1008` | Footer |

### Tipografia

| Variável | Fonte | Uso |
|---|---|---|
| `--font-h` | **Sora** (300-800) | Headings, labels, badges |
| `--font-b` | **Poppins** (300-700) | Body text, parágrafos |

### Estilo Visual

- **Glassmorphism:** `backdrop-filter: blur(12px)`, backgrounds `rgba(255,255,255,0.04)`, `box-shadow` com inset
- **Border Radius:** sistema de tokens (`--r-sm: 8px` → `--r-pill: 100px`)
- **Sombras:** 3 níveis (`--shadow-sm`, `--shadow-md`, `--shadow-lg`)
- **Ícones:** SVG inline (Material Design paths) — **NUNCA usar emojis como ícones**

---

## Design & Responsividade

### Breakpoints

| Breakpoint | Dispositivo | Comportamento |
|---|---|---|
| **375px** | Mobile (iPhone SE) | Single column, hamburger menu, font-size menor |
| **560px** | Tablet pequeno | Transição para 2 colunas em grids |
| **768px** | Tablet (iPad) | 2 colunas, hamburger menu (< 900px) |
| **900px** | Navbar desktop | Navbar troca de hamburger para links inline |
| **1024px** | Desktop | Layout completo, 3 colunas em grids |
| **1280px** | Desktop wide | Max-width container 1180px centralizado |

### Acessibilidade (Implementado)

- `*:focus-visible` — outline 2px solid gold-pale com offset
- `@media (prefers-reduced-motion: reduce)` — desabilita animações
- Touch targets mínimos: **44px** (buttons, links, inputs)
- Inputs com `min-height: 48px` e `font-size: 1rem` (evita zoom no iOS)
- Heading hierarchy sequencial (h1 → h2 → h3)
- `aria-label` em botões de ícone e navegação
- Contraste de texto ≥ 4.5:1

### Convenções CSS

- Transições: `0.25s ease-out` (micro-interações)
- Cards glassmorphic: `backdrop-filter: blur(12px)`, `border: 1px solid rgba(255,255,255,0.06)`
- Scrollbar hidden em containers horizontais: `scrollbar-width: none` + `::-webkit-scrollbar { display: none }`
- Navbar usa breakpoint `900px` (não 768px) para evitar layout cramped no tablet

---

## API REST — Endpoints

**Base URL:** `http://localhost:5000/api`

| Método | Endpoint | Descrição |
|---|---|---|
| GET | `/eventos` | Lista todos os eventos |
| GET | `/eventos/{id}` | Evento por ID |
| GET | `/atividades` | Lista todas as atividades |
| GET | `/atividades/{id}` | Atividade por ID |
| GET | `/atividades/evento/{eventoId}` | Atividades de um evento |
| POST | `/participantes` | Cadastrar participante |
| GET | `/participantes/cpf/{cpf}` | Buscar por CPF |
| POST | `/inscricoes` | Criar inscrição |
| PATCH | `/inscricoes/{id}/cancelar` | Cancelar inscrição |
| GET | `/inscricoes/participante/{id}` | Inscrições de um participante |
| GET | `/notificacoes/participante/{id}` | Notificações de um participante |
| GET | `/certificados/participante/{cpf}` | Certificados por CPF |
| GET | `/certificados/validar/{codigo}` | Validar certificado por código |
| POST | `/feedbacks` | Enviar feedback |
| GET | `/glossario-libras` | Lista todos os termos |
| GET | `/glossario-libras/categoria/{cat}` | Termos por categoria |
| GET | `/glossario-libras/busca?termo=...` | Buscar termos |

### Conceitos OOP Aplicados

- **Herança:** `Pessoa` (abstrata) → `Participante`, `UsuarioAdmin`
- **Interfaces:** `ICertificavel` (emissão de certificados), `ICsvPersistivel<T>` (persistência genérica)
- **Enums:** `TipoAtividade`, `StatusInscricao`, `TipoNotificacao`
- **Encapsulamento:** Properties com validação nos Services
- **Polimorfismo:** Serviços implementando interfaces com comportamento específico

---

## Convenção de Commits

Seguimos **Conventional Commits** em português:

```
<tipo>(<escopo>): <descrição curta>
```

### Tipos permitidos

| Tipo | Quando usar |
|---|---|
| `feat` | Nova funcionalidade |
| `fix` | Correção de bug |
| `refactor` | Refatoração sem mudar funcionalidade |
| `style` | Formatação, CSS, sem lógica |
| `docs` | Documentação |
| `chore` | Configuração, .gitignore, setup |
| `test` | Testes |

### Escopos comuns

| Escopo | Quando |
|---|---|
| `frontend` | Alterações em HTML/CSS/JS |
| `backend` | Alterações na API C# |
| `docs` | Documentação acadêmica |
| `config` | .gitignore, launch.json, etc. |

### Exemplos

```
feat(backend): criação completa da API EventosAPI
feat(frontend): criação completa do front-end responsivo
fix(frontend): ajustes de responsividade
refactor(frontend): melhorias de acessibilidade e UI/UX
chore: remover .claude do repositório e adicionar ao .gitignore
docs: adicionar documento acadêmico ABNT
```

### Regras

- **NÃO incluir co-author do Claude** — o projeto não pode parecer gerado por IA
- Mensagens em **português**
- Descrição curta, máximo ~72 caracteres

---

## Status das Tarefas

### Concluído

- [x] **Backend completo** — API com 8 controllers, 8 services, models com OOP, seed data
- [x] **Frontend completo** — 6 páginas HTML responsivas com glassmorphism
- [x] **Bugs corrigidos** — títulos undefined, programação não carregando, ícones Libras, emojis→SVG
- [x] **Responsividade testada** — todas as 6 páginas em 375px, 768px, 1280px
- [x] **Acessibilidade** — focus-visible, reduced-motion, touch targets, aria-labels
- [x] **GitHub configurado** — repositório PimV, .claude no .gitignore, sem co-author
- [x] **Brand kit aplicado** — cores oliva+dourado, Sora+Poppins, glassmorphism

### Pendente

- [ ] **Documento acadêmico ABNT** — 15-20 páginas (fundamentação teórica + desenvolvimento técnico)
- [ ] **Commits organizados** — commitar todas as alterações pendentes
- [ ] **Revisão final** — testar fluxo completo (cadastro → inscrição → certificado)

---

## Regras para o Claude

1. **NUNCA adicionar co-author** nos commits — usar commits limpos
2. **NUNCA usar emojis como ícones** — sempre SVG inline
3. **Seguir o Brand Kit** — cores, fontes e estilo visual conforme `docs/brand_kit_dominio_visual.md`
4. **Mobile-first** — testar sempre em 375px primeiro
5. **Breakpoint do navbar é 900px** (não 768px)
6. **API roda em localhost:5000**, frontend em localhost:8080
7. **Persistência em CSV** — sem banco de dados
8. **Atualizar este CLAUDE.md** a cada nova movimentação significativa no projeto
9. **Conventional Commits em português** — sem co-author, mensagens claras
10. **Acessibilidade obrigatória** — focus states, aria-labels, contraste, reduced-motion
11. **Commit + push automático** — após cada alteração significativa, commitar e fazer push sem perguntar
12. **Atualizar o CLAUDE.md** junto com o commit quando houver mudança relevante no projeto

---

## Histórico de Alterações

| Data | O que foi feito |
|---|---|
| 2026-03-17 | Criação completa do backend (API + models + services + seed) |
| 2026-03-17 | Criação completa do frontend (6 páginas responsivas) |
| 2026-03-17 | Correção de bugs (undefined titles, programação, Libras icons) |
| 2026-03-17 | GitHub setup (.gitignore, .claude oculto, repositório PimV) |
| 2026-03-18 | Refatoração CSS: acessibilidade, glassmorphism, touch targets, UI/UX |
| 2026-03-18 | Teste de responsividade completo (6 páginas × 3 breakpoints) |
| 2026-03-18 | Fix: scrollbar hidden nos day-tabs da programação |
| 2026-03-18 | Criação do CLAUDE.md com instruções completas do projeto |
