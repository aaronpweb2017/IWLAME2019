import { Component} from '@angular/core';
import { EmployeesService } from './shared/employees.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})

export class EmployeesListComponent {
  employees:any[];
  rows:any[]; cols:any[];
  noRowSep:number;
  constructor(private employeesService:EmployeesService, private route:ActivatedRoute) { }
  ngOnInit() {
    this.employeesService.ngOnInit();
    this.employees=this.employeesService.getEmployees();
    setTimeout(()=>{this.employees=this.employeesService.getEmployees();}, 1000);
    this.noRowSep=this.route.snapshot.params['pg'];
  }
  
  getArrayFromAToB(a:number,b:number) {
    let colsArray:number[]=[];
    let index:number=0;
    for(let i=0; i<(b-a); i+=1) {
      colsArray[i]=a+i;
    }
    return colsArray;
  }
  wtfFunction(){
    console.log("you make click here.")
  }
}