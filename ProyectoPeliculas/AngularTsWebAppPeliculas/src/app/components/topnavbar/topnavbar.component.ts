import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-topnavbar',
  templateUrl: './topnavbar.component.html',
  styles: []
})

export class TopNavbarComponent {
  projectName = "MoviesProject2019";
  busqueda: string;

  constructor(private router: Router) { }

  isLogged() {
    return JSON.parse(localStorage.getItem('logged'));
  }

  isAdmin() {
    return JSON.parse(localStorage.getItem('admin'));
  }

  buscarPelicula() {
    this.router.navigate(['/home', { busqueda: this.busqueda }]);
  }
}