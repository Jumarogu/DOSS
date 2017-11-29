import {Component, Input} from '@angular/core';
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

  @Input() dataSource: MatTableDataSource<any>;

  displayedColumns = ['id', 'noLista', 'name', 'lastName', 'dateOfLastGame'];
  //private dataSource : MatTableDataSource<any>;

  constructor (private dataService: DataService, private auth: AuthService) {

  }
  ngOnInit(){
    
  }

  ngOnChanges() {

  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

}