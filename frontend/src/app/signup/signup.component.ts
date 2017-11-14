import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    
    styleUrls: ['signup.component.css'],
    templateUrl: 'signup.component.html'
})

export class SignUpComponent {
    user: any;
    constructor(private router: Router) {
        this.user = {};
        this.user.email = "";
        this.user.password = "";
    }

}
