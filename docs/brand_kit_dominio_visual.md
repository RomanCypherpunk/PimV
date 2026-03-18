# DOMÍNIO VISUAL — Brand Kit

Guia completo de identidade visual — cores, tipografia, gradientes, formas, sombras e padrões de design extraídos da página de vendas atual.

---

## 01 — Paleta de Cores Primária

A identidade visual é construída sobre um eixo de tons oliva (verde-escuro terroso) combinado com dourados quentes. O contraste entre fundos escuros e acentos dourados cria uma atmosfera de sofisticação, confiança e exclusividade.

### Tons Oliva (Base da Identidade)

| Nome | Hex | Uso |
|------|-----|-----|
| Olive Dark | `#3B4211` | Fundo hero, seções principais |
| Olive Mid | `#4D5520` | Transições entre seções |
| Olive | `#60682D` | Cards, destaques, ícones check |
| Olive Light | `#7C8A1E` | Ícones, checks, gradientes |

### Tons Dourados (Destaque e Ação)

| Nome | Hex | Uso |
|------|-----|-----|
| Gold Pale | `#FDF383` | Headlines destacadas, preço, subtítulos |
| Gold | `#EAAF21` | CTA, ícones, dots carrossel, eyebrows |
| Gold Deep | `#C98F0A` | Gradiente do botão CTA (extremidade) |
| Cream | `#E5D2B2` | Texto secundário em seções de produto |

### Tons Escuros (Fundos e Profundidade)

| Nome | Hex | Uso |
|------|-----|-----|
| Dark | `#1D1F1C` | Fundo principal do body |
| Dark Alt | `#232611` | Seção de preço |
| Dark Product | `#20230A` | Seção de produto |
| Dark Depo | `#1B1D0F` | Seção de depoimentos |
| Dark Footer | `#0F1008` | Footer |

### Tons Claros (Texto e Legibilidade)

| Nome | Hex / Valor | Uso |
|------|-------------|-----|
| White | `#FFFFFF` | Texto principal sobre fundo escuro |
| Cream Light | `#FFFBF4` | Fundo claro alternativo |
| Cream | `#E5D2B2` | Texto na seção de produto |
| Olive Accent | `#B5C76A` | Texto de labels oliva |
| Text Soft | `rgba(255,255,255, 0.82)` | Corpo de texto principal |
| Text Muted | `rgba(255,255,255, 0.65)` | Descrições, labels menores |

---

## 02 — Tipografia

O sistema tipográfico usa duas famílias Google Fonts complementares: **Sora** para títulos (geométrica, moderna, com personalidade) e **Poppins** para corpo de texto (humanista, leve, alta legibilidade em tela).

### Fontes

| Propriedade | Sora (Títulos) | Poppins (Corpo) |
|-------------|----------------|-----------------|
| Uso | h1, h2, h3, h4, h5, botões CTA, preço | Parágrafos, labels, FAQ, depoimentos |
| Pesos | 300 · 400 · 500 · 600 · 700 · 800 | 300 · 400 · 500 · 600 · 700 · 400i |
| Variável CSS | `var(--font-h)` | `var(--font-b)` |
| Fallback | sans-serif | sans-serif |
| Estilo | Geométrica, moderna | Humanista, arredondada |

**Import:**
```
https://fonts.googleapis.com/css2?family=Sora:wght@300;400;500;600;700;800&family=Poppins:ital,wght@0,300;0,400;0,500;0,600;0,700;1,400&display=swap
```

### Escala Tipográfica

| Elemento | Tamanho (clamp) | Peso | Cor |
|----------|-----------------|------|-----|
| H1 Hero (Mobile) | `clamp(1.9rem, 5.5vw, 3rem)` | 700 | `#FFFFFF` |
| H1 Hero (Desktop) | `clamp(2.1rem, 4.5vw, 3.2rem)` | 700 | `#FFFFFF` |
| H1 Hero `<em>` | — | 700 | `#FDF383` (Gold Pale) |
| H2 Seção | `clamp(1.55rem, 4vw, 2.4rem)` | 700 | `#FFFFFF` ou `#FDF383` |
| H3 / Subtítulo | `clamp(1.05rem, 2.2vw, 1.35rem)` | 600 | `#FDF383` |
| H4 Card | `1rem` | 600 | `#FFFFFF` |
| Corpo | `clamp(.92rem, 1.8vw, 1.02rem)` | 300–400 | `rgba(255,255,255,.82)` |
| Small / Muted | `.875rem` | 400 | `rgba(255,255,255,.65)` |
| Preço Principal | `clamp(2.4rem, 6vw, 3.4rem)` | 800 | `#FDF383` |
| CTA Botão | `clamp(.95rem, 2.2vw, 1.1rem)` | 700 | `#1A1800` |
| Eyebrow / Label | `.72rem–.78rem` | 600 | `#EAAF21` ou rgba |

