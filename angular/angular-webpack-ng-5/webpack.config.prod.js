var path = require('path');
var webpack = require('webpack');
var webpackMerge = require('webpack-merge');
var commonconfig = require('./webpack.config.common');

module.exports = webpackMerge(commonconfig, {
    entry: './src/app/main.aot.ts',
    output: {
        path: path.resolve(__dirname, 'dist'),
        publicPath: '/',
        filename: '[hash].js',
        chunkFilename: '[id].[hash].js'
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: [{ loader: 'awesome-typescript-loader' },
                { loader: 'angular2-template-loader' },
                { loader: 'angular-router-loader?aot=true' }
                ]
            }
        ]
    },
    plugins: [
        new webpack.optimize.UglifyJsPlugin()
    ]
})