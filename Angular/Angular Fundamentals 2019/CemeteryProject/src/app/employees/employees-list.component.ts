import { Component} from '@angular/core';
import { EmployeesService } from './shared/employees.service';

@Component({
  selector: 'employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})

export class EmployeesListComponent {
  employees:any[];
  constructor(private employeesService:EmployeesService) { }
  ngOnInit() {
    this.employeesService.ngOnInit();
    this.employees=this.employeesService.getEmployees();
    setTimeout(()=>{this.employees=this.employeesService.getEmployees();}, 1000);
  }
}