### Detalhes Tipográficos

- **Letter-spacing headlines:** `-.025em` (negativo, compacta visualmente)
- **Letter-spacing labels/eyebrows:** `.12em–.13em` (positivo, aberto)
- **Text-transform labels:** `uppercase`
- **Line-height corpo:** `1.7–1.85`
- **Line-height headlines:** `1.15–1.2`
- **Font-smoothing:** antialiased (webkit + moz)

---

## 03 — Gradientes

Gradientes são fundamentais na identidade visual. São usados em fundos de seção, botões CTA, divisores, cards e elementos decorativos. Todos seguem a mesma família de tons oliva + dourado.

### Gradientes Principais

**CTA Button:**
```css
background: linear-gradient(135deg, #FDF383 0%, #EAAF21 55%, #C98F0A 100%);
```

**Hero Background:**
```css
background: radial-gradient(ellipse at top left, #5A6129 0%, #3B4211 50%, #1E2208 100%);
```

**Hero Overlay (camada sobre o fundo):**
```css
background:
  radial-gradient(ellipse at 75% 15%, rgba(253,243,131,.07) 0%, transparent 55%),
  radial-gradient(ellipse at 10% 85%, rgba(59,66,17,.5) 0%, transparent 55%);
```

**Pain Section:**
```css
background: linear-gradient(180deg, #3B4211 0%, #495218 50%, #3B4211 100%);
```

**Dossier Section:**
```css
background: linear-gradient(180deg, #1D1F1C 0%, #191B07 100%);
```

**Price Card:**
```css
background: linear-gradient(145deg, #3A4410 0%, #252910 100%);
```

**Author Section:**
```css
background: linear-gradient(160deg, #5A6129 0%, #3B4211 45%, #474E1A 100%);
```

**Benefit Card:**
```css
background: linear-gradient(145deg, rgba(96,104,45,.14), rgba(59,66,17,.08));
```

**Check Circle:**
```css
background: linear-gradient(135deg, #7C8A1E, #60682D);
```

**Benefit Icon:**
```css
background: linear-gradient(135deg, rgba(253,243,131,.15), rgba(234,175,33,.08));
```

### Divisores de Seção (1px)

```css
/* Divisor dourado */
background: linear-gradient(90deg, transparent, rgba(253,243,131,.18–.30), transparent);

/* Divisor oliva */
background: linear-gradient(90deg, transparent, rgba(96,104,45,.40–.60), transparent);

/* HR decorativo */
background: linear-gradient(90deg, #EAAF21, transparent);
/* 52px largura, 3px altura, border-radius 2px */
```

---

## 04 — Formas e Border Radius

O sistema de arredondamento usa 5 níveis definidos em variáveis CSS, indo de cantos sutis (8px) até formas completamente arredondadas (pill). Isso cria uma linguagem visual coesa entre cards, botões, imagens e inputs.

### Tokens de Raio

| Token | Valor | Uso |
|-------|-------|-----|
| `--r-sm` | `8px` | Cards FAQ, itens inclusos, inputs |
| `--r-md` | `14px` | Cards de dor, benefícios, slides carrossel |
| `--r-lg` | `22px` | Imagens, vídeo hero, fotos da autora |
| `--r-xl` | `36px` | Card de preço |
| `--r-pill` | `100px` | Botão CTA, labels, tags, eyebrows |

### Variáveis CSS

```css
:root {
  --r-sm: 8px;
  --r-md: 14px;
  --r-lg: 22px;
  --r-xl: 36px;
  --r-pill: 100px;
}
```

---

## 05 — Sombras

Três níveis de sombra criam profundidade e hierarquia visual. Todas usam preto com opacidade variável, sem tom colorido. A exceção é o glow dourado do CTA.

### Tokens de Sombra

