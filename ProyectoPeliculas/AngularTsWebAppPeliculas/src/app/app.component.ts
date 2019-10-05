import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'PeliculasWebApp';

  constructor() {
    localStorage.setItem('apiUrl', 'https://189.186.51.66:443/Api');
  }
}