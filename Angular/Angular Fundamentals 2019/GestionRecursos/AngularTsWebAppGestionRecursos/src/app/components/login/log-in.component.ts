import { Component, OnInit } from '@angular/core';
import { Empleado } from 'src/app/interfaces/empleado';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { token } from 'src/app/tokens';

@Component({
  selector: 'log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})

export class LogInComponent implements OnInit {
  title: string;
  id_empleado: number;
  password: string;
  empleado: Empleado;
  isLoggedIn: boolean;

  constructor(private empleadosService: EmpleadosService,
    private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.title = 'Gestión de Recursos Asignados 2019';
    this.id_empleado = 0; this.password = "";
    this.empleado = {
      id_empleado: 0, nombre: "", apellido: "",
      direccion: "", telefono: "", sueldo: 0,
      status: 0
    };
    this.isLoggedIn = false;
  }

  ValidaUsuario() {
    if (this.id_empleado <= 0 || this.password == "") {
      this.toastrService.error("Ingrese código o contraseña."); return;
    }
    this.empleadosService.GetEmpleado(this.id_empleado).subscribe(data => {
      if ((data as Empleado) == null) {
        this.toastrService.error("No se encontró al empleado."); return;
      }
      this.empleado = data as Empleado;
      this.toastrService.success("Bienvenido " + this.empleado.nombre
        + " " + this.empleado.apellido); this.isLoggedIn = true;
      this.router.navigate(['/empleados/index']);
    });
  }
}