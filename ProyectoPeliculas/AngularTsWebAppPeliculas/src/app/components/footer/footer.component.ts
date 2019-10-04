import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styles: []
})

export class FooterComponent  {
  constructor() { }

  isLogged() {
    return JSON.parse(localStorage.getItem('logged'));
  }
}