var mysql = require('mysql');
var db = require('../db');

var gameRes = {
    "alumnoID" : '',
    "juegoID" : '',
    "timepo" : '',
    'respuesta' : '',
    'pregunta' : '',
    'fecha' : ''
};

exports.getGames = function(req, res) {
    
}

exports.getGame = function(req, res) {
    
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
    this.gameRes.alumnoID = req.body.alumnoID;
    this.gameRes.juegoID = req.body.juegoID;
    this.gameRes.tiempo = parseInt(req.body.tiempo);
    this.gameRes.respuesta = parseInt(req.body.respuesta);
    this.gameRes.pregunta = req.body.pregunta;
    this.gameRes.fecha = req.body.fecha;

    var insertQuery = 'INSERT INTO juegaPartida (alumnoId, juegoId, tiempo, respuesta, pregunta, fecha) VALUES ( ?, ?, ?, ?, ?, ?);'
    var data = [this.gameRes.alumnoID, this.gameRes.juegoID, this.gameRes.timepo, this.gameRes.respuesta, this.gameRes.pregunta, this.gameRes.fecha];

    insertQuery = mysql.format(insertQuery, data);

    db.query(insertQuery, function(err, rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing INSERT QUERY", 'error' : err});
        } else {
            res.status(200).json({'Error' : false, "Message" : 'Inserted game', 'SQL response' : rows});
        }
    });
}