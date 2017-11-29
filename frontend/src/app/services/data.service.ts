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
    getAlumnosLastGame(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/alumnos/lastgame/' + grupo );
    }
    getMaxGrade(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/alumnos/max/' + grupo );
    }
    getMinGrade(grupo: string) : Observable<any> {
        return this.http.get( this.apiURL + '/alumnos/min/' + grupo );
    }
}
