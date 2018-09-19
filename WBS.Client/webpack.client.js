const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const BabelMinifyPlugin = require('babel-minify-webpack-plugin');
const autoprefixer = require('autoprefixer');

module.exports = prod => ({
    entry: {
        bundle: path.resolve(__dirname, 'ClientApp-old/boot-client.jsx'),
    },

    output: {
        filename: `[name].js`,
        path: path.resolve(__dirname, 'wwwroot/dist'),
        publicPath: 'dist/',
    },

    resolve: {
        extensions: ['.js', '.jsx'],
        modules: [path.resolve(__dirname, 'ClientApp-old'), "node_modules"],
    },

    devtool: prod ? undefined : 'inline-source-map',

    module: {
        rules: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                use: [
                    'babel-loader',
                    'eslint-loader'
                ],
            },
            {
                test: /\.css$/,
                use: ExtractTextPlugin.extract({
                    use: [
                        {
                            loader: 'css-loader',
                            options: {
                                sourceMap: !prod,
                                modules: true,
                                minimize: prod,
                            }
                        },
                        {
                            loader: 'postcss-loader',
                            options: {
                                sourceMap: !prod,
                                plugins: [autoprefixer()],
                            },
                        }
                    ],
                    fallback: { loader: 'style-loader' },
                }),
            }
        ],
    },

    plugins: [
        new ExtractTextPlugin("bundle.css"),
        new webpack.EnvironmentPlugin({
            NODE_ENV: prod ? 'production' : 'development',
        })
    ].concat(prod ? [new BabelMinifyPlugin()] : []),
});
