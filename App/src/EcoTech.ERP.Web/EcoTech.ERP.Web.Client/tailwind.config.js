/** @type {import('tailwindcss').Config} */
module.exports = {
content: [
    "./**/*.{razor,html,cshtml}",               // Escanea TODO el Client
    "./Pages/**/*.{razor,html}",
    "./Components/**/*.{razor,html}",
    "./Shared/**/*.{razor,html}",               // Si tienes Shared
    // Si algunos componentes están en el proyecto principal (prerender o Server), agrega:
    "../EcoTech.ERP.Web/Components/**/*.{razor,html}",
    "../EcoTech.ERP.Web/**/*.{razor,html}",
    "../EcoTech.ERP.Web/Shared/**/*.{razor,html}"
],
  theme: {
    extend: {},
  },
  plugins: [],
}

