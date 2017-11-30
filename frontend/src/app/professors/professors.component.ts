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
   private hard_tema: any;
   private easy_tema: any;
   private dataisLoaded : boolean;
   private data_isLoaded : boolean;
   

    
    constructor(private router: Router, private dataService: DataService, private auth: AuthService) {
        this.dataLoaded = false;
        this.dataisLoaded = false;
        this.data_isLoaded = false;
        if(this.auth.isAuthenticated()){
            this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
                this.currentUser = data[0];
                
                this.dataService.getAlumnosLastGame(this.currentUser.grupo).subscribe(data => {
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
                var grp = new String(this.grupo);
                //65 unicode de A
                //66 unicode de B
                if((this.grupo.charCodeAt(0))==66){
                    this.mascota="http://reciplast.mx/masc/avatarLion.png";
                }
                if((this.grupo.charCodeAt(0))==65){
                    this.mascota="http://reciplast.mx/masc/avatarDelfin.png";
                }
                this.dataService.getDificil().subscribe( data=>{
                    console.log(data.responseRows[0].id);
                    this.hard_tema=data.responseRows[0];
                    this.dataisLoaded=true;
                })

                this.dataService.getFacil().subscribe( data=>{
                    console.log(data.responseRows[0].id);
                    this.easy_tema=data.responseRows[0];
                    this.data_isLoaded=true;
                })

            })
            

        }
    }
    fillDataSource(alumnos: any[]) {
        this.ELEMENT_DATA = new Array<IElement>();
        for (var i = 0; i < alumnos.length; i++) {
            var myobj : IElement;
            myobj = {
                id: alumnos[i].ID, 
                noLista: alumnos[i].noLista, 
                name: alumnos[i].Nombre, 
                lastName: alumnos[i].Apellidos, 
                dateOfLastGame: alumnos[i].Fecha
            };
            
            this.ELEMENT_DATA.push(myobj);
        }
        this.dataSource = new MatTableDataSource<IElement>(this.ELEMENT_DATA);
        this.dataLoaded = true;
    }

}

export interface IElement {
    id: any;
    noLista: any;
    name: any;
    lastName: any;
    dateOfLastGame: any;
}
