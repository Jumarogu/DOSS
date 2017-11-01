var mysql = require('mysql');

var connection = mysql.createConnection({
    host: '10.43.52.177',
    //host: '192.168.1.77',
    user: 'jumarogu',
    password: 'rooster1881',
    database: 'dossTest'
});

connection.connect(function(err) {
    if (err) throw err;
});

module.exports = connection;