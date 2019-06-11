import { Component, OnInit } from '@angular/core';
import { EmpleadosService } from '../../services/empleados-service';
import { Empleado } from "../../interfaces/Empleado";
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

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
      if (data == null) {
        this.toastrService.error("No se encontró al empleado."); return;
      }
      this.empleado.id_empleado = Number(Object.values(data)[0]);
      this.empleado.nombre = (Object.values(data)[1]).toString();
      this.empleado.apellido = (Object.values(data)[2]).toString();
      this.toastrService.success("Bienvenido " + this.empleado.nombre + " " + this.empleado.apellido);
      this.isLoggedIn = true; this.router.navigate(['/empleados/index']);
    });
  }
  
  ValidaUsuario1() {
    //this.empleadosService.GetEmpleados().subscribe(data => {
      //Tamaño de data (array de objetos Empleado) --> Object.values(data).length;
      //Objeto Empleado "i" --> Object.values(data)[i];
      //Atributo j del Objeto "i" --> Object.values(Object.values(data)[i])[j]
    //});
  }
}