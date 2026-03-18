/* ========================================
   MAIN — Lógica de cada página
   ======================================== */

/* ── SVG Icons (substituem emojis) ── */
const SVG = {
  calendar: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M19 3h-1V1h-2v2H8V1H6v2H5c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm0 16H5V8h14v11zM9 10H7v2h2v-2zm4 0h-2v2h2v-2zm4 0h-2v2h2v-2z"/></svg>',
  clock: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M11.99 2C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8zm.5-13H11v6l5.25 3.15.75-1.23-4.5-2.67V7z"/></svg>',
  people: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M16 11c1.66 0 2.99-1.34 2.99-3S17.66 5 16 5c-1.66 0-3 1.34-3 3s1.34 3 3 3zm-8 0c1.66 0 2.99-1.34 2.99-3S9.66 5 8 5C6.34 5 5 6.34 5 8s1.34 3 3 3zm0 2c-2.33 0-7 1.17-7 3.5V19h14v-2.5c0-2.33-4.67-3.5-7-3.5zm8 0c-.29 0-.62.02-.97.05 1.16.84 1.97 1.97 1.97 3.45V19h6v-2.5c0-2.33-4.67-3.5-7-3.5z"/></svg>',
  libras: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M20 7c0-.55-.45-1-1-1s-1 .45-1 1v4h-1V4c0-.55-.45-1-1-1s-1 .45-1 1v7h-1V3c0-.55-.45-1-1-1s-1 .45-1 1v8h-1V5c0-.55-.45-1-1-1s-1 .45-1 1v10l-2.7-2.7c-.39-.39-1.02-.39-1.41 0s-.39 1.02 0 1.41L9.53 18.36C10.46 19.29 11.73 20 13 20h3c2.76 0 5-2.24 5-5V7z"/></svg>',
  location: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7zm0 9.5c-1.38 0-2.5-1.12-2.5-2.5s1.12-2.5 2.5-2.5 2.5 1.12 2.5 2.5-1.12 2.5-2.5 2.5z"/></svg>',
  speaker: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z"/></svg>',
  check: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm-2 15l-5-5 1.41-1.41L10 14.17l7.59-7.59L19 8l-9 9z"/></svg>',
  checkLg: '<svg width="48" height="48" viewBox="0 0 24 24" fill="var(--olive-accent)"><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm-2 15l-5-5 1.41-1.41L10 14.17l7.59-7.59L19 8l-9 9z"/></svg>',
  errorLg: '<svg width="48" height="48" viewBox="0 0 24 24" fill="#f0a0a0"><path d="M12 2C6.47 2 2 6.47 2 12s4.47 10 10 10 10-4.47 10-10S17.53 2 12 2zm5 13.59L15.59 17 12 13.41 8.41 17 7 15.59 10.59 12 7 8.41 8.41 7 12 10.59 15.59 7 17 8.41 13.41 12 17 15.59z"/></svg>',
  search: '<svg width="14" height="14" viewBox="0 0 24 24" fill="currentColor"><path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z"/></svg>'
};

document.addEventListener('DOMContentLoaded', () => {
  initNavbar();
  initReveal();

  const path = window.location.pathname;

  if (path.endsWith('index.html') || path.endsWith('/') || path.endsWith('/frontend/')) {
    initHome();
  } else if (path.includes('programacao')) {
    initProgramacao();
  } else if (path.includes('inscricao')) {
    initInscricao();
  } else if (path.includes('area-participante')) {
    initAreaParticipante();
  } else if (path.includes('certificados')) {
    initCertificados();
  } else if (path.includes('libras')) {
    initLibras();
  }
});

/* ── Helper: calcular horário de término ── */
function calcularHorarioFim(dataHora, duracaoMinutos) {
  const d = new Date(dataHora);
  d.setMinutes(d.getMinutes() + duracaoMinutos);
  return d.toISOString();
}

/* ════════════════════════════════════════
   HOME (index.html)
   ════════════════════════════════════════ */
