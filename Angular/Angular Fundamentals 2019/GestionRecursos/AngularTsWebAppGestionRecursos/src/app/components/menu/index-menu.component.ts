import { Component} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'index-menu',
  templateUrl: './index-menu.component.html',
  styleUrls: ['./index-menu.component.css']
})

export class IndexMenuComponent
{
  constructor(private router: Router) { }

  EmpleadosRequest() {
    this.router.navigate(['/empleados/index']);
  }
  
  ProyectosRequest() {
    this.router.navigate(['/proyectos/index']);
  }
  
  AsignacionesRequest() {
    this.router.navigate(['/asignaciones/index']);
  }
}