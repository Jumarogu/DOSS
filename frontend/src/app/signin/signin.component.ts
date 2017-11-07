import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    
    styleUrls: ['signin.component.css'],
    templateUrl: 'signin.component.html'
})

export class SignInComponent {
    user: any;
    constructor(private router: Router) {
        this.user = {};
        this.user.email = "";
        this.user.password = "";
    }

}