| Token | Valor CSS | Uso |
|-------|-----------|-----|
| `--shadow-sm` | `0 2px 10px rgba(0,0,0,0.18)` | Hover sutil em cards pequenos |
| `--shadow-md` | `0 8px 32px rgba(0,0,0,0.28)` | Cards em hover, carrosséis |
| `--shadow-lg` | `0 20px 64px rgba(0,0,0,0.40)` | Imagens hero, card de preço, fotos |

### Sombras Específicas

| Elemento | Valor CSS |
|----------|-----------|
| CTA glow | `0 4px 24px rgba(234,175,33,.55), 0 0 0 0 rgba(234,175,33,.35)` |
| CTA hover | `0 10px 36px rgba(234,175,33,.7)` |
| Video hero | `0 24px 80px rgba(0,0,0,.55), 0 0 0 1px rgba(255,255,255,.06)` |
| Price card | `0 24px 80px rgba(0,0,0,.45), inset 0 1px 0 rgba(255,255,255,.08)` |
| Card hover (benefício) | `0 16px 48px rgba(0,0,0,.35)` |

### Variáveis CSS

```css
:root {
  --shadow-sm: 0 2px 10px rgba(0,0,0,0.18);
  --shadow-md: 0 8px 32px rgba(0,0,0,0.28);
  --shadow-lg: 0 20px 64px rgba(0,0,0,0.40);
}
```

---

## 06 — Transparências e Overlays

A identidade faz uso extensivo de transparências para criar camadas de profundidade, glassmorphism sutil e separação hierárquica.

### Fundos com Transparência

| Elemento | Valor | Contexto |
|----------|-------|----------|
| Cards de dor (bg) | `rgba(255,255,255, 0.05)` | Fundo glass sutil |
| Cards de dor (hover) | `rgba(255,255,255, 0.08)` | Elevação visual no hover |
| FAQ item (bg) | `rgba(255,255,255, 0.04)` | Fundo accordion |
| Item incluso (bg) | `rgba(255,255,255, 0.04)` | Lista de entregáveis |
| Carousel button (bg) | `rgba(255,255,255, 0.07)` | Botões de navegação |

### Bordas com Transparência

| Elemento | Valor |
|----------|-------|
| Cards de dor | `rgba(255,255,255, 0.09)` |
| FAQ item | `rgba(255,255,255, 0.08)` |
| FAQ item open | `rgba(253,243,131, 0.25)` |
| Benefit card | `rgba(253,243,131, 0.10)` |
| Benefit card hover | `rgba(253,243,131, 0.22)` |
| Price card | `rgba(253,243,131, 0.22)` |
| Item incluso | `rgba(255,255,255, 0.07)` |
| Pain icon | `rgba(253,243,131, 0.15)` |
| Label gold border | `rgba(234,175,33, 0.30)` |
| Label olive border | `rgba(124,138,30, 0.35)` |
| Label light border | `rgba(255,255,255, 0.18)` |

### Labels / Tags

| Tipo | Background | Border | Text Color |
|------|-----------|--------|------------|
| Label Light | `rgba(255,255,255, 0.10)` | `rgba(255,255,255, 0.18)` | `rgba(255,255,255, 0.75)` |
| Label Gold | `rgba(234,175,33, 0.14)` | `rgba(234,175,33, 0.30)` | `#EAAF21` |
| Label Olive | `rgba(96,104,45, 0.18)` | `rgba(124,138,30, 0.35)` | `#B5C76A` |

### Efeitos Especiais

| Efeito | Valor |
|--------|-------|
| Backdrop blur (cards) | `blur(6px)` |
| Shimmer CTA | `rgba(255,255,255, 0.38)` |
| CTA pulse (pico) | `rgba(234,175,33, 0.75)` |
| CTA pulse (fade) | `rgba(234,175,33, 0)` |

---

## 07 — Animações e Micro-Interações

As animações são sutis e funcionais — reforçam hierarquia e guiam o olhar sem competir com o conteúdo.

### Animações de Entrada (Scroll)

| Animação | Propriedades | Timing | Uso |
|----------|-------------|--------|-----|
| Reveal | `opacity: 0→1`, `translateY: 28px→0` | `0.75s ease` | Todos os elementos de conteúdo |
| Reveal Zoom | `opacity: 0→1`, `scale: 0.93→1` | `0.7s ease` | Vídeo hero, imagens destaque |
| Delay Cascade | `rd1→.08s`, `rd2→.18s`, `rd3→.28s`, `rd4→.38s`, `rd5→.48s`, `rd6→.58s` | Sequencial | Elementos em sequência (hero, author) |

