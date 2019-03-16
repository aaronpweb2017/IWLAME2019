import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule }  from '@angular/router';
import { EventsAppComponent } from './events-app.component'; 
import { EventsListComponent } from './events/events-list.component';
import { EventThumbnailComponent } from './events/event-thumbnail.component';
import { NavBarComponent } from './nav/navbar.component';
import { EventDetailsComponent } from './events/event-details/event-details.component';
import { EventService } from './events/shared/event.service';
import { ToastrService } from './events/common/toastr.service';
import { appRoutes } from './routes';
import { LlllDirective } from './llll.directive';
import { YesPipe } from './yes.pipe';

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  declarations: [
    EventsAppComponent,
    EventsListComponent,
    EventThumbnailComponent,
    NavBarComponent,
    EventDetailsComponent,
    LlllDirective,
    YesPipe
  ],
  providers: [EventService,ToastrService],
  bootstrap: [EventsAppComponent]
})
export class AppModule { }