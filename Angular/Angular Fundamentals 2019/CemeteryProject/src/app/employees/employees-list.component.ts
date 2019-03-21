import { Component} from '@angular/core';
import { EmployeesService } from './shared/employees.service';

@Component({
  selector: 'employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})

export class EmployeesListComponent {
  employees:any[];
  rows:any[]; cols:any[];
  constructor(private employeesService:EmployeesService) { }
  ngOnInit() {
    this.employeesService.ngOnInit();
    this.employees=this.employeesService.getEmployees();
    setTimeout(()=>{this.employees=this.employeesService.getEmployees();}, 1000);
  }
  
  getArrayFromAToB(a:number,b:number) {
    let colsArray:number[]=[];
    let index:number=0;
    for(let i=0; i<(b-a); i+=1) {
      colsArray[i]=a+i;
    }
    return colsArray;
  }
}