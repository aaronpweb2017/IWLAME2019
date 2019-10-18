import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'PeliculasWebApp';

  constructor() {
    //localStorage.setItem('apiUrl', 'https://187.149.72.4:443/Api');
    localStorage.setItem('apiUrl', 'https://192.168.1.68:443/Api');
  }
}