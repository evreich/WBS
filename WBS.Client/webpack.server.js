const path = require('path');
const webpack = require('webpack');
const BabelMinifyPlugin = require('babel-minify-webpack-plugin');

module.exports = () => ({
    entry: {
        bundle: path.resolve(__dirname, 'ClientApp/boot-server.jsx'),
    },

    output: {
        filename: '[name].js',
        libraryTarget: 'commonjs',
        path: path.resolve(__dirname, 'ClientApp/dist'),
        publicPath: 'dist/',
    },

    resolve: {
        extensions: ['.js', '.jsx'],
        modules: [path.resolve(__dirname, 'ClientApp'), "node_modules"],
    },

    target: 'node',

    module: {
        rules: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            presets: [
                                ['@babel/preset-env', {
                                    targets: { node: 'current' },
                                    useBuiltIns: false,
                                }],
                            ],
                            plugins: [require('babel-plugin-css-modules-transform')],
                        },
                    },
                    'eslint-loader'
                ],
            },
        ],
    },

    plugins: [
        new BabelMinifyPlugin(),
        new webpack.EnvironmentPlugin({
            NODE_ENV: 'production',
        }),
    ],
});
