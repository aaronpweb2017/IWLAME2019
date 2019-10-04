import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/interfaces/usuario';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  emailPattern: RegExp;
  flagForgottenPassword: boolean;
  flagNuevaCuenta: boolean;
  userNameEmail: string;
  passwordLogIn: string;
  emailToSendPass: string;
  passwordSignIn1: string;
  passwordSignIn2: string;
  usuario: Usuario;

  constructor(private usuariosService: UsuariosService,
    private router: Router, private toastrService: ToastrService) { }

  ngOnInit() {
    this.emailPattern = /\b[a-z0-9-_.]+@[a-z0-9-_.]+(\.[a-z0-9]+)+/;
    this.flagForgottenPassword = false;
    this.flagNuevaCuenta = false;
    this.userNameEmail = "";
    this.passwordLogIn = "";
    this.emailToSendPass = "";
    this.passwordSignIn1 = "";
    this.passwordSignIn2 = "";
    this.usuario = {
      id_usuario: 0, nombre_usuario: "",
      correo_usuario: "", password_usuario: "",
      tipo_usuario: 0
    }
  }

  setUserLogInAttributes() {
    this.usuario.correo_usuario = ""; this.usuario.nombre_usuario = "";
    if (String(this.userNameEmail).search(this.emailPattern) != -1) {
      this.usuario.correo_usuario = this.userNameEmail;
    }
    else {
      this.usuario.nombre_usuario = this.userNameEmail;
    }
    this.usuario.password_usuario = this.passwordLogIn;
  }

  getUserNameEmail(): string {
    if (this.usuario.nombre_usuario.length > 0) {
      return this.usuario.nombre_usuario
    }
    return this.usuario.correo_usuario;
  }

  iniciarSesion() {
    this.setUserLogInAttributes();
    this.usuariosService.getTokenAuthentication(this.usuario).subscribe(
      response => {
        if (response[0] != null) {
          if (response[0].includes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9")) {
            localStorage.setItem('token', "Bearer " + response[0]);
            let username_email: string = this.getUserNameEmail();
            this.usuariosService.getUsuario(username_email).subscribe(
              response => {
                if (response[0]) {
                  this.usuario = response[0];
                  localStorage.setItem('logged', JSON.stringify(true));
                  if(this.usuario.tipo_usuario == 1)
                    localStorage.setItem('admin', JSON.stringify(true));
                  this.toastrService.info("Bienvenido: " + this.usuario.nombre_usuario);
                  this.router.navigate(['/home']); return;
                }
                this.toastrService.error(response[1]);
              }, error => {
                this.toastrService.error(error.message);
              });
            return;
          }
          this.toastrService.error(response[0]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  solicitarToken() {
    this.setUserLogInAttributes();
    this.usuariosService.getTokenAuthentication(this.usuario).subscribe(
      response => {
        if (response[0] != null) {
          if (response[0].includes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9")) {
            this.toastrService.info("Tu token aún no ha expirado..."); return;
          }
          if (response[0].includes("expirado")) {
            this.usuariosService.solicitudToken(this.usuario).subscribe(
              response => {
                if (response[0] != null) {
                  if (response[0]) {
                    this.toastrService.success("Tu solicitud ha sido enviada."); return;
                  }
                  this.toastrService.error("El usuario no existe, la contraseña es"
                    + "incorrecta o tu solicitud ya fue realizada."); return;
                }
                this.toastrService.error(response[1]);
              }, error => {
                this.toastrService.error(error.message);
              });
            return;
          }
          this.toastrService.error(response[0]); return;
        }
        this.toastrService.error(response[1]); return;
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  sendForgottenPassword() {
    this.usuariosService.getForgottenPassword(this.emailToSendPass).subscribe(
      response => {
        if (response[0] != null) {
          if (response[0]) {
            this.toastrService.success("Tu contraseña ha sido enviada a tu correo."); return;
          }
          this.toastrService.info("El usuario no existe."); return;
        }
        this.toastrService.error(response[1]); return;
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  crearCuentaNueva() {
    if (this.passwordSignIn1 != this.passwordSignIn2) {
      this.toastrService.error("Contraseñas distintas.");
      return;
    }
    this.usuario.password_usuario = this.passwordSignIn1;
    this.usuariosService.crearUsuario(this.usuario).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Tu cuenta fue creada con éxito."); return;
        }
        this.toastrService.error(response[1]); return;
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  setFlagForgottenPassword(flag: boolean) {
    this.flagForgottenPassword = flag;
  }

  setFlagNuevaCuenta(flag: boolean) {
    this.flagNuevaCuenta = flag;
  }
}