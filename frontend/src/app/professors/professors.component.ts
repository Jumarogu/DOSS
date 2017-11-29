import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { AuthService } from '../services/auth/auth.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    
    styleUrls: ['professors.component.css'],
    templateUrl: 'professors.component.html'
})


export class ProfessorsComponent implements OnInit{
   nombre;
   apellido;
   grupo;
   mascota;
    
    constructor(private router: Router, private dataService: DataService, private auth: AuthService) {
     
    }

    ngOnInit() {
        if(this.auth.isAuthenticated()){
        this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
            this.nombre=data[0].nombres;
            this.apellido=data[0].apellidos;
            this.grupo=data[0].grupo;
            var grp = new String(this.grupo);
            //65 unicode de A
            //66 unicode de B
            if((this.grupo.charCodeAt(0))==65){
                this.mascota="http://reciplast.mx/masc/avatarLion.png";
            }
            if((this.grupo.charCodeAt(0))==66){
                this.mascota="http://reciplast.mx/masc/avatarDelfin.png";
            }
        })
    }
      }

}
