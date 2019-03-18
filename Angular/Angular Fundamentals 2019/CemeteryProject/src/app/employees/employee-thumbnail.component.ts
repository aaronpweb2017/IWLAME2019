import { Component, Input} from '@angular/core'

@Component({
    selector: 'employee-thumbnail',
    templateUrl: './employee-thumbnail.component.html'
})

export class EventThumbnailComponent {
    @Input() employee:any;
}