async function initHome() {
  try {
    const atividades = await GET('/atividades?eventoId=1');
    const container = document.getElementById('atividades-destaque');
    if (!container) return;

    const destaque = atividades.slice(0, 4);
    container.innerHTML = destaque.map(a => cardAtividadeHTML(a)).join('');
    initReveal();
  } catch (err) {
    console.error('Erro ao carregar atividades:', err);
  }
}

/* ════════════════════════════════════════
   PROGRAMACAO
   ════════════════════════════════════════ */
let todasAtividades = [];
let filtroTipoAtual = 'todos';
let filtroDiaAtual = 'todos';

async function initProgramacao() {
  try {
    todasAtividades = await GET('/atividades?eventoId=1');
    renderDayTabs();
    renderAtividades();
    initFiltroTipo();
  } catch (err) {
    document.getElementById('lista-atividades').innerHTML =
      '<p class="text-muted">Erro ao carregar programacao.</p>';
  }
}

function renderDayTabs() {
  const datas = [...new Set(todasAtividades.map(a => a.dataHora.split('T')[0]))].sort();
  const container = document.getElementById('tabs-dia');
  if (!container) return;

  let html = '<button class="day-tab active" data-dia="todos">Todos os Dias</button>';
  datas.forEach((d, i) => {
    const date = new Date(d + 'T12:00:00');
    const label = date.toLocaleDateString('pt-BR', { weekday: 'short', day: '2-digit', month: '2-digit' });
    html += `<button class="day-tab" data-dia="${d}">Dia ${i + 1} — ${label}</button>`;
  });
  container.innerHTML = html;

  container.querySelectorAll('.day-tab').forEach(btn => {
    btn.addEventListener('click', () => {
      container.querySelectorAll('.day-tab').forEach(b => b.classList.remove('active'));
      btn.classList.add('active');
      filtroDiaAtual = btn.dataset.dia;
      renderAtividades();
    });
  });
}

function initFiltroTipo() {
  document.querySelectorAll('#filtros-tipo .filter-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      document.querySelectorAll('#filtros-tipo .filter-btn').forEach(b => b.classList.remove('active'));
      btn.classList.add('active');
      filtroTipoAtual = btn.dataset.tipo;
      renderAtividades();
    });
  });
}

function renderAtividades() {
  let filtradas = [...todasAtividades];

  if (filtroTipoAtual === 'libras') {
    filtradas = filtradas.filter(a => a.temInterpreteLibras);
  } else if (filtroTipoAtual !== 'todos') {
    filtradas = filtradas.filter(a => a.tipo === filtroTipoAtual);
  }

  if (filtroDiaAtual !== 'todos') {
    filtradas = filtradas.filter(a => a.dataHora.startsWith(filtroDiaAtual));
  }

  const container = document.getElementById('lista-atividades');
  if (!filtradas.length) {
    container.innerHTML = '<div class="empty-state"><p>Nenhuma atividade encontrada com esses filtros.</p></div>';
    return;
  }

  container.innerHTML = `<div class="grid grid--2">${filtradas.map(a => cardAtividadeHTML(a)).join('')}</div>`;
  initReveal();
}

/* ════════════════════════════════════════
   INSCRICAO
   ════════════════════════════════════════ */
let participanteAtual = null;

async function initInscricao() {
  const sessao = obterSessao();
  if (sessao) {
    participanteAtual = sessao;
    mostrarStepAtividade();
  }

  document.getElementById('form-participante').addEventListener('submit', async (e) => {
    e.preventDefault();
    await cadastrarParticipante();
  });

  document.getElementById('btn-voltar-dados').addEventListener('click', () => {
    document.getElementById('step-atividade').style.display = 'none';
    document.getElementById('step-dados').style.display = 'block';
  });

  document.getElementById('btn-nova-inscricao').addEventListener('click', () => {
    document.getElementById('step-confirmacao').style.display = 'none';
    mostrarStepAtividade();
  });
}

