module.exports = {
  root: true,
  parser: '@typescript-eslint/parser',
  parserOptions: {
    ecmaVersion: 2020,
    sourceType: 'module',
    ecmaFeatures: {
      jsx: true,
    },
  },
  settings: {
    react: {
      version: 'detect',
    },
  },
  env: {
    browser: true,
    amd: true,
    node: true,
  },
  extends: [
    'eslint:recommended',
    'plugin:react/recommended',
    'plugin:react-hooks/recommended',
    // Uncomment this next line if you want to check your code for accessibility issues!
    // 'plugin:jsx-a11y/recommended',
    'prettier', // Make sure this is always the last element in the array.
  ],
  plugins: [],
  rules: {
    'react/react-in-jsx-scope': 'off',
    'jsx-a11y/accessible-emoji': 'off',
    'react/prop-types': 'off',
    '@typescript-eslint/explicit-function-return-type': 'off',
    'jsx-a11y/anchor-is-valid': 'off',
    // Allow arguments with an underscore to be ignored if they are unused
    'no-unused-vars': ['error', { argsIgnorePattern: '^_' }],
  },
}

