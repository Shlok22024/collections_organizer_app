/* Collectify shared UI helpers: toast + URL utilities. */
(function () {
  function ensureToastHost() {
    let host = document.getElementById('toast-host');
    if (host) return host;
    host = document.createElement('div');
    host.id = 'toast-host';
    host.className = 'toast-host';
    document.body.appendChild(host);
    return host;
  }

  function showToast(message, opts) {
    opts = opts || {};
    const variant = opts.variant || 'success';
    const icon = opts.icon || (variant === 'success' ? 'bi-check-circle-fill' : 'bi-info-circle-fill');
    const duration = typeof opts.duration === 'number' ? opts.duration : 1600;

    const host = ensureToastHost();
    const el = document.createElement('div');
    el.className = 'toast-flash toast-' + variant;
    el.innerHTML = '<i class="bi ' + icon + '"></i><span>' + message + '</span>';
    host.appendChild(el);

    requestAnimationFrame(() => el.classList.add('show'));

    setTimeout(() => {
      el.classList.remove('show');
      el.addEventListener('transitionend', () => el.remove(), { once: true });
      setTimeout(() => el.remove(), 500);
    }, duration);
  }

  function getQueryParam(name) {
    const p = new URLSearchParams(window.location.search);
    return p.get(name);
  }

  function findItem(id) {
    if (!id || !Array.isArray(window.COLLECTIFY_ITEMS)) return null;
    return window.COLLECTIFY_ITEMS.find((it) => it.id === id) || null;
  }

  function formatMoney(n) {
    if (n == null || isNaN(n)) return '$0.00';
    return '$' + Number(n).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
  }

  function categoryIcon(category) {
    switch ((category || '').toLowerCase()) {
      case 'cards':     return 'bi-collection';
      case 'vinyl':     return 'bi-disc';
      case 'figurines': return 'bi-stars';
      default:          return 'bi-box';
    }
  }

  window.CollectifyUI = { showToast, getQueryParam, findItem, formatMoney, categoryIcon };
})();
