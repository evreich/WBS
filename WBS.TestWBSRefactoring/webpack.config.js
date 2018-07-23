const client = require("./webpack.client");
//const server = require('./webpack.server');

module.exports = () => {
    const prod = process.env.NODE_ENV === 'production';
    //return [client(prod), server()];
    return [client(prod)];
}