import {Component } from '@angular/core';
import { NgxXml2jsonService } from 'ngx-xml2json';
import { XMLClientService } from './xml-client.service';

@Component({
  selector: 'employees-app',
  templateUrl: './employees-app.component.html'
})

export class EmployeesAppComponent {
  title='TheCemeteryProject';
  employees:any[];
  constructor(private ngxXml2jsonService:NgxXml2jsonService, private xmlClientService:XMLClientService) { }
    ngOnInit() {
      this.xmlClientService.getTextFile('assets/employees.xml').subscribe(data => {
        const xmlFileContent=data; const parser=new DOMParser();
        const xml=parser.parseFromString(xmlFileContent,'text/xml');
        const obj=this.ngxXml2jsonService.xmlToJson(xml);
        this.employees=Object.values(Object.values(obj)[0])[1];
      });
    }
}