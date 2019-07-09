import { Component, OnInit } from '@angular/core';
import { Empleado } from 'src/app/interfaces/empleado';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/token-service';

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
    private toastrService: ToastrService, private router:
      Router, private tokenService: TokenService) { }

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
    if (this.id_empleado <= 0 || this.password.length == 0) {
      this.toastrService.error("Ingrese código o contraseña."); return;
    }
    this.empleado.id_empleado = this.id_empleado;
    this.empleadosService.GetTokenAuthentication(this.empleado).subscribe(data => {
      let tokenValue: string = data as string;
      this.tokenService.SetTokenValue(tokenValue);
      this.empleadosService.GetEmpleado(this.id_empleado).subscribe(data => {
        this.empleado = data as Empleado;
        this.toastrService.success("Bienvenido " + this.empleado.nombre
          + " " + this.empleado.apellido); this.isLoggedIn = true;
        this.router.navigate(['/empleados/index']);
      },
        (error) => {
          this.toastrService.error("Error: " + error.name
          + " (" + error.status + "): " + error.statusText);
        });
    });
  }
}