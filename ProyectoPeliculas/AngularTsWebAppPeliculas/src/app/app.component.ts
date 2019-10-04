import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'PeliculasWebApp';

  constructor() {
    localStorage.setItem('apiUrl', 'https://localhost:5001/Api');
  }
}