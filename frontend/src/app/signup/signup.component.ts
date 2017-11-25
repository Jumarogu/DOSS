import { Component } from '@angular/core';
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
            console.log(data['Alumnos']);
        });
    }

    printUser() {
        console.log(this.user);
    }

    ngOnInit(): void {
        // Make the HTTP request:
      }
}
