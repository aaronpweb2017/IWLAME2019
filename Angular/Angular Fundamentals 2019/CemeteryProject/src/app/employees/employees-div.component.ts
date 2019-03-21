import { Component, Input} from '@angular/core'

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
        let index:number=0;
        for(let i=0; i<(b-a); i++) {
          colsArray[i]=a+i;
        }
        return colsArray;
    }
}