import { Component, EventEmitter} from '@angular/core';
import { DataService } from '../../services/data.service';
import { AuthService } from '../../services/auth/auth.service';

@Component({
 selector: 'baseChart',
 templateUrl: 'baseChart.component.html'
})
export class baseChart {
 public barChartOptions:any = {
   scaleShowVerticalLines: false,
   responsive: true
 };
 public barChartLabels:string[];
 public barChartType:string = 'bar';
 public barChartLegend:boolean = true;
 public Loaded:boolean;
 private dat:number[];
 private isLoaded:boolean;
 public barChartData:any[] = [
   {data: [9,9], label: 'Promedio'}
 ];
 constructor (private dataService: DataService, private auth: AuthService) {
    this.isLoaded=false;
}
ngOnInit(){
  this.dataService.getPromedio().subscribe( data=>{
    console.log(data.responseRows.length);
    this.barChartLabels= new Array(data.responseRows.length);
    this.dat= new Array(data.responseRows.length);
    for(var item in data.responseRows){
        console.log(data.responseRows[item].Promedio);
        this.dat[item]=data.responseRows[item].Promedio;
        this.barChartLabels[item]="Level 0"+(+item+1)+"";
    }
    this.barChartData[0].data=this.dat;
    this.isLoaded=true;
})

      
}

 // events
 public chartClicked(e:any):void {

 }

 public chartHovered(e:any):void {
 
 }

 public randomize():void {
   // Only Change 3 values
   let data = [
     Math.round(Math.random() * 100),
     59,
     80,
     (Math.random() * 100),
     56,
     (Math.random() * 100),
     40];
   let clone = JSON.parse(JSON.stringify(this.barChartData));
   clone[0].data = data;
   this.barChartData = clone;
   /**
    * (My guess), for Angular to recognize the change in the dataset
    * it has to change the dataset variable directly,
    * so one way around it, is to clone the data, change it and then
    * assign it;
    */
 }
}