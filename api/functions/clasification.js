var mysql = require('mysql');
var db = require('../db');

var alumnos;
var promedioMax;
var promedioMin;
var rangos;

exports.clasificationByGroup = function (grupo) {

    var queryMax = 'SELECT Alumno, Proporcion FROM promedioGeneralGrupal WHERE Proporcion = (SELECT MAX(Proporcion) FROM promedioGeneralGrupal) AND Grupo = ? ';
    var queryMin = 'SELECT Alumno, Proporcion FROM promedioGeneralGrupal WHERE Proporcion = (SELECT MIN(Proporcion) FROM promedioGeneralGrupal) AND Grupo = ? ';
    var table = [grupo];

    queryMax = mysql.format(queryMax, table);
    queryMin = mysql.format(queryMin, table);
    
    db.query(queryMax, function(err,rows){
        if(err) {
            console.log('ERRROR ' + err);
        } else {
            
            this.promedioMax = parseInt(rows[0].Proporcion, 10);
            this.promedioMax = 1 + this.promedioMax;
            console.log(this.promedioMax);

            db.query(queryMin, function (err, rows) {
                if(err) {
                    console.log('ERRROR ' + err);
                } else {
                    this.promedioMin = parseInt(rows[0].Proporcion, 10);
                    this.promedioMin = 1 + this.promedioMin;
                    console.log( this.promedioMax - this.promedioMin );
                    this.rangos = (this.promedioMax - this.promedioMin);

                    console.log(this.rangos + ' rangs' );
                    this.rangos = Math.ceil (this.rangos / 3);
                    console.log('da fuck ' + this.rangos);
                }
            })

        }
    })
};

function studentClasification(){
    var query = 'SELECT ';
}

