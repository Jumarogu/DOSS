import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { AuthService } from '../services/auth/auth.service';

@Component({
    
    styleUrls: ['professors.component.css'],
    templateUrl: 'professors.component.html'
})


export class ProfessorsComponent {

    
    constructor(private router: Router, private dataService: DataService, private auth: AuthService) {
        this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
            console.log(data);
        })
    }

}
