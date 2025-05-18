import { defineConfig } from 'vite';
import path from 'path';

export default defineConfig({
  resolve: {
    alias: {
      'primeng': path.resolve(__dirname, 'node_modules/primeng'),
      'primeicons': path.resolve(__dirname, 'node_modules/primeicons')
    }
  }
});
