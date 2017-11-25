import { Component, EventEmitter } from '@angular/core';
 

@Component({
 selector: 'dnutChart',
 templateUrl: 'dnutChart.component.html'
})
export class dnutChart {
 // Doughnut
 public doughnutChartLabels:string[] = ['Bueno', 'Medio', 'Malo'];
 public doughnutChartData:number[] = [5, 10, 15];
 public doughnutChartType:string = 'doughnut';
 private colors = [
    {
      backgroundColor: [
        'rgba(0, 255, 0, 0.4)',
        'rgba(255, 206, 86, 0.4)',
        'rgba(255, 0, 0, 0.4)',
        'rgba(0, 255, 0, 0)',
        'rgba(102, 0, 204, 0)',
        'rgba(255, 128, 0, 0)'
      ]
    }
    ];

 // events
 public chartClicked(e:any):void {
   console.log(e);
 }

 public chartHovered(e:any):void {
   console.log(e);
 }
}