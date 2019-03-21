import { Component, Input} from '@angular/core'

@Component({
    selector: 'employee-thumbnail',
    templateUrl: './employee-thumbnail.component.html',
    styleUrls: ['./employee-thumbnail.component.css']
})

export class EventThumbnailComponent {
    @Input() employee:any;
}