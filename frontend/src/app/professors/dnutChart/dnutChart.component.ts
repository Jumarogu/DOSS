import { Component, EventEmitter } from '@angular/core';
import { DataService } from '../../services/data.service';
import { AuthService } from '../../services/auth/auth.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
 

@Component({
 selector: 'dnutChart',
 templateUrl: 'dnutChart.component.html'
})
export class dnutChart implements OnInit {
 // Doughnut
    private doughnutChartLabels:string[] = ['Regular', 'Bueno', 'Excelente'];
    private doughnutChartData:number[] = [0, 0, 0];
    private doughnutChartType:string = 'doughnut';
    private currentUser: any;
    private students: any[];
    private dataLoaded: boolean;
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

    constructor (private dataService: DataService, private auth: AuthService) {
        this.dataLoaded = false;
        this.dataService.getUser(this.auth.currentUser.email).subscribe(data => {
            this.currentUser = data[0];
            this.dataService.getAlumnosLastGame(this.currentUser.grupo).subscribe(data => {
                this.students = data;
                this.fillData(this.students);
            })
        })
    }
    ngOnInit(){
 
    }

    fillData(students: any[]){
        
        let buenDes = 0, excelenteDes = 0, regularDes = 0;
        for (let i = 0; i < students.length; i++) {
            if(students[i].desempeno == 'Regular') {
                regularDes ++;
            } else if(students[i].desempeno == 'Bueno') {
                buenDes ++;
            } else if(students[i].desempeno == 'Excelente') {
                excelenteDes ++;
            }
        }
        this.doughnutChartData[0] = regularDes;
        this.doughnutChartData[1] = buenDes;
        this.doughnutChartData[2] = excelenteDes;
        this.dataLoaded = true;
    }
    // events
    public chartClicked(e:any):void {
    console.log(e);
    }

    public chartHovered(e:any):void {
    console.log(e);
    }
}