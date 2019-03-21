import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { EmployeesAppComponent } from './employees-app.component';
import { JSONClientService } from './json-client.service';
import { HttpClientModule } from '@angular/common/http';
import { XMLClientService } from './xml-client.service';
import { EmployeesListComponent } from './employees/employees-list.component';
import { EmployeesDivComponent } from './employees/employees-div.component';
import { EmployeeThumbnailComponent } from './employees/employee-thumbnail.component';
import { EmployeesService } from './employees/shared/employees.service';

@NgModule({
  declarations: [EmployeesAppComponent,
    EmployeesListComponent,
    EmployeesDivComponent,
    EmployeeThumbnailComponent],
  imports: [BrowserModule,
    HttpClientModule],
  providers: [JSONClientService,
    XMLClientService,
    EmployeesService],
  bootstrap: [EmployeesAppComponent]
})
export class AppModule { }