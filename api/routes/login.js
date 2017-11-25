var mysql = require('mysql');
var db = require('../db');

exports.loginStudent = function(req, res){
    var query = 'SELECT * FROM ?? WHERE ?? = ? AND ?? = ? AND ?? = ?';
    var table = ['alumno', 'cumpleanos', req.body.cumpleanos, 'grupo', req.body.grupo, 'noLista', req.body.noLista];
    query = mysql.format(query, table);
    console.log('loing' + req.body.noLista);
    db.query(query, function(err, rows){
        if(err){
            res.status(300).json({'Error':true, 'Message': 'Error executing query'});
        } else {
            console.log(rows[0]);
            if(rows.length > 0) {
                res.status(200).json(rows[0]);
            } else {
                res.status(300).json({'Error' : true, 'Message ' : 'Not existing student'});
            }
           
        }
    });
}

exports.loginUser = function(req, res) {
    var query = 'SELECT * FROM ?? WHERE ?? = ? AND ?? = ?';
    var table = ['profesor', 'correo', req.body.email, 'contrasena', req.body.password];
    query = mysql.format(query, table);
    console.log('loing user ' + req.body.email);
    db.query(query, function(err, rows){
        if(err){
            console.log(err);
            res.status(400).json({'Error':true, 'Message': 'Error executing query'});
        } else {
            if(rows.length > 0) {
                res.status(200).json(rows[0]);
            } else {
                console.log ( 'not existing usr' );
                res.status(400).json({'Error' : true, 'Message ' : 'Not existing user'});
            }
        }
    });
}

exports.getLoggedUser = function(req, res) {
    
    var query = 'SELECT * FROM USERS WHERE EMAIL = ?';
    var table = [req.body.email];

    query = mysql.format(query, table);

    console.log('getting user ' + req.body.email);

    db.query(query, function(err, rows){
        if(err) {
            console.log(err);
            res.status(400).json({'Error':true, 'Message': 'Error executing query'});
        } else {
            if(rows.length > 0) {
                res.status(200).json(rows[0]);
            } else {
                res.status(400).json({ 'Message' : 'Not users found' });
            }
        }
    });
}