import { Component } from '@angular/core';
import { GlobalService } from 'src/app/global.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  loggedd: boolean;
  title: string = 'PeliculasWebApp';

  constructor(private globalService: GlobalService) { }
}