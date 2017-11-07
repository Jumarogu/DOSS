import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { DataService } from '../services/data.service';

@Component({
    
    styleUrls: ['signin.component.css'],
    templateUrl: 'signin.component.html'
})

export class SignInComponent {
    user: any;
    constructor(private authService: AuthService, private router: Router, private dataService: DataService) {
        this.user = {};
        this.user.email = "";
        this.user.password = "";
    }

}
