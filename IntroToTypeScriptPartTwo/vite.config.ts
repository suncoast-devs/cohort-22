import { defineConfig } from 'vite'
import checker from 'vite-plugin-checker'
import path from 'path'
import fs from 'fs'

// Build a list of all the HTML files in the directory
const htmlFiles = fs
  .readdirSync('.')
  .filter((file) => path.extname(file) === '.html')

// Build a list of input options mapping all the html files here
const inputOptions = htmlFiles.reduce(
  (input, file) => ({ ...input, [file]: path.resolve(__dirname, file) }),
  {}
)

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [checker({ typescript: true })],
  // Add a build option to tell the build to include all the html files above
  build: { rollupOptions: { input: inputOptions } },
})