async function cadastrarParticipante() {
  const nome = document.getElementById('nome').value.trim();
  const email = document.getElementById('email').value.trim();
  const cpf = document.getElementById('cpf').value.trim();
  const instituicao = document.getElementById('instituicao').value.trim();
  const telefone = document.getElementById('telefone').value.trim();
  const necessitaLibras = document.getElementById('necessitaLibras').checked;

  if (!nome || !email || !cpf) {
    mostrarAlerta('alert-inscricao', 'error', 'Preencha Nome, E-mail e CPF.');
    return;
  }

  if (cpf.length !== 11 || !/^\d+$/.test(cpf)) {
    mostrarAlerta('alert-inscricao', 'error', 'CPF deve conter 11 digitos numericos.');
    return;
  }

  try {
    let participante;
    try {
      participante = await GET(`/participantes/cpf/${cpf}`);
    } catch {
      participante = await POST('/participantes', {
        nome, email, cpf, instituicao, telefone,
        necessitaInterpreteLibras: necessitaLibras
      });
    }

    participanteAtual = participante;
    salvarSessao(participante);
    mostrarStepAtividade();
  } catch (err) {
    mostrarAlerta('alert-inscricao', 'error', err.message);
  }
}

async function mostrarStepAtividade() {
  document.getElementById('step-dados').style.display = 'none';
  document.getElementById('step-confirmacao').style.display = 'none';
  document.getElementById('step-atividade').style.display = 'block';
  document.getElementById('nome-participante').textContent = participanteAtual.nome;

  try {
    const atividades = await GET('/atividades?eventoId=1');
    const container = document.getElementById('lista-atividades-inscricao');

    container.innerHTML = atividades.map(a => `
      <div class="card-atividade" style="margin-bottom:0.75rem;">
        <div class="card-atividade__header">
          <h4 class="card-atividade__title">${a.titulo}</h4>
          <span class="label label--gold">${tipoAtividadeLabel(a.tipo)}</span>
        </div>
        <p class="text-muted" style="font-size:0.85rem;">${a.descricao || ''}</p>
        <div class="card-atividade__meta">
          <span class="card-atividade__info">${SVG.calendar} ${formatarData(a.dataHora)}</span>
          <span class="card-atividade__info">${SVG.clock} ${formatarHora(a.dataHora)} — ${formatarHora(calcularHorarioFim(a.dataHora, a.duracaoMinutos))}</span>
          <span class="card-atividade__info">${SVG.people} ${a.vagasDisponiveis} vagas</span>
          ${a.temInterpreteLibras ? `<span class="label label--libras" style="font-size:0.65rem;">${SVG.libras} Libras</span>` : ''}
        </div>
        <button class="btn-secondary" style="margin-top:1rem; width:100%;" onclick="inscrever(${a.id})" ${a.vagasDisponiveis <= 0 ? 'disabled style="opacity:0.5;margin-top:1rem;width:100%;"' : ''}>
          ${a.vagasDisponiveis > 0 ? 'Inscrever-se nesta atividade' : 'Sem vagas'}
        </button>
      </div>
    `).join('');
  } catch (err) {
    console.error(err);
  }
}

async function inscrever(atividadeId) {
  try {
    const inscricao = await POST('/inscricoes', {
      participanteId: participanteAtual.id,
      atividadeId: atividadeId
    });

    document.getElementById('step-atividade').style.display = 'none';
    document.getElementById('step-confirmacao').style.display = 'block';
    document.getElementById('msg-confirmacao').textContent =
      `Inscricao #${inscricao.id} confirmada com sucesso! Status: ${statusLabel(inscricao.status)}. Confira suas notificacoes na Minha Area.`;
  } catch (err) {
    mostrarAlerta('alert-inscricao', 'error', err.message);
  }
}

/* ════════════════════════════════════════
   AREA DO PARTICIPANTE
   ════════════════════════════════════════ */
