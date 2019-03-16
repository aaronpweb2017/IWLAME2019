import { Component, Input, Output, EventEmitter } from '@angular/core'

@Component({
    selector: 'event-thumbnail',
    templateUrl: './event-thumbnail.component.html',
    styleUrls: ['./event-thumbnail.component.css']
})

export class EventThumbnailComponent {
    @Input() event:any;
    @Input() eventsQuantity:any;
    @Output() eventClick=new EventEmitter();
    handleClickMe() {
        //alert('Some event clicked...');
        console.log('Some event clicked...');
        this.eventClick.emit(this.event.id);
    }
    showSessionsQuantity() {
        alert('CurrentSessionsQuantity: '+this.event.sessions.length);
    }
}