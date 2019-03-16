import { Component, OnInit } from '@angular/core';
import { EventService } from './shared/event.service';
import { ToastrService } from './common/toastr.service';

declare let toastr;

@Component({
    templateUrl: './events-list.component.html'
})

export class EventsListComponent implements OnInit {
    events:any[];
    toastr:ToastrService;

    handleEventClicked(id) {
        //alert('Clicked Event Id: '+id);
        console.log('Clicked Event Id: '+id);
    }
    
    constructor(private eventService:EventService, private toastrService:ToastrService) { }
    
    ngOnInit() {
      this.events=this.eventService.getEvents();
      this.toastr=this.toastrService;
    }

    handleThumbnailClicked(eventName) {
      this.toastr.success("Click on: "+eventName+ "event.");
    }
}