async function initAreaParticipante() {
  const sessao = obterSessao();
  if (sessao) {
    await carregarPainel(sessao);
  }

  document.getElementById('btn-login').addEventListener('click', loginCPF);
  document.getElementById('cpf-login').addEventListener('keypress', (e) => {
    if (e.key === 'Enter') loginCPF();
  });
  document.getElementById('btn-logout').addEventListener('click', () => {
    limparSessao();
    document.getElementById('section-painel').style.display = 'none';
    document.getElementById('section-login').style.display = 'block';
  });
  document.getElementById('form-feedback').addEventListener('submit', enviarFeedback);
}

async function loginCPF() {
  const cpf = document.getElementById('cpf-login').value.trim();
  if (!cpf || cpf.length !== 11) {
    mostrarAlerta('alert-login', 'error', 'Informe um CPF valido com 11 digitos.');
    return;
  }
  try {
    const participante = await GET(`/participantes/cpf/${cpf}`);
    salvarSessao(participante);
    await carregarPainel(participante);
  } catch {
    mostrarAlerta('alert-login', 'error', 'CPF nao encontrado. Faca sua inscricao primeiro.');
  }
}

async function carregarPainel(participante) {
  document.getElementById('section-login').style.display = 'none';
  document.getElementById('section-painel').style.display = 'block';
  document.getElementById('painel-nome').textContent = participante.nome;
  document.getElementById('painel-email').textContent = participante.email;

  try {
    const [inscricoes, notifData, certificados, atividades] = await Promise.all([
      GET(`/inscricoes?cpf=${participante.cpf}`).catch(() => []),
      GET(`/notificacoes?participanteId=${participante.id}`).catch(() => []),
      GET(`/certificados?cpf=${participante.cpf}`).catch(() => []),
      GET('/atividades?eventoId=1').catch(() => [])
    ]);

    const ativas = inscricoes.filter(i => i.status === 'Confirmada');
    const concluidas = inscricoes.filter(i => i.status === 'Concluida');
    const naoLidas = notifData.filter(n => !n.lida);

    document.getElementById('stat-inscricoes').textContent = ativas.length;
    document.getElementById('stat-notificacoes').textContent = naoLidas.length;
    document.getElementById('stat-concluidas').textContent = concluidas.length;
    document.getElementById('stat-certificados').textContent = certificados.length;

    renderNotificacoes(notifData);
    renderInscricoesPainel(inscricoes, atividades);

    const selectAtiv = document.getElementById('feedback-atividade');
    selectAtiv.innerHTML = '<option value="">Selecione uma atividade...</option>';
    inscricoes.forEach(insc => {
      const ativ = atividades.find(a => a.id === insc.atividadeId);
      if (ativ) {
        selectAtiv.innerHTML += `<option value="${ativ.id}">${ativ.titulo}</option>`;
      }
    });

    initReveal();
  } catch (err) {
    console.error('Erro ao carregar painel:', err);
  }
}

function renderNotificacoes(notificacoes) {
  const container = document.getElementById('lista-notificacoes');
  if (!notificacoes.length) {
    container.innerHTML = '<div class="empty-state"><p>Nenhuma notificacao.</p></div>';
    return;
  }

  container.innerHTML = notificacoes.map(n => `
    <div class="notificacao-item ${!n.lida ? 'notificacao-item--nao-lida' : ''}">
      ${!n.lida ? '<div class="notificacao-item__badge"></div>' : '<div style="width:10px;"></div>'}
      <div class="notificacao-item__texto">
        <p style="font-size:0.9rem;">${n.mensagem}</p>
        <p class="notificacao-item__data">${formatarDataHora(n.dataEnvio)}</p>
      </div>
      ${!n.lida ? `<button class="btn-secondary" style="padding:0.4em 0.8em; font-size:0.72rem;" onclick="marcarLida(${n.id}, this)">Marcar lida</button>` : ''}
    </div>
  `).join('');
}

