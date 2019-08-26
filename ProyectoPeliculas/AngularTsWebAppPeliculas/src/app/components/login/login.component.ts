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
    private router: Router, private toastrService: ToastrService) {
  }

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
      tipo_usuario: 0, token_usuario: ""
    }
  }

  setUserLogInAttributes() {
    this.usuario.correo_usuario = ""; this.usuario.nombre_usuario = "";
    if(String(this.userNameEmail).search(this.emailPattern) != -1) {
      this.usuario.correo_usuario = this.userNameEmail;
    }
    else {
      this.usuario.nombre_usuario = this.userNameEmail;
    }
    this.usuario.password_usuario = this.passwordLogIn;
  }

  iniciarSesion() {
    this.setUserLogInAttributes();
    this.usuariosService.getTokenAuthentication(this.usuario).subscribe(data => {
      let response: string = data as string;
      if(String(response).search("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9") != -1) {
        this.toastrService.info("Token de navegación: " + response); 
        this.router.navigate(['/home']);
        return;
      }
      this.toastrService.error(response);
    });
  }

  setFlagForgottenPassword() {
    if(this.flagForgottenPassword) {
      this.flagForgottenPassword = false;
      return;
    }
    this.flagForgottenPassword = true;
    this.flagNuevaCuenta = false;
  }

  solicitarToken() {
    this.setUserLogInAttributes();
    this.usuariosService.getTokenAuthentication(this.usuario).subscribe(data => {
      let response: string = data as string;
      if(String(response).search("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9") != -1) {
        this.toastrService.error("Tu token aún no ha expirado..."); return;
      }
      if(String(response).search("Tu token ha expirado") != -1) {
        this.usuariosService.solicitudToken(this.usuario).subscribe(data => {
          let response: boolean = data as boolean;
          if(response) {
            this.toastrService.success("Tu solicitud ha sido enviada."); return;
          }
          this.toastrService.error("Tu solicitud aún no es aprobada."); 
        });
      }
    });
  }

  setFlagNuevaCuenta() {
    if(this.flagNuevaCuenta) {
      this.flagNuevaCuenta = false;
      return;
    }
    this.flagNuevaCuenta = true;
    this.flagForgottenPassword = false;
  }

  crearCuentaNueva() {
    if(this.passwordSignIn1 != this.passwordSignIn2) {
      this.toastrService.error("Contraseñas distintas.");
      return;
    }
    this.usuario.password_usuario = this.passwordSignIn1;
    this.usuariosService.crearUsuario(this.usuario).subscribe(data => {
      let response: boolean = data as boolean;
      if(response) {
        this.toastrService.success("Tu cuenta fue creada con éxito."); return;
      }
      this.toastrService.error("Tu cuenta no pudo ser creada."); 
    });
  }
}