import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { AuthService } from '../services/auth/auth.service';

@Component({
    
    styleUrls: ['signin.component.css'],
    templateUrl: 'signin.component.html'
})

export class SignInComponent {
    user: any;
    constructor(private router: Router, private dataService: DataService, private auth: AuthService) {
        this.user = {};
        this.user.email = "";
        this.user.password = "";
    }

}
