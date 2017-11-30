var mysql = require('mysql');

var connection = mysql.createConnection({
    host: 'localhost',
    //host: '192.168.1.77',
    user: 'root',
    password: '19195',
    database: 'SPACEMATH'
});

connection.connect(function(err) {
    if (err) throw err;
});

module.exports = connection;
