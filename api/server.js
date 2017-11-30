
var express = require('express');
var bodyParser = require('body-parser');
var cors = require('cors');

var loginHandler = require('./routes/login');
var studentsRoutes = require('./routes/student');
var teacherRoutes = require('./routes/teachers');
var gamesRoutes = require('./routes/games');
var parentRoutes = require('./routes/parents');


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
router.post('/api/user', teacherRoutes.setUser);

// STUDENTS
router.get('/api/alumno', studentsRoutes.getStudents);
router.get('/api/alumno/:id', studentsRoutes.getStudent);
router.get('/api/alumno/:nombres/', studentsRoutes.getStudentByName);
//router.get('api/alumno/', studentsRoutes.getStudentByGroup);

router.get('/api/alumnos/lastgame/:group', studentsRoutes.getLastGame);
router.get('/api/alumnos/max/:group', studentsRoutes.getMax);
router.get('/api/alumnos/min/:group', studentsRoutes.getMin);
router.get('/api/alumnos/grades/:group', studentsRoutes.getGrades);

router.post('/api/alumno', studentsRoutes.registerStudent);
router.put('/api/alumno/:id', studentsRoutes.updateStudent);

// TEACHERS
router.post('/api/profesor/email', teacherRoutes.getTeacher);

// STORE
router.post('/api/compra', studentsRoutes.compra);

// PARENTS
router.post('/api/parent', parentRoutes.registerParent);

// GAMES
router.get('/api/juego', gamesRoutes.getGames);
router.get('/api/juego/:id', gamesRoutes.getGame);
router.get('/api/jugado/:alumnoId', gamesRoutes.getStudentResults);
router.get('/api/jugado/:grupoId', gamesRoutes.getGroupResults);
router.get('/api/jugado/:alumnoId&juegoId', gamesRoutes.getStudentGameResults);

router.get('/api/gam/dificil/:grupo', gamesRoutes.getHardGame);
router.get('/api/gam/facil/:grupo', gamesRoutes.getEasyGame);
router.get('/api/gamz/visitas/:grupo', gamesRoutes.getVisitas);
router.get('/api/game/promedio/:grupo', gamesRoutes.getAVG);

router.post('/api/juega', gamesRoutes.registerGame);

app.use('/', router);

app.listen(port);
console.log('server running on port ' + port);