async function marcarLida(id, btn) {
  try {
    await PATCH(`/notificacoes/${id}/lida`);
    btn.closest('.notificacao-item').classList.remove('notificacao-item--nao-lida');
    btn.remove();
    const counter = document.getElementById('stat-notificacoes');
    counter.textContent = Math.max(0, parseInt(counter.textContent) - 1);
  } catch (err) {
    console.error(err);
  }
}

function renderInscricoesPainel(inscricoes, atividades) {
  const container = document.getElementById('lista-inscricoes-painel');
  if (!inscricoes.length) {
    container.innerHTML = '<div class="empty-state"><p>Nenhuma inscricao encontrada.</p></div>';
    return;
  }

  container.innerHTML = inscricoes.map(insc => {
    const ativ = atividades.find(a => a.id === insc.atividadeId);
    const titulo = ativ ? ativ.titulo : `Atividade #${insc.atividadeId}`;
    const statusClass = insc.status === 'Confirmada' ? 'label--olive' :
                        insc.status === 'Concluida' ? 'label--gold' : 'label--light';
    return `
      <div class="card-atividade" style="margin-bottom:0.75rem;">
        <div class="card-atividade__header">
          <h4 class="card-atividade__title">${titulo}</h4>
          <span class="label ${statusClass}">${statusLabel(insc.status)}</span>
        </div>
        <div class="card-atividade__meta">
          <span class="card-atividade__info">${SVG.calendar} Inscrito em ${formatarData(insc.dataInscricao)}</span>
          ${insc.solicitouInterpreteLibras ? `<span class="label label--libras" style="font-size:0.65rem;">${SVG.libras} Libras</span>` : ''}
        </div>
        ${insc.status === 'Confirmada' ? `<button class="btn-secondary" style="margin-top:0.75rem; font-size:0.8rem;" onclick="cancelarInscricao(${insc.id})">Cancelar Inscricao</button>` : ''}
      </div>
    `;
  }).join('');
}

async function cancelarInscricao(id) {
  if (!confirm('Tem certeza que deseja cancelar esta inscricao?')) return;
  try {
    await PATCH(`/inscricoes/${id}/cancelar`);
    const sessao = obterSessao();
    if (sessao) await carregarPainel(sessao);
  } catch (err) {
    alert(err.message);
  }
}

async function enviarFeedback(e) {
  e.preventDefault();
  const sessao = obterSessao();
  if (!sessao) return;

  const atividadeId = parseInt(document.getElementById('feedback-atividade').value);
  const nota = parseInt(document.getElementById('feedback-nota').value);
  const comentario = document.getElementById('feedback-comentario').value.trim();
  const sugestao = document.getElementById('feedback-sugestao').value.trim();

  if (!atividadeId || !nota) {
    mostrarAlerta('alert-feedback', 'error', 'Selecione a atividade e a nota.');
    return;
  }

  try {
    await POST('/feedbacks', {
      participanteId: sessao.id,
      atividadeId,
      nota,
      comentario,
      sugestao
    });
    mostrarAlerta('alert-feedback', 'success', 'Feedback enviado com sucesso! Obrigado pela sua avaliacao.');
    document.getElementById('form-feedback').reset();
  } catch (err) {
    mostrarAlerta('alert-feedback', 'error', err.message);
  }
}

/* ════════════════════════════════════════
   CERTIFICADOS
   ════════════════════════════════════════ */
function initCertificados() {
  document.getElementById('btn-validar').addEventListener('click', validarCertificado);
  document.getElementById('codigo-validacao').addEventListener('keypress', (e) => {
    if (e.key === 'Enter') validarCertificado();
  });
  document.getElementById('btn-buscar-certificados').addEventListener('click', buscarCertificados);
}

