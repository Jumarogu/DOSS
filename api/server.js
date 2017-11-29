var express = require('express');
var bodyParser = require('body-parser');
var cors = require('cors');

var loginHandler = require('./routes/login');
var studentsRoutes = require('./routes/student');
var teacherRoutes = require('./routes/teachers');
var gamesRoutes = require('./routes/games');


var app = express();
var port = process.env.PORT || 8080;
var router = express.Router();

app.use(cors());
app.options('*', cors())
app.use(bodyParser.urlencoded({ extended: false }))
app.use(bodyParser.json())

// LOGIN AND USER REGISTRATION
router.post('/api/login-alumno', loginHandler.loginStudent);
router.post('/api/login', loginHandler.getLoggedUser);

router.post('/api/profesor', teacherRoutes.registerTeacher);

// STUDENTS
router.get('/api/alumno', studentsRoutes.getStudents);
router.get('/api/alumno/:id', studentsRoutes.getStudent);
router.get('/api/alumno/:nombres/', studentsRoutes.getStudentByName);
//router.get('api/alumno/', studentsRoutes.getStudentByGroup);
router.put('/api/alumno/:id', studentsRoutes.updateStudent);
router.post('/api/alumno', studentsRoutes.registerStudent);
router.get('/api/alumnos/lastgame/:group', studentsRoutes.getLastGame);
router.get('/api/alumnos/max/:group', studentsRoutes.getMax);
router.get('/api/alumnos/min/:group', studentsRoutes.getMin);

// TEACHERS
router.post('/api/profesor/email', teacherRoutes.getTeacher);


// PARENTS


// GAMES
router.get('/api/juego', gamesRoutes.getGames);
router.get('/api/juego/:id', gamesRoutes.getGame);
router.get('/api/jugado/:alumnoId', gamesRoutes.getStudentResults);
router.get('/api/jugado/:grupoId', gamesRoutes.getGroupResults);
router.get('/api/jugado/:alumnoId&juegoId', gamesRoutes.getStudentGameResults);

router.post('/api/juega', gamesRoutes.registerGame);

app.use('/', router);

app.listen(port);
console.log('server running on port ' + port);
