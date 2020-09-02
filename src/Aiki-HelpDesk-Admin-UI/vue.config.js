'use strict'

module.exports = {
    outputDir: '../../_publish/admin-ui',
    "transpileDependencies": [
        "vuetify"
    ],
    devServer: {
        host:'localhost',
        hot:true,
        disableHostCheck: true,
        https: false,
        port:5002,
        proxy: {
            '/api': {
                target: 'http://localhost:28152/',
                changeOrigin: true,
                pathRewrite: {
                    '^/api': ''
                }
            }
        }
    },
    pwa: {
        workboxOptions: {
            skipWaiting: true
        }
    }
}
