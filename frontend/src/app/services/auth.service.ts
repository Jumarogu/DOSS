import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { DataService } from './data.service';

// import UserInfo = firebase.UserInfo;

@Injectable()
export class AuthService {
    constructor(private router: Router, private dataService: DataService) {
        
    }
}
