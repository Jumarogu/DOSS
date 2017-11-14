var mysql = require('mysql');

var connection = mysql.createConnection({
    host: 'localhost',
    //host: '192.168.1.77',
    user: 'jumarogu',
    password: 'rooster1881',
    database: 'dossDB'
});

connection.connect(function(err) {
    if (err) throw err;
});

module.exports = connection;