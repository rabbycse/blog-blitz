const path = require('path')
const VueLoaderPlugin = require('vue-loader/lib/plugin')

module.exports = {
    mode: "development",
    entry: {
        'main': './vue-app/main.js'
    },
    output: {
        path: path.join(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js',
        publicPath: '/dist/'
    },
    module: {
        rules: [
            { 
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test:/\.css$/,
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            }
        ]
    },
    plugins: [
        new VueLoaderPlugin()
    ]
}