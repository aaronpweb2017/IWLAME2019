import { Component} from '@angular/core';
import { EmployeesService } from './shared/employees.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})

export class EmployeesListComponent {
  employees:any[];
  rows:any[]; cols:any[];
  noRowSep:number;
  noSelectedBtn:number;
  constructor(private employeesService:EmployeesService, private route:ActivatedRoute, private router:Router) { }
  
  ngOnInit() {
    this.employeesService.ngOnInit();
    this.employees=this.employeesService.getEmployees();
    setTimeout(()=>{this.employees=this.employeesService.getEmployees();},1000);
    this.noRowSep=this.route.snapshot.params['pg']; this.noSelectedBtn=1;
  }
  
  redirectEmployeePage(currentButtonId:number,currentNoRowSep:number) {
    
    this.noSelectedBtn=currentButtonId;
    this.noRowSep=currentNoRowSep;
    console.log('currentButtonId: '+currentButtonId);
    console.log('currentNoRowSep: '+currentNoRowSep);
    this.router.navigate(['/employees',this.noRowSep]);
  }

  getArrayFromAToB(a:number,b:number) {
    let colsArray:number[]=[];
    for(let index=0; index<(b-a); index++) {
      colsArray[index]=a+index;
    }
    return colsArray;
  }
}