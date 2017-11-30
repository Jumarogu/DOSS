var mysql = require('mysql');
var db = require('../db');
var functions = require('../functions/clasification');

var gameRes = {
    "alumnoID" : '',
    "juegoID" : '',
    "timepo" : '',
    'respuesta' : '',
    'pregunta' : '',
    'fecha' : '',
    'correcto' : ''
};

exports.getGames = function(req, res) {
    var query = "SELECT * FROM ??";
    var table = ["juego"];
    query = mysql.format(query,table);
    console.log(query);
    db.query(query,function(err,rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing MySQL query"});
        } else {
            res.status(200).json({"Error" : false, "Message" : "Success", "Juegos" : rows});
        }
    });
}

exports.getGame = function(req, res) {
    var query = "SELECT * FROM ?? WHERE ?? = ? ";
    var table = ["juego", 'id', req.params.juegoId];
    query = mysql.format(query,table);
    console.log(query);
    db.query(query,function(err,rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing MySQL query"});
        } else if(rows.length > 0){
            res.status(200).json({"Error" : false, "Message" : "Success", "Juego" : rows});
        }
    });
}

exports.getGameResults = function(req, res) {
    
}

exports.getStudentResults = function(req, res) {
    
}

exports.getGroupResults = function(req, res) {
    
}

exports.getStudentGameResults = function(req, res) {
    
}

exports.registerGame = function(req, res) {

    gameRes.alumnoID = req.body.alumnoId;
    gameRes.juegoID = req.body.juegoId;
    gameRes.tiempo = parseInt(req.body.tiempo);
    gameRes.respuesta = req.body.respuesta;
    gameRes.respuestaCorrecta = req.body.respuestaCorrecta;
    gameRes.fecha = req.body.fecha;
    gameRes.correcto = parseInt(req.body.correcto);

    var insertQuery = 'INSERT INTO juegaPartida (alumnoId, juegoId, tiempo, respuesta, respuestaCorrecta, fecha, correcto) VALUES ( ?, ?, ?, ?, ?, ?, ?);'
    var data = [gameRes.alumnoID, gameRes.juegoID, gameRes.tiempo, gameRes.respuesta, gameRes.respuestaCorrecta, gameRes.fecha, gameRes.correcto];

    //console.log(data);
    insertQuery = mysql.format(insertQuery, data);
    console.log(insertQuery);

    db.query(insertQuery, function(err, rows){
        if(err) {
            console.log(err);
            res.json({"Error" : true, "Message" : "Error executing INSERT QUERY", 'error' : err});
        } else {
            //console.log(rows);
            res.status(200).json({'Error' : false, "Message" : 'Inserted game', 'SQL response' : rows});
        }
    });
    functions.clasificationByGroup('A', gameRes.alumnoID, gameRes.correcto);
}

exports.getHardGame = function (req, res) {

    var selectQuery = "SELECT * FROM juegomasdificil WHERE grupo = ?";
    var table = [req.params.grupo];
    //console.log(data);
    selectQuery =mysql.format(selectQuery,table);
    console.log(selectQuery);

    db.query(selectQuery, function(err, rows){
        if(err) {
            console.log(err);
            res.json({"Error" : true, "Message" : "Error executing SELECT QUERY", 'error' : err});
        } else {
            //console.log(rows);
            res.status(200).json({'Error' : false, "Message" : 'SELECT HardGame', 'responseRows' : rows});
        }
    });
}

exports.getEasyGame = function (req, res) {

    var selectQuery = "SELECT * FROM juegomasfacil WHERE grupo = ?";
    var table = [req.params.grupo];    
    selectQuery = mysql.format(selectQuery,table);
    console.log(selectQuery);
    
    db.query(selectQuery, function(err, rows){
       if(err) {
            console.log(err);
            res.json({"Error" : true, "Message" : "Error executing SELECT QUERY", 'error' : err});
        } else {
            //console.log(rows);
            res.status(200).json({'Error' : false, "Message" : 'SELECT HardGame', 'responseRows' : rows});
        }
    });
}

exports.getAVG = function (req, res) {
    var selectQuery = "select * from promporgrupo where grupo= ?";
        //console.log(data);
        var table = [req.params.grupo];    
        selectQuery = mysql.format(selectQuery,table);
        console.log(selectQuery);
    
        db.query(selectQuery, function(err, rows){
            if(err) {
                console.log(err);
                res.json({"Error" : true, "Message" : "Error executing SELECT QUERY", 'error' : err});
            } else {
                //console.log(rows);
                res.status(200).json({'Error' : false, "Message" : 'SELECT juegaPartida', 'responseRows' : rows});
            }
        });
}
exports.getVisitas = function (req, res) {
    var selectQuery = "select * from numvisitas where grupo= ?";
    
        //console.log(data);
        var table = [req.params.grupo];    
        selectQuery = mysql.format(selectQuery,table);
        console.log(selectQuery);
    
        db.query(selectQuery, function(err, rows){
            if(err) {
                console.log(err);
                res.json({"Error" : true, "Message" : "Error executing SELECT QUERY", 'error' : err});
            } else {
                //console.log(rows);
                res.status(200).json({'Error' : false, "Message" : 'SELECT juegaPartida', 'responseRows' : rows});
            }
        });
}

