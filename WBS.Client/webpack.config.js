const client = require("./webpack.client");

module.exports = () => {
    const prod = process.env.NODE_ENV === 'production';
    return [client(prod)];
}