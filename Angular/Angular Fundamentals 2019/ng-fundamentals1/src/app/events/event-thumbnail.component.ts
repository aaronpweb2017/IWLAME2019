import { Component, Input, Output, EventEmitter } from '@angular/core'

@Component({
    selector: 'event-thumbnail',
    templateUrl: './event-thumbnail.component.html',
    styles: [
        `.red { color: #FF0000 !important; }
        .green { color: #00FF00 !important; }
        .blue { color: #0000FF !important; }
        .yellow { color: #FFFF00 !important; }
        .bold { font-weight: bold; }
        .oblique { font-style: oblique; }
        .italic { font-style: italic; }
        .normal { font-style: normal; }
        .thumbnail { min-height: 210px; }
        .pad-left { margin-left: 10px; }
        .well_div { color: #bbb; }`
    ]
})

export class EventThumbnailComponent {
    @Input() event : any
    @Input() eventsQuantity : any 
    @Output() eventClick = new EventEmitter()
    handleClickMe() {
        alert('Some event clicked...');
        console.log('Some event clicked...');
        this.eventClick.emit(this.event.id);
    }
    showSessionsQuantity() {
        alert('CurrentSessionsQuantity: '+this.event.sessions.length);
    }
}