import {Component} from '@angular/core';
import {MatTableDataSource} from '@angular/material';
import { DataService } from '../../services/data.service';
import { AuthService } from '../../services/auth/auth.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { forEach } from '@angular/router/src/utils/collection';
import { Element } from '@angular/compiler';

@Component({
  selector: 'table',
  styleUrls: ['table.component.css'],
  templateUrl: 'table.component.html',
})
export class TableComponent implements OnInit{

  private currentUser: any;
  private alumnos: any[];
  displayedColumns = ['id','noLista', 'name', 'lastName', 'dateOfLastGame'];
  dataSource : MatTableDataSource<any>;

  constructor (private dataService: DataService, private auth: AuthService) {

  }
  ngOnInit(){
    this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
      this.currentUser = data[0];
      
      this.dataService.getAlumnosLastGame(this.currentUser.grupo).subscribe(data => {
        //console.log(data);
        this.alumnos = data;
        this.fillDataSource(this.alumnos);
      })    
    });
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

  fillDataSource(alumnos: any[]) {
    let ELEMENT_DATA = new Array(alumnos.length);
    for (let i = 0; i < alumnos.length; i++) {
      let myobj = { 'id':alumnos[i].ID, 'noLista': alumnos[i].noLista, 'name': alumnos[i].Nombre, 'lastName': alumnos[i].Apellidos, 'dateOfLastGame': alumnos[i].Fecha}

      ELEMENT_DATA.push(myobj);
    }
    this.dataSource = new MatTableDataSource(ELEMENT_DATA);
  }
}

export interface IElement {
    name: string;
    noLista: string;
    id: string;
    lastName: string;
    dateOfLastGame: string;
}