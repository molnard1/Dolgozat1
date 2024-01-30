// @ts-check
import {themes as prismThemes} from 'prism-react-renderer';
require('dotenv').config();

/** @type {import('@docusaurus/types').Config} */
const config = {
  title: 'Dolgozat',
  tagline: 'Dolgozat MAUI dokumentáció',
  favicon: 'img/favicon.ico',

  url: 'https://molnard1.github.io/',
  baseUrl: process.env.DOCS_BASE_URL || '/public/docs/',

  organizationName: 'molnard1',
  projectName: 'Dolgozat1',

  onBrokenLinks: 'ignore',
  onBrokenMarkdownLinks: 'warn',


  i18n: {
    defaultLocale: 'hu',
    locales: ['hu'],
  },

  presets: [
    [
      'classic',
      /** @type {import('@docusaurus/preset-classic').Options} */
      ({
        docs: {
          routeBasePath: '/',
          sidebarPath: require.resolve('./sidebars.js'),
        },

        pages: false,
        blog: false
      }),
    ],
  ],

  themeConfig:
    /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
    ({
      image: 'img/docusaurus-social-card.jpg',
      navbar: {
        title: 'Dolgozat',
        logo: {
          alt: 'Frontend Logo',
          src: 'img/logo.svg',
        },
      },
      footer: {
        copyright: 'A forráskód MIT licenc alatt áll. A weboldal tartalma CC BY-NC-SA 4.0 licenc alá tartozik.',
      },
      prism: {
        theme: prismThemes.github,
		darkTheme: prismThemes.dracula,
      },
      colorMode: {
        respectPrefersColorScheme: true
      }
    }),
};

module.exports = config;