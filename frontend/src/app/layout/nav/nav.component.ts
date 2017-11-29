import { Component } from '@angular/core';
import { AuthService } from 'app/services/auth/auth.service';

@Component({
    selector: 'top-nav',
    templateUrl: './nav.component.html',
    styleUrls: ['./nav.component.css']
})

export class NavComponent {
    constructor(private auth: AuthService) {
        
    }
}