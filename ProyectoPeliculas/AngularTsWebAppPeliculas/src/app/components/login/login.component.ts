import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/interfaces/usuario';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  passOlvidada: boolean;
  nuevaCuenta: boolean;
  emailPattern: RegExp;
  userNameEmailLogIn: string;
  emailToSendPass: string;
  passwordLogIn: string;
  passwordSignIn1: string;
  passwordSignIn2: string;
  usuario: Usuario;

  constructor(private usuariosService: UsuariosService,
    private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.passOlvidada = false;
    this.nuevaCuenta = false;
    this.emailPattern = /\b[a-z0-9-_.]+@[a-z0-9-_.]+(\.[a-z0-9]+)+/;
    this.userNameEmailLogIn = "";
    this.emailToSendPass = "";
    this.passwordLogIn = "";
    this.passwordSignIn1 = "";
    this.passwordSignIn2 = "";
    this.usuario = {
      id_usuario: 0, nombre_usuario: "",
      correo_usuario: "", password_usuario: "",
      tipo_usuario: 0, token_usuario: ""
    }
  }

  iniciarSesion() {
    this.usuario.correo_usuario = ""; this.usuario.nombre_usuario = "";
    this.usuario.password_usuario = this.passwordLogIn;
    if (String(this.userNameEmailLogIn).search(this.emailPattern) != -1) {
      this.usuario.correo_usuario = this.userNameEmailLogIn;
    }
    else {
      this.usuario.nombre_usuario = this.userNameEmailLogIn;
    }
    this.usuariosService.getTokenAuthentication(this.usuario).subscribe(data => {
      console.log("token: " + data);
    });
  }

  passwordOlvidada() {
    if (this.passOlvidada)
      this.passOlvidada = false;
    else
      this.passOlvidada = true;
    this.nuevaCuenta = false;
  }

  verificarCrearCuentaNueva() {
    if (this.nuevaCuenta)
      this.nuevaCuenta = false;
    else
      this.nuevaCuenta = true;
    this.passOlvidada = false;
  }

  crearCuentaNueva() {
    if(this.passwordSignIn1 != this.passwordSignIn2) {
      this.toastrService.error("Contraseñas distintas.");
      return;
    }
    this.usuario.password_usuario = this.passwordSignIn1;
    this.usuariosService.crearUsuario(this.usuario).subscribe(data => {
      console.log("result: " + data);
    });
  }
}