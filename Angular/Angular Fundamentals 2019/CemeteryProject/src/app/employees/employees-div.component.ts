import { Component, Input} from '@angular/core';

@Component({
    selector: 'employees-div',
    templateUrl: './employees-div.component.html',
    styleUrls: ['./employees-div.component.css']
})

export class EmployeesDivComponent {
    @Input() employees:any[];
    @Input() noRowSep:number;
    
    getArrayFromAToB(a:number,b:number) {
        let colsArray:number[]=[];
        for(let index=0; index<(b-a); index++) {
          colsArray[index]=a+index;
        }
        return colsArray;
    }
}