import { Injectable } from '@angular/core';
import { NgxXml2jsonService } from 'ngx-xml2json';
import { XMLClientService } from 'src/app/xml-client.service';

@Injectable()
export class EmployeesService {
    public employees:any[];
    public xmlcontent:string;
    
    constructor(private ngxXml2jsonService:NgxXml2jsonService, private xmlClientService:XMLClientService) { }
    
    ngOnInit() {
        this.xmlClientService.getTextFile('assets/employees.xml').subscribe(data => {
        const xmlFileContent=data;
        this.xmlcontent=xmlFileContent;
        const parser=new DOMParser();
        const xml=parser.parseFromString(xmlFileContent,'text/xml');
        const obj=this.ngxXml2jsonService.xmlToJson(xml);
        this.employees=Object.values(Object.values(obj)[0])[1];
      }); 
    }

    getEmployees() {
      return this.employees;
    }
}