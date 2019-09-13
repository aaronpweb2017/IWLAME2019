import { Component } from '@angular/core';
import { GlobalService } from 'src/app/global.service';

@Component({
  selector: 'app-topnavbar',
  templateUrl: './topnavbar.component.html',
  styles: []
})

export class TopNavbarComponent {
  constructor(private globalService: GlobalService) { }
}