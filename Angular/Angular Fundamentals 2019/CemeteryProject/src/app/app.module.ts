import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { EmployeesAppComponent } from './employees-app.component';
import { JSONClientService } from './json-client.service';
import { HttpClientModule } from '@angular/common/http';
import { XMLClientService } from './xml-client.service';

@NgModule({
  declarations: [EmployeesAppComponent],
  imports: [BrowserModule,HttpClientModule],
  providers: [JSONClientService,XMLClientService],
  bootstrap: [EmployeesAppComponent]
})
export class AppModule { }