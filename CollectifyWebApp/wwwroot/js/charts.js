/* Collectify — Dashboard charts
   Runs only when the dashboard canvases are present. */
(function () {
  if (typeof Chart === 'undefined') return;

  const pieEl = document.getElementById('pieChart');
  const barEl = document.getElementById('barChart');
  const lineEl = document.getElementById('lineChart');
  if (!pieEl && !barEl && !lineEl) return;

  const css = getComputedStyle(document.documentElement);
  const accent       = css.getPropertyValue('--accent').trim()        || '#C7A97A';
  const accentBright = css.getPropertyValue('--accent-bright').trim() || '#E0C79A';
  const accentMuted  = css.getPropertyValue('--accent-muted').trim()  || '#8F7852';
  const highlight    = css.getPropertyValue('--highlight').trim()     || '#D98880';
  const text         = css.getPropertyValue('--text').trim()          || '#F2EDE4';
  const textMuted    = css.getPropertyValue('--text-muted').trim()    || '#B8ADAE';
  const border       = 'rgba(199, 169, 122, 0.18)';
  const surface      = css.getPropertyValue('--surface').trim()       || '#261C2C';

  Chart.defaults.color = textMuted;
  Chart.defaults.font.family = "'Inter', system-ui, sans-serif";
  Chart.defaults.font.size = 12;

  const tooltipBase = {
    backgroundColor: surface,
    titleColor: text,
    bodyColor: textMuted,
    borderColor: 'rgba(199, 169, 122, 0.3)',
    borderWidth: 1,
    padding: 12,
    cornerRadius: 10,
    displayColors: true,
    boxPadding: 4,
  };

  const money = (n) => '$' + n.toLocaleString();

  if (pieEl) {
    new Chart(pieEl, {
      type: 'doughnut',
      data: {
        labels: ['Cards', 'Vinyl', 'Figurines'],
        datasets: [{
          data: [40, 35, 25],
          backgroundColor: [accent, highlight, accentMuted],
          borderColor: surface,
          borderWidth: 3,
          hoverOffset: 8,
        }],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        cutout: '62%',
        plugins: {
          legend: {
            position: 'bottom',
            labels: { color: textMuted, padding: 16, usePointStyle: true, pointStyle: 'circle' },
          },
          tooltip: {
            ...tooltipBase,
            callbacks: { label: (ctx) => ` ${ctx.label}: ${ctx.parsed}%` },
          },
        },
      },
    });
  }

  if (barEl) {
    new Chart(barEl, {
      type: 'bar',
      data: {
        labels: ['Pikachu Card', 'Rare Vinyl', 'Anime Figure', 'Silver Coin', 'Signed Manga'],
        datasets: [{
          label: 'Estimated Value',
          data: [850, 420, 310, 240, 180],
          backgroundColor: accent,
          hoverBackgroundColor: accentBright,
          borderRadius: 8,
          borderSkipped: false,
          maxBarThickness: 52,
        }],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: { display: false },
          tooltip: {
            ...tooltipBase,
            callbacks: { label: (ctx) => ` ${money(ctx.parsed.y)}` },
          },
        },
        scales: {
          x: {
            grid: { display: false },
            ticks: { color: textMuted },
            title: { display: true, text: 'Item', color: textMuted, font: { size: 11 }, padding: { top: 8 } },
          },
          y: {
            beginAtZero: true,
            grid: { color: border, drawBorder: false },
            ticks: { color: textMuted, callback: (v) => money(v) },
            title: { display: true, text: 'Estimated Value (USD)', color: textMuted, font: { size: 11 } },
          },
        },
      },
    });
  }

  if (lineEl) {
    const ctx2d = lineEl.getContext('2d');
    const gradient = ctx2d.createLinearGradient(0, 0, 0, 320);
    gradient.addColorStop(0, 'rgba(199, 169, 122, 0.35)');
    gradient.addColorStop(1, 'rgba(199, 169, 122, 0.02)');

    new Chart(lineEl, {
      type: 'line',
      data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
        datasets: [{
          label: 'Portfolio Value',
          data: [18500, 19200, 20100, 21400, 22800, 24860],
          borderColor: accent,
          backgroundColor: gradient,
          pointBackgroundColor: accentBright,
          pointBorderColor: surface,
          pointBorderWidth: 2,
          pointRadius: 5,
          pointHoverRadius: 7,
          tension: 0.38,
          fill: true,
          borderWidth: 2.5,
        }],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: { display: false },
          tooltip: {
            ...tooltipBase,
            callbacks: { label: (ctx) => ` ${money(ctx.parsed.y)}` },
          },
        },
        scales: {
          x: {
            grid: { display: false },
            ticks: { color: textMuted },
            title: { display: true, text: 'Month (2026)', color: textMuted, font: { size: 11 }, padding: { top: 8 } },
          },
          y: {
            beginAtZero: false,
            grid: { color: border, drawBorder: false },
            ticks: { color: textMuted, callback: (v) => money(v) },
            title: { display: true, text: 'Total Value (USD)', color: textMuted, font: { size: 11 } },
          },
        },
      },
    });
  }
})();
