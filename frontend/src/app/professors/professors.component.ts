import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { AuthService } from '../services/auth/auth.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import {MatTableDataSource} from '@angular/material';
import { Element } from '@angular/compiler';

@Component({
    
    styleUrls: ['professors.component.css'],
    templateUrl: 'professors.component.html'
})


export class ProfessorsComponent implements OnInit{
   private nombre: string;
   private apellido: string;
   private grupo: string;
   private mascota: string;

   private dataLoaded: boolean;
   private dataSource : MatTableDataSource<IElement>;
   private currentUser: any;
   private alumnos: any[];
   private ELEMENT_DATA: IElement[];
    
    constructor(private router: Router, private dataService: DataService, private auth: AuthService) {
        this.dataLoaded = false;
        if(this.auth.isAuthenticated()){
            this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
                this.currentUser = data[0];
                
                this.dataService.getAlumnosLastGame(this.currentUser.grupo).subscribe(data => {
                  console.log(data);
                  this.alumnos = data;
                  this.fillDataSource(this.alumnos);
                })    
              });
        }
    }

    ngOnInit() {
        if(this.auth.isAuthenticated()){
            this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
                this.nombre=data[0].nombres;
                this.apellido=data[0].apellidos;
                this.grupo=data[0].grupo;
                console.log(data); 
                var grp = new String(this.grupo);
                //console.log(this.grupo.charCodeAt(0));
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
    fillDataSource(alumnos: any[]) {
        this.ELEMENT_DATA = new Array<IElement>();
        console.log(alumnos.length);
        for (var i = 0; i < alumnos.length; i++) {
            var myobj : IElement;
          //myobj = {};
        //   myobj.id = alumnos[i].ID;
        //   myobj.noLista = alumnos[i].noLista;
        //   myobj.name = alumnos[i].Nombre;
        //   myobj.lastName = alumnos[i].Apellidos;
        //   myobj.dateOfLastGame = alumnos[i].Fecha;

            myobj = {
                id: alumnos[i].ID, 
                noLista: alumnos[i].noLista, 
                name: alumnos[i].Nombre, 
                lastName: alumnos[i].Apellidos, 
                dateOfLastGame: alumnos[i].Fecha
            };
            
            this.ELEMENT_DATA.push(myobj);
            console.log('id: ' + alumnos[i].ID + ' Element addded ' + this.ELEMENT_DATA.length);
            //console.log(ELEMENT_DATA[i]);
        }
        console.log(this.ELEMENT_DATA.length);
        this.dataSource = new MatTableDataSource<IElement>(this.ELEMENT_DATA);
        this.dataLoaded = true;
        console.log('bolean -> true');
    }

}

export interface IElement {
    id: any;
    noLista: any;
    name: any;
    lastName: any;
    dateOfLastGame: any;
}
