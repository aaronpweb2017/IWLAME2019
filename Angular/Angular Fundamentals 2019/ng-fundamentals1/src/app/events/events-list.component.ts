import { Component, OnInit } from '@angular/core';
import { EventService } from './shared/event.service';
import { ToastService } from './common/toastr.service';

declare let toastr

@Component({
    selector: 'events-list',
    templateUrl: './events-list.component.html',
})

export class EventsListComponent implements OnInit {
    events:any[]
    
    handleEventClicked(id) {
        alert('Clicked Event Id: '+id);
        console.log('Clicked Event Id: '+id);
    }
    constructor(private eventService: EventService, private toastr : ToastService) { }
    
    ngOnInit() {
      this.events = this.eventService.getEvents()
    }

    handleThumbnailClick(eventName) {
      this.toastr.success("Click on: "+eventName+ "event.")
    }
}