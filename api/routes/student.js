var mysql = require('mysql');

var db = require('../db');

exports.getStudent = function (req, res) {
    var query = "SELECT * FROM ?? WHERE ?? = ?";
    var table = ["alumno", 'id', req.params.id];
    query = mysql.format(query,table);
    db.query(query,function(err,rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing MySQL query"});
        } else {
            res.json({"Error" : false, "Message" : "Success", "Alumno" : rows});
        }
    });
}

exports.getStudents = function (req, res) {
    var query = "SELECT * FROM ??";
    var table = ["alumno"];
    query = mysql.format(query,table);
    console.log(query);
    db.query(query,function(err,rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing MySQL query"});
        } else {
            res.status(200).json({"Error" : false, "Message" : "Success", "Alumnos" : rows});
        }
    });
}

exports.getStudentByName = function (req, res) {
    var query = "SELECT * FROM ?? WHERE ?? LIKE ? AND ?? LIKE ?";
    var table = ["alumno", 'nombres', '%'+req.params.nombres+'%', 'apellidos', '%'+req.params.apellidos+'%'];
    query = mysql.format(query,table);
    console.log(query);
    db.query(query,function(err,rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing MySQL query"});
        } else if(rows.length > 0){
            res.status(200).json({"Error" : false, "Message" : "Success", "Alumno" : rows});
        }
    });
}

exports.getStudentByGroup = function (req, res) {
    var query = "SELECT * FROM ?? WHERE ?? = ? AND ?? = ?";
    var table = ["alumno", 'noLista', req.params.noLista, 'grupo', req.params.grupo];
    query = mysql.format(query,table);
    console.log(query);
    db.query(query,function(err,rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing MySQL query"});
        } else {
            res.status(200).json({"Error" : false, "Message" : "Success", "Alumno" : rows});
        }
    });
}

exports.getLastGame = function (req, res) {

    var query = 'SELECT * FROM LastPartida WHERE GRUPO = ?';
    var table = [req.params.group];
    console.log(query + 'fuckofff');
    query = mysql.format(query, table);
    db.query (query, function(err, rows) {
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing SELECT query", 'error' : err}).status(500);
        } else {
            if(rows.length > 0) {
                res.json(rows).status(200);
            } else {
                res.json({"Error" : true, 'Message' : ' Error Not user found'}).status(400);
            }
        }  
    });
}

exports.getMax = function (req, res) {

    var query = 'SELECT Alumno, Correctas FROM sumasconGrupo WHERE Correctas = (SELECT MAX(Correctas) FROM sumasConGrupo) AND Grupo = ?';
    var table = [req.params.group];
    console.log(query + 'fuckofff');
    query = mysql.format(query, table);
    db.query (query, function(err, rows) {
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing SELECT query", 'error' : err}).status(500);
        } else {
            if(rows.length > 0) {
                res.json(rows).status(200);
            } else {
                res.json({"Error" : true, 'Message' : ' Error Not user found'}).status(400);
            }
        }  
    });
}

exports.getMin = function (req, res) {

    var query = 'SELECT Alumno, Correctas FROM sumasconGrupo WHERE Correctas = (SELECT MIN(Correctas) FROM sumasConGrupo) AND Grupo = ?';
    var table = [req.params.group];
    console.log(query + 'fuckofff');
    query = mysql.format(query, table);
    db.query (query, function(err, rows) {
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing SELECT query", 'error' : err}).status(500);
        } else {
            if(rows.length > 0) {
                res.json(rows).status(200);
            } else {
                res.json({"Error" : true, 'Message' : ' Error Not user found'}).status(400);
            }
        }  
    });
}

exports.updateStudent = function (req, res) {
    var query = 'UPDATE alumno SET ?? = ? , ?? = ?, ?? = ?, ?? = ?, ?? = ? WHERE id = ? '
    var table = ['nombres', req.body.nombres, 'apellidos', req.body.apellidos, 'grupo', req.body.grupo, 'noLista', req.body.noLista, 'cumpleanos', req.body.cumpleanos, req.params.id];
    query = mysql.format(query, table);
    db.query(query, function(err, rows){
        if(err){
            res.status(300).json({'Error' : true, 'Message' : 'Error executing SLQ query' + query})
        } else {
            res.status(200).json({"Error" : false, "Message" : "Student updated", "Alumno" : rows});
        }
    });
    console.log(query);
    console.log(req.params.id);
    console.log(req.body);
    //res.status(200).json({'message' : 'printing body'});
}

exports.registerStudent = function(req, res) {
    
    var userID = req.body.nombres.substring(0, 2).toUpperCase() + req.body.apellidos.substring(0, 2).toUpperCase() + randomID(10, 99);
    var noLista = parseInt(req.body.noLista);

    var selectQuery = 'SELECT * FROM alumno WHERE ?? = ?';
    var selectTable = ['noLista', req.body.noLista];
    selectQuery = mysql.format(selectQuery, selectTable);

    var query = "INSERT INTO ?? (id, nombres, apellidos, cumpleanos, noLista, grupo, profesorID) VALUES (?, ?, ?, ?, ?, ?, ?)";
    var table = ['alumno', userID, req.body.nombres, req.body.apellidos, req.body.cumpleanos, noLista, req.body.grupo, req.body.profesorID];
    query = mysql.format(query, table);
    
    console.log(selectQuery);
    console.log(query);

    db.query(selectQuery, function(err,rows){
        if(err) {
            res.json({"Error" : true, "Message" : "Error executing SELECT query", 'error' : err});
        } 
        if(rows.length > 0) {
            res.status(300).json({"Message": "Estudiante existente"});
        } else {
            console.log(rows.length);
            db.query(query, function(err, rows){
                if(err) {
                    res.json({"Error" : true, "Message" : "Error executing INSERT query", 'error' : err});
                } else {
                    res.status(200).json({'Error' : false, "Message" : 'Inserted student', 'SQL response' : rows});
                } 
            })
        }
    });
}

function randomID(min,max) {
    return Math.floor(Math.random()*(max-min+1)+min);
}