async function validarCertificado() {
  const codigo = document.getElementById('codigo-validacao').value.trim().toUpperCase();
  if (!codigo) return;

  const container = document.getElementById('resultado-validacao');
  try {
    const resultado = await GET(`/certificados/validar/${codigo}`);
    container.innerHTML = `
      <div class="certificado-resultado certificado-resultado--valido">
        <div style="margin-bottom:0.75rem;">${SVG.checkLg}</div>
        <h3>Certificado Valido</h3>
        <p style="margin-top:0.75rem; color:var(--text-soft);">
          Codigo: <strong>${resultado.codigoValidacao}</strong><br>
          Emitido em: ${formatarData(resultado.dataEmissao)}
        </p>
      </div>
    `;
  } catch {
    container.innerHTML = `
      <div class="certificado-resultado certificado-resultado--invalido">
        <div style="margin-bottom:0.75rem;">${SVG.errorLg}</div>
        <h3 style="color:#f0a0a0;">Certificado Nao Encontrado</h3>
        <p style="margin-top:0.75rem; color:var(--text-muted);">
          O codigo informado nao corresponde a nenhum certificado valido.
        </p>
      </div>
    `;
  }
}

async function buscarCertificados() {
  const cpf = document.getElementById('cpf-certificado').value.trim();
  if (!cpf || cpf.length !== 11) return;

  const container = document.getElementById('lista-certificados');
  try {
    const certificados = await GET(`/certificados?cpf=${cpf}`);
    if (!certificados.length) {
      container.innerHTML = '<div class="empty-state"><p>Nenhum certificado encontrado para este CPF.</p></div>';
      return;
    }

    container.innerHTML = certificados.map(c => `
      <div class="card-atividade" style="margin-bottom:0.75rem;">
        <div class="card-atividade__header">
          <h4 class="card-atividade__title">Certificado #${c.id}</h4>
          <span class="label label--gold">${c.codigoValidacao}</span>
        </div>
        <div class="card-atividade__meta">
          <span class="card-atividade__info">${SVG.calendar} Emitido em ${formatarData(c.dataEmissao)}</span>
        </div>
      </div>
    `).join('');
  } catch {
    container.innerHTML = '<div class="empty-state"><p>Erro ao buscar certificados.</p></div>';
  }
}

/* ════════════════════════════════════════
   LIBRAS (Glossario)
   ════════════════════════════════════════ */
let todosTermos = [];
let categoriasLibras = [];

async function initLibras() {
  try {
    const [termos, categorias] = await Promise.all([
      GET('/glossario-libras'),
      GET('/glossario-libras/categorias')
    ]);
    todosTermos = termos;
    categoriasLibras = categorias;

    renderCategoriasFiltro();
    renderTermos(todosTermos);
    initBuscaLibras();
    await carregarDemandaLibras();
  } catch (err) {
    console.error('Erro ao carregar glossario:', err);
  }
}

function renderCategoriasFiltro() {
  const container = document.getElementById('filtros-categoria');
  if (!container) return;

  let html = '<button class="filter-btn active" data-cat="todos">Todas</button>';
  categoriasLibras.forEach(cat => {
    html += `<button class="filter-btn" data-cat="${cat}">${cat}</button>`;
  });
  container.innerHTML = html;

  container.querySelectorAll('.filter-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      container.querySelectorAll('.filter-btn').forEach(b => b.classList.remove('active'));
      btn.classList.add('active');
      filtrarTermos();
    });
  });
}

function initBuscaLibras() {
  const input = document.getElementById('busca-libras');
  if (!input) return;
  input.addEventListener('input', () => filtrarTermos());
}

function filtrarTermos() {
  const busca = (document.getElementById('busca-libras')?.value || '').toLowerCase();
  const catAtiva = document.querySelector('#filtros-categoria .filter-btn.active')?.dataset.cat || 'todos';

  let filtrados = [...todosTermos];
  if (catAtiva !== 'todos') {
    filtrados = filtrados.filter(t => t.categoria === catAtiva);
  }
  if (busca) {
    filtrados = filtrados.filter(t =>
      t.termoPortugues.toLowerCase().includes(busca) ||
      t.descricaoSinal.toLowerCase().includes(busca)
    );
  }

  renderTermos(filtrados);
}

