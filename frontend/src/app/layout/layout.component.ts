import { Component } from '@angular/core';
import { AuthService } from 'app/services/auth/auth.service';

@Component({
    selector: 'app-layout',
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.css']
})

export class LayoutComponent {
    constructor(private auth: AuthService) {

    }
}