import { Routes } from '@angular/router';
import { EmployeesListComponent } from './employees/employees-list.component';

export const appRoutes:Routes = [{path: 'employees/:pg', component: EmployeesListComponent},
                                {path: '', redirectTo: '/employees/1', pathMatch: 'full'}];