function renderTermos(termos) {
  const container = document.getElementById('lista-termos');
  const empty = document.getElementById('empty-termos');

  if (!termos.length) {
    container.innerHTML = '';
    if (empty) empty.style.display = 'block';
    return;
  }

  if (empty) empty.style.display = 'none';
  container.innerHTML = termos.map(t => `
    <div class="termo-card">
      <div style="display:flex; align-items:center; justify-content:space-between; margin-bottom:0.5rem;">
        <span class="termo-card__titulo">${t.termoPortugues}</span>
        <span class="label label--olive" style="font-size:0.6rem;">${t.categoria}</span>
      </div>
      <p class="termo-card__descricao">${t.descricaoSinal}</p>
      <p class="termo-card__contexto">Contexto: ${t.contextoUso}</p>
    </div>
  `).join('');
}

async function carregarDemandaLibras() {
  const container = document.getElementById('demanda-libras');
  if (!container) return;

  try {
    const atividades = await GET('/atividades?eventoId=1');
    const atividadesComLibras = atividades.filter(a => a.temInterpreteLibras);

    if (!atividadesComLibras.length) {
      container.innerHTML = '<div class="empty-state"><p>Nenhuma atividade com suporte em Libras.</p></div>';
      return;
    }

    const demandas = await Promise.all(
      atividadesComLibras.map(async (a) => {
        try {
          const d = await GET(`/inscricoes/demanda-libras/${a.id}`);
          return { ...a, demanda: d };
        } catch {
          return { ...a, demanda: { solicitacoesLibras: 0 } };
        }
      })
    );

    container.innerHTML = demandas.map(d => `
      <div class="card" style="display:flex; align-items:center; gap:1.25rem;">
        <div class="icon-box">
          ${SVG.libras}
        </div>
        <div style="flex:1;">
          <h4>${d.titulo}</h4>
          <p class="text-muted" style="font-size:0.82rem;">
            ${d.demanda.solicitacoesLibras || 0} participante(s) solicitaram interprete
          </p>
          <p class="text-muted" style="font-size:0.75rem; margin-top:0.25rem;">
            ${SVG.speaker} ${d.palestrante} &middot; ${SVG.location} ${d.sala}
          </p>
        </div>
      </div>
    `).join('');
  } catch (err) {
    container.innerHTML = '<div class="empty-state"><p>Erro ao carregar demanda.</p></div>';
  }
}

/* ════════════════════════════════════════
   HELPERS COMPARTILHADOS
   ════════════════════════════════════════ */
function cardAtividadeHTML(a) {
  return `
    <div class="card-atividade reveal">
      <div class="card-atividade__header">
        <h4 class="card-atividade__title">${a.titulo}</h4>
        <span class="label label--gold">${tipoAtividadeLabel(a.tipo)}</span>
      </div>
      <p class="text-muted" style="font-size:0.85rem; margin-top:0.5rem;">${a.descricao || ''}</p>
      <div class="card-atividade__meta">
        <span class="card-atividade__info">${SVG.calendar} ${formatarData(a.dataHora)}</span>
        <span class="card-atividade__info">${SVG.clock} ${formatarHora(a.dataHora)} — ${formatarHora(calcularHorarioFim(a.dataHora, a.duracaoMinutos))}</span>
        <span class="card-atividade__info">${SVG.people} ${a.vagasDisponiveis} vagas</span>
        <span class="card-atividade__info">${SVG.speaker} ${a.palestrante}</span>
        <span class="card-atividade__info">${SVG.location} ${a.sala}</span>
        ${a.temInterpreteLibras ? `<span class="label label--libras" style="font-size:0.65rem;">${SVG.libras} Libras</span>` : ''}
      </div>
    </div>
  `;
}
