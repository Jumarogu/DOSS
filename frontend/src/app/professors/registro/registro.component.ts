import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../../services/data.service';
import { AuthService } from '../../services/auth/auth.service';

@Component({
    
    styleUrls: ['registro.component.css'],
    templateUrl: 'registro.component.html'
})

export class RegistroComponent implements OnInit{
    private parent: any;
    private alumno: any;
    private professor: any;
    
    constructor(private router: Router, private dataService: DataService, private auth: AuthService) {
        this.parent = {};
        this.alumno = {};
        this.professor = {};

    }
    registerUsers() {
        console.log(' parent');

        this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
            console.log(data[0].id);
            this.professor = data[0];

            this.dataService.registerParent(this.parent.nombres, this.parent.apellidos, this.parent.email).subscribe( data => {
                this.parent = data;
                console.log(this.parent);
                
                this.dataService.setUser(this.parent.correo, 'parent').subscribe(data => {
                    let pass = this.alumno.cumpleanos + this.alumno.noLista;
                    this.auth.signup(this.parent.correo, pass);
                    console.log('user parent setted' + this.parent.correo + ' with pass ' + pass);
                })

                this.dataService.registerStudent(this.alumno.nombres, this.alumno.apellidos, this.alumno.cumpleanos, this.professor.grupo, this.alumno.noLista, this.alumno.genero, this.professor.id, this.parent.id).subscribe(data => {
                    console.log('Estudiante registrado ' + this.professor.grupo + ' ' + this.alumno.nombres);
                    console.log(data);

                    this.alumno = {};
                    this.parent = {};
                })
            })

        })
    }
    ngOnInit(): void {
        
      }
}
