/* ========================================
   UTILS — Helpers e comunicação com a API
   ======================================== */

const API_BASE = 'http://localhost:5000/api';

/**
 * Faz uma requisição à API e retorna o JSON.
 * @param {string} endpoint - Caminho relativo (ex: '/eventos')
 * @param {object} options  - Opções extras para fetch (method, body, etc.)
 * @returns {Promise<any>}
 */
async function api(endpoint, options = {}) {
  const url = `${API_BASE}${endpoint}`;
  const config = {
    headers: { 'Content-Type': 'application/json' },
    ...options,
  };
  if (config.body && typeof config.body === 'object') {
    config.body = JSON.stringify(config.body);
  }
  const res = await fetch(url, config);
  if (!res.ok) {
    const err = await res.json().catch(() => ({ mensagem: 'Erro na requisição.' }));
    throw new Error(err.mensagem || err.title || `Erro ${res.status}`);
  }
  if (res.status === 204) return null;
  return res.json();
}

/* ── Atalhos de requisição ── */
const GET    = (endpoint) => api(endpoint);
const POST   = (endpoint, body) => api(endpoint, { method: 'POST', body });
const PUT    = (endpoint, body) => api(endpoint, { method: 'PUT', body });
const PATCH  = (endpoint) => api(endpoint, { method: 'PATCH' });

/* ── Formatação ── */
function formatarData(dataStr) {
  if (!dataStr) return '';
  const d = new Date(dataStr);
  return d.toLocaleDateString('pt-BR', { day: '2-digit', month: '2-digit', year: 'numeric' });
}

function formatarDataHora(dataStr) {
  if (!dataStr) return '';
  const d = new Date(dataStr);
  return d.toLocaleDateString('pt-BR', {
    day: '2-digit', month: '2-digit', year: 'numeric',
    hour: '2-digit', minute: '2-digit'
  });
}

function formatarHora(dataStr) {
  if (!dataStr) return '';
  const d = new Date(dataStr);
  return d.toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit' });
}

function tipoAtividadeLabel(tipo) {
  const map = {
    'Palestra': 'Palestra',
    'Minicurso': 'Minicurso',
    'MesaRedonda': 'Mesa Redonda',
    'Workshop': 'Workshop',
    'Hackathon': 'Hackathon',
    'Encerramento': 'Encerramento'
  };
  return map[tipo] || tipo;
}

function statusLabel(status) {
  const map = {
    'Pendente': 'Pendente',
    'Confirmada': 'Confirmada',
    'Cancelada': 'Cancelada',
    'Concluida': 'Concluída'
  };
  return map[status] || status;
}

/* ── Alertas ── */
function mostrarAlerta(elementId, tipo, mensagem) {
  const el = document.getElementById(elementId);
  if (!el) return;
  el.className = `alert alert--${tipo} show`;
  el.textContent = mensagem;
  setTimeout(() => { el.classList.remove('show'); }, 6000);
}

/* ── LocalStorage (sessão do participante) ── */
function salvarSessao(participante) {
  localStorage.setItem('pim_participante', JSON.stringify(participante));
}

function obterSessao() {
  const data = localStorage.getItem('pim_participante');
  return data ? JSON.parse(data) : null;
}

function limparSessao() {
  localStorage.removeItem('pim_participante');
}

/* ── Reveal Animation (IntersectionObserver) ── */
function initReveal() {
  const els = document.querySelectorAll('.reveal');
  if (!els.length) return;
  const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
      if (entry.isIntersecting) {
        entry.target.classList.add('visible');
        observer.unobserve(entry.target);
      }
    });
  }, { threshold: 0.12, rootMargin: '0px 0px -50px 0px' });
  els.forEach(el => observer.observe(el));
}

/* ── Navbar Toggle (mobile) ── */
function initNavbar() {
  const toggle = document.querySelector('.navbar__toggle');
  const links = document.querySelector('.navbar__links');
  if (!toggle || !links) return;
  toggle.addEventListener('click', () => {
    const open = links.classList.toggle('open');
    toggle.setAttribute('aria-expanded', open);
  });
  // Fechar ao clicar em um link
  links.querySelectorAll('a').forEach(a => {
    a.addEventListener('click', () => {
      links.classList.remove('open');
      toggle.setAttribute('aria-expanded', 'false');
    });
  });
}
