import { NgModule } from '@angular/core';
import { Routes, RouterModule }  from '@angular/router'
import { BrowserModule } from '@angular/platform-browser';
import { EventsAppComponent } from './events-app.component'; 
import { EventsListComponent } from './events/events-list.component';
import { EventThumbnailComponent } from './events/event-thumbnail.component';
import { NavBarComponent } from './nav/navbar.component';
import { EventService } from './events/shared/event.service';
import { ToastService } from './events/common/toastr.service';
import { EventDetailsComponent } from './events/event-details/event-details.component';
import { appRoutes } from './routes';

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  declarations: [
    EventsAppComponent,
    EventsListComponent,
    EventThumbnailComponent,
    EventDetailsComponent,
    NavBarComponent
  ],
  providers: [EventService, ToastService],
  bootstrap: [EventsAppComponent]
})
export class AppModule { }