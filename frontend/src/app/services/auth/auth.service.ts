import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { AUTH_CONFIG } from './auth0-variables';
import * as auth0 from 'auth0-js';

import { DataService } from '../data.service';

// import UserInfo = firebase.UserInfo;

@Injectable()
export class AuthService {

    currentUser: any;
    
    auth0 = new auth0.WebAuth({
        domain: AUTH_CONFIG.domain,
        clientID: AUTH_CONFIG.clientID,
        redirectUri: AUTH_CONFIG.callbackURL,
        audience: `https://${AUTH_CONFIG.domain}/userinfo`,
        responseType: 'token id_token',
        scope: 'openid'
      });
    
    constructor(private router: Router, private dataService: DataService) {
         
    }

    public login(username: string, password: string): void {
        this.auth0.client.login({
            realm: 'Username-Password-Authentication',
            username,
            password
        }, (err, authResult) => {
            if (err) {
                console.log(err);
                alert(`Error: ${err.error_description}. Check the console for further details.`);
                return;
            } else if (authResult && authResult.accessToken && authResult.idToken) {
                console.log(authResult);
                this.setSession(authResult);
                this.dataService.getUserRol(username).subscribe(data => {
                    this.currentUser = data;
                    console.log();
                    this.router.navigate(['/' + this.currentUser.rol]);
                });
            }
        });
    }

    public signup(email: string, password: string): void {
        this.auth0.signup({
            connection: 'Username-Password-Authentication',
            email,
            password,
        }, err => {
            if (err) {
                console.log(err);
                alert(`Error: ${err.description}. Check the console for further details.`);
                return;
            }
        });
    }

    private setSession(authResult): void {
        // Set the time that the access token will expire at
        const expiresAt = JSON.stringify(
            (authResult.expiresIn * 1000) + new Date().getTime()
        );
        localStorage.setItem('access_token', authResult.accessToken);
        localStorage.setItem('id_token', authResult.idToken);
        localStorage.setItem('expires_at', expiresAt);
    }

    public logout(): void {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem('access_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
        // Go back to the / route, that will redirect to signin
        this.router.navigate(['/']);
    }
    
    public isAuthenticated(): boolean {
        // Check whether the current time is past the
        // access token's expiry time
        const expiresAt = JSON.parse(localStorage.getItem('expires_at'));
        return new Date().getTime() < expiresAt;
    }
    
}
