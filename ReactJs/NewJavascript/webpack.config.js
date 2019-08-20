const path = require('path');

module.exports = {
  entry: './Main.js',
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'bundle.js'
  }
};