import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '../shared/event.service';

@Component ({
    templateUrl: './event-details.component.html',
    styleUrls: ['./event-details.component.css']
})

export class EventDetailsComponent {
    event:any;
    constructor(private eventService:EventService, private route:ActivatedRoute) { }
    ngOnInit() {
        this.event=this.eventService.getEvent(this.route.snapshot.params['id']);
    }
}