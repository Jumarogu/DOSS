import { Component, group } from '@angular/core';
import { Router } from '@angular/router';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../services/data.service';
import { AuthService } from '../services/auth/auth.service';

@Component({
    
    styleUrls: ['signup.component.css'],
    templateUrl: 'signup.component.html'
})

export class SignUpComponent implements OnInit{
    user: any;
    api = 'http://localhost:8080';
    constructor(private router: Router, private dataService: DataService, private auth: AuthService) {
        this.user = {};
        this.user.email = "";
        this.user.password = "";

        this.dataService.getAlumnos().subscribe( data => {
        });
    }

    printUser() {
       
    }

    registerTeacher(nombres, apellidos, email, grupo){
        this.dataService.registerTeacher(nombres, apellidos, email, grupo).subscribe(data => {
            console.log(data);
            this.user = {};
            alert('Usuario Registrado \n Nombre: ' + nombres + ' ' + apellidos);
            this.dataService.setUser(email, 'professor').subscribe(data => {
                console.log('user added');
            })
        })
    }

    ngOnInit(): void {
        // Make the HTTP request:
      }
}
