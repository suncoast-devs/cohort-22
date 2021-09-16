import { defineConfig } from 'vite'
import reactRefresh from '@vitejs/plugin-react-refresh'
import checker from 'vite-plugin-checker'
import { EsLinter, linterPlugin } from 'vite-plugin-linter'

// https://vitejs.dev/config/
export default defineConfig((configEnv) => ({
  plugins: [
    reactRefresh(),
    checker({
      // TypeScript config
      typescript: { tsconfigPath: './tsconfig.json' },
    }),
    linterPlugin({
      disableForBuild: true,
      include: ['./src/**/*.ts', './src/**/*.tsx'],
      linters: [
        new EsLinter({
          configEnv: configEnv,
          serveOptions: { cache: false, formatter: 'visualstudio' },
        }),
      ],
    }),
  ],
}))