**Trigger:** IntersectionObserver com `threshold: 0.12` e `rootMargin: 0px 0px -50px 0px`.

### Animações Loop (CTA)

| Animação | Propriedades | Timing |
|----------|-------------|--------|
| Pulse CTA | `box-shadow` pulsando (glow dourado) | `2.8s ease-in-out infinite` |
| Shimmer | Barra de luz passando sobre o botão | `3.2s ease-in-out infinite` |

```css
@keyframes pulse-cta {
  0%, 100% { box-shadow: 0 4px 24px rgba(234,175,33,.55), 0 0 0 0 rgba(234,175,33,.35); }
  50%      { box-shadow: 0 4px 30px rgba(234,175,33,.75), 0 0 0 14px rgba(234,175,33,0); }
}

@keyframes shimmer {
  0%   { left: -120%; }
  100% { left: 220%; }
}
```

### Animações de Hover

| Elemento | Efeito | Timing |
|----------|--------|--------|
| Cards (dor/benefício) | `translateY(-5px / -6px)` | `0.3s` |
| Imagens (produto/causa) | `scale(1.02–1.025) rotate(±0.5–1deg)` | `0.6s ease` |
| CTA botão | `translateY(-3px) scale(1.02)` | `0.2s` |
| FAQ icon | `rotate(45deg)` | `0.3s` |
| Carousel btn | `scale(1.08)` | `0.2s` |

### Carousel

```css
transition: transform 0.52s cubic-bezier(.25, .1, .25, 1);
```

---

## 08 — Componentes UI e Padrões

Componentes reutilizáveis que formam o sistema de design da página.

### Botão CTA

```css
.btn-cta {
  background: linear-gradient(135deg, #FDF383 0%, #EAAF21 55%, #C98F0A 100%);
  color: #1A1800;
  font-family: var(--font-h); /* Sora */
  font-size: clamp(.95rem, 2.2vw, 1.1rem);
  font-weight: 700;
  padding: 1em 2.5em;
  border-radius: var(--r-pill); /* 100px */
  letter-spacing: .02em;
  box-shadow: 0 4px 24px rgba(234,175,33,.55);
  /* + pulse animation + shimmer animation */
}
```

### Card de Dor

```css
.pain-card {
  background: rgba(255,255,255, 0.05);
  border: 1px solid rgba(255,255,255, 0.09);
  border-radius: var(--r-md); /* 14px */
  padding: 1.75rem;
  backdrop-filter: blur(6px);
  /* hover: translateY(-5px), bg .08, border gold .18 */
}
```

### Card de Benefício

```css
.benefit-card {
  background: linear-gradient(145deg, rgba(96,104,45,.14), rgba(59,66,17,.08));
  border: 1px solid rgba(253,243,131, 0.10);
  border-radius: var(--r-md); /* 14px */
  padding: 1.75rem;
  /* hover: translateY(-6px), border gold .22 */
}
```

### Card de Preço

```css
.price-card {
  background: linear-gradient(145deg, #3A4410 0%, #252910 100%);
  border: 1px solid rgba(253,243,131, 0.22);
  border-radius: var(--r-xl); /* 36px */
  padding: clamp(2rem, 5vw, 3rem);
  box-shadow: 0 24px 80px rgba(0,0,0,.45), inset 0 1px 0 rgba(255,255,255,.08);
  position: sticky;
  top: 2rem;
}
```

### Ícones (Containers)

```css
/* Ícone de dor */
.pain-icon {
  width: 50px; height: 50px;
  background: rgba(253,243,131, 0.10);
  border-radius: 13px;
  border: 1px solid rgba(253,243,131, 0.15);
  /* SVG fill: #FDF383 (Gold Pale), 24x24 */
}

/* Ícone de benefício */
.benefit-icon {
  width: 52px; height: 52px;
  background: linear-gradient(135deg, rgba(253,243,131,.15), rgba(234,175,33,.08));
  border-radius: 14px;
  border: 1px solid rgba(234,175,33, 0.20);
  /* SVG fill: #EAAF21 (Gold), 24x24 */
}
```

### Check Circle (Itens Inclusos)

```css
.check-circle {
  width: 24px; height: 24px;
  background: linear-gradient(135deg, #7C8A1E, #60682D);
  border-radius: 50%;
  /* SVG check branco 13x13 */
}
```

### FAQ Accordion

```css
.faq-item {
  background: rgba(255,255,255, 0.04);
  border: 1px solid rgba(255,255,255, 0.08);
  border-radius: var(--r-md); /* 14px */
  /* Open: border rgba(253,243,131, 0.25) */
}

.faq-icon-btn {
  width: 28px; height: 28px;
  border-radius: 50%;
  background: rgba(253,243,131, 0.09);
  border: 1px solid rgba(253,243,131, 0.20);
  /* Open: rotate(45deg), bg .18 */
  /* SVG + fill: #FDF383, 14x14 */
}
```

### Labels / Tags

```css
.label-light {
  background: rgba(255,255,255, 0.10);
  color: rgba(255,255,255, 0.75);
  border: 1px solid rgba(255,255,255, 0.18);
  border-radius: var(--r-pill);
  font-size: .72rem;
  font-weight: 600;
  letter-spacing: .13em;
  text-transform: uppercase;
  padding: .35em 1.1em;
}

.label-gold {
  background: rgba(234,175,33, 0.14);
  color: #EAAF21;
  border: 1px solid rgba(234,175,33, 0.30);
}

.label-olive {
  background: rgba(96,104,45, 0.18);
  color: #B5C76A;
  border: 1px solid rgba(124,138,30, 0.35);
}
```

---

## 09 — Layout e Espaçamento

### Grid e Container

| Propriedade | Valor | Nota |
|-------------|-------|------|
| Max-width container | `1180px` | Conteúdo centralizado |
| Padding lateral | `clamp(1.25rem, 5vw, 3.5rem)` | Responsivo automático |
| Padding seção (vertical) | `clamp(4rem, 8vw, 7rem)` | Espaçamento generoso |
| Grid desktop (hero, causa, produto, preço) | `1fr 1fr` ou `1.1fr 1fr` | 2 colunas |
| Grid cards desktop | `repeat(3, 1fr)` | Benefícios |
| Grid cards tablet | `1fr 1fr` | Dores, benefícios |
| Gap entre cards | `1.25rem` | Consistente |
| Gap grid desktop | `4rem–5rem` | Seções com 2 colunas |

### Breakpoints

| Breakpoint | Comportamento |
|------------|---------------|
| `< 560px` | Mobile — 1 coluna, cards empilhados |
| `560px` | Tablet — 2 colunas em grids de cards |
| `768px` | Desktop start — hero 2 colunas, headline troca |
| `1024px` | Desktop full — benefícios em 3 colunas |

### Variáveis CSS Completas

```css
:root {
  /* Cores */
  --olive-dark: #3B4211;
  --olive: #60682D;
  --olive-mid: #4d5520;
  --olive-light: #7C8A1E;
  --gold-pale: #FDF383;
  --gold: #EAAF21;
  --gold-deep: #c98f0a;
  --dark: #1D1F1C;
  --dark-alt: #232611;
  --dark-blue: #0e0f07;
  --cream: #E5D2B2;
  --cream-light: #FFFBF4;
  --white: #FFFFFF;
  --text-muted: rgba(255,255,255,0.65);
  --text-soft: rgba(255,255,255,0.82);

  /* Tipografia */
  --font-h: 'Sora', sans-serif;
  --font-b: 'Poppins', sans-serif;

  /* Raios */
  --r-sm: 8px;
  --r-md: 14px;
  --r-lg: 22px;
  --r-xl: 36px;
  --r-pill: 100px;

  /* Sombras */
  --shadow-sm: 0 2px 10px rgba(0,0,0,0.18);
  --shadow-md: 0 8px 32px rgba(0,0,0,0.28);
  --shadow-lg: 0 20px 64px rgba(0,0,0,0.40);

  /* Layout */
  --max-w: 1180px;
  --pad: clamp(1.25rem, 5vw, 3.5rem);
}
```

---

*DOMÍNIO VISUAL — Brand Kit · Documento interno de identidade visual*
*Extraído da página de vendas atual · Referência para criativos, anúncios e materiais*
