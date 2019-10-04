import { Component } from '@angular/core';

@Component({
  selector: 'app-topnavbar',
  templateUrl: './topnavbar.component.html',
  styles: []
})

export class TopNavbarComponent {
  constructor() { }

  isLogged() {
    return JSON.parse(localStorage.getItem('logged'));
  }

  isAdmin() {
    return JSON.parse(localStorage.getItem('admin'));
  }
}