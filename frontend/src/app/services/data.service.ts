import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/switchMap';
import {Observable} from 'rxjs/Observable';
import {Injectable} from '@angular/core';
import {AuthService} from './auth/auth.service';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class DataService {

    private apiURL = 'http://localhost:8080/api';

    constructor(private http: HttpClient) {
        
    }

    getAlumnos () : Observable<any> {
        // HTTP REQ
        return this.http.get( this.apiURL + '/alumno' );
    }

    getJuegos () : Observable<any> {
        return this.http.get( this.apiURL + '/juegos' );
    }

    getUserRol (email: string) : Observable<any> {
        const body = {
            email: email
        };
        return this.http.post( this.apiURL + '/login', body);
    }
    getUser(email: string) : Observable<any> {
        const body = {
            email: email};
        return this.http.post( this.apiURL + '/profesor/email', body);
    }

    setUser(email: string, rol: string): Observable <any>{
        const body = {
            email: email,
            rol: rol
        };
        return this.http.post( this.apiURL + '/user', body);
    }
    getAlumnosLastGame(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/alumnos/lastgame/' + grupo );
    }
    getMaxGrade(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/alumnos/max/' + grupo );
    }
    getMinGrade(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/alumnos/min/' + grupo );
    }
    getFacil(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/gam/facil/'+ grupo);
    }
    getDificil(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/gam/dificil/'+grupo);
    }
    getVisitas(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/gamz/visitas/'+grupo);
    }
    getPromedio(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/game/promedio/'+grupo);
    }
    
    registerTeacher(nombres: string, apellidos: string, email: string, grupo: string): Observable<any>{
        const body = {
            nombres: nombres,
            apellidos: apellidos,
            email: email,
            grupo: grupo
        };
        return this.http.post( this.apiURL + '/profesor', body);
    }

    registerStudent(nombres: string, apellidos: string, cumpleanos: string, grupo: string, noLista: string, genero: string, profesorid: string, padreid: string): Observable<any> {
        const body = {
            nombres: nombres,
            apellidos: apellidos,
            genero: genero,
            grupo: grupo,
            profesorid: profesorid,
            padreid: padreid,
            noLista: noLista,
            cumpleanos: cumpleanos
        };
        return this.http.post( this.apiURL + '/alumno', body);
    }
    registerParent (nombres: string, apellidos: string, email: string): Observable<any> {
        const body = {
            nombres: nombres,
            apellidos: apellidos,
            email: email
        };
        return this.http.post( this.apiURL + '/parent', body);
    }
}
