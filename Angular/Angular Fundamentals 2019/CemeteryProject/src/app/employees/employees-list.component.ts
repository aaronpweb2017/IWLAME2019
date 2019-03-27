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
  page_indexes:number[];
  noPage:number;
  noSelBtn:number;
  constructor(private employeesService:EmployeesService, private route:ActivatedRoute, private router:Router) { }
  
  ngOnInit() {
    this.employeesService.ngOnInit();
    this.employees=this.employeesService.getEmployees();
    setTimeout(()=> { this.employees=this.employeesService.getEmployees();
      this.page_indexes=this.getArrayFromAToB(1,(this.employees.length/5)+1); },1000);
    this.noPage=this.route.snapshot.params['pg']; this.noSelBtn=1;
  }
  
  redirectEmployeePage(currentButtonId:number,currentnoPage:number) {
    this.noPage=currentnoPage;
    this.noSelBtn=currentButtonId;
    this.router.navigate(['/employees',this.noPage]);
  }

  getArrayFromAToB(a:number,b:number) {
    let colsArray:number[]=[];
    for(let index=0; index<(b-a); index++) 
      colsArray[index]=a+index;
    return colsArray;
  }
}