import { Component, Input, Output, EventEmitter } from '@angular/core'

@Component({
    selector: 'event-thumbnail',
    templateUrl: './event-thumbnail.component.html'
})

export class EventThumbnailComponent {
    @Input() employee : any
    @Input() employeesQuantity : any 
    @Output() eventClick = new EventEmitter()
    handleClickMe() {
        alert('Some employee clicked...');
        console.log('Some employee clicked...');
        this.eventClick.emit(this.employee.id);
    }
    showEmployeesQuantity() {
        alert('CurrentEmployeesQuantity: '+this.employeesQuantity);
    }
}