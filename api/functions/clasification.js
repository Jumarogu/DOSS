var mysql = require('mysql');
var db = require('../db');

exports.clasificationByGroup = function (grupo, alumnoId, lastTry) {

    var queryMax = 'SELECT Alumno, Proporcion FROM promedioGeneralGrupal WHERE Proporcion = (SELECT MAX(Proporcion) FROM promedioGeneralGrupal) AND Grupo = ? ';
    var queryMin = 'SELECT Alumno, Proporcion FROM promedioGeneralGrupal WHERE Proporcion = (SELECT MIN(Proporcion) FROM promedioGeneralGrupal) AND Grupo = ? ';
    var queryAlumno = 'SELECT alumno, proporcion from promedioGeneralGrupal WHERE alumno = ? ';
    
    var table2 = [alumnoId];
    var table = [grupo];
    
    var promedioMax;
    var promedioMin;
    var rangos;

    queryMax = mysql.format(queryMax, table);
    queryMin = mysql.format(queryMin, table);
    queryAlumno = mysql.format(queryAlumno, table2);
    
    db.query(queryMax, function(err,rows){
        if(err) {
            console.log('ERRROR ' + err);
        } else {
            
            let max = +rows[0].Proporcion;
            promedioMax = max ;
            promedioMax = Math.ceil(promedioMax);
            console.log(isNaN(promedioMax));
            console.log(promedioMax);
            //console.log('this.promedioMax -> ' + this.promedioMax);

            db.query(queryMin, function (err, rows) {
                if(err) {
                    console.log('ERRROR ' + err);
                } else {

                    let min = +rows[0].Proporcion;
                    promedioMin = min ;
                    promedioMin = Math.floor(promedioMin);
                    console.log(promedioMin);
                    
                    let difference = promedioMax - promedioMin;
                    rangos = ( difference ) / 3. ;
                    rangos = Math.ceil (rangos);

                    console.log(isNaN(difference));
                    console.log( rangos );

                    db.query(queryAlumno, function (err, rows) {
                        if(err) {
                            console.log('Error al ejecutar query alumno ' + err)
                        } else {

                            let r1 = promedioMin + rangos;
                            let r2 = r1 + rangos;
                            let avg = +rows[0].proporcion;
                            let desempeno = '';

                            if( avg < r1) {
                                desempeno = 'Regular';
                            } else if ( (avg >= r1) && (avg < r2)) {
                                desempeno = 'Bueno';
                            } else {
                                desempeno = 'Excelente';
                            }

                            updateStudentStatus(alumnoId, avg, desempeno);
                            
                            if(lastTry == 1){
                                updateStudentMoney(alumnoId);
                            } 
                            console.log(isNaN(avg));
                            console.log(desempeno);
                        }
                    })

                }
            })

        }
    })
};

function updateStudentStatus(alumnoId, avg, desempeno) {

    var queryStatus = 'UPDATE ALUMNO SET DESEMPENO = ? , PROMEDIO = ? WHERE id = ?'
    var tableStatus = [desempeno, avg, alumnoId];

    queryStatus = mysql.format( queryStatus, tableStatus );

    db.query(queryStatus, function (err, rows) {
        if(err) {
            console.log('Error: ' + err);
        } else {
            console.log(queryStatus);
        }
    })
}

function updateStudentMoney(alumnoId) {

    var queryDinero = 'UPDATE alumno SET dinero = dinero + 10 WHERE id = ?';
    var tableDinero = [alumnoId];

    queryDinero = mysql.format( queryDinero, tableDinero );

    db.query(queryDinero, function (err, rows){
        if(err) {
            console.log('Error: ' + err);
        } else {
            console.log(queryDinero);
        }
    })
}

