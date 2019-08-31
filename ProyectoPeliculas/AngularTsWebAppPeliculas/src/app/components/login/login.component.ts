import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/interfaces/usuario';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { GlobalService } from 'src/app/global.service';

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
    private router: Router, private toastrService: ToastrService,
    private globalService: GlobalService) { }

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
    if(String(this.userNameEmail).search(this.emailPattern) != -1) {
      this.usuario.correo_usuario = this.userNameEmail;
    }
    else {
      this.usuario.nombre_usuario = this.userNameEmail;
    }
    this.usuario.password_usuario = this.passwordLogIn;
  }

  getUserNameEmail(): string {
    if(this.usuario.nombre_usuario.length > 0) {
      return this.usuario.nombre_usuario
    }
    return this.usuario.correo_usuario;
  }

  iniciarSesion() {
    this.setUserLogInAttributes();
    this.usuariosService.getTokenAuthentication(this.usuario).subscribe(data => {
      let response: string = data as string;
      if(String(response).search("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9") != -1) {
        this.globalService.SetTokenValue(response);
        this.globalService.setLoggedValue(true);
        let username_email: string = this.getUserNameEmail();
        this.usuariosService.getUsuario(username_email).subscribe(data => {
          this.usuario = data as Usuario;
          this.toastrService.info("Bienvenido: " + this.usuario.nombre_usuario); 
          this.router.navigate(['/home']); 
        });
      }
      else {
        this.toastrService.error(response);
      }
    });
  }

  solicitarToken() {
    this.setUserLogInAttributes();
    this.usuariosService.getTokenAuthentication(this.usuario).subscribe(data => {
      let response: string = data as string;
      if(String(response).search("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9") != -1) {
        this.toastrService.info("Tu token aún no ha expirado..."); return;
      }
      if(String(response).search("Tu token ha expirado") != -1) {
        this.usuariosService.solicitudToken(this.usuario).subscribe(data => {
          let response: boolean = data as boolean;
          if(response) {
            this.toastrService.success("Tu solicitud ha sido enviada."); return;
          }
          this.toastrService.info("Tu solicitud aún no es aprobada."); 
        }); return;
      }
      this.toastrService.error(response); 
    });
  }

  sendForgottenPassword() {
    this.usuariosService.getUsuario(this.emailToSendPass).subscribe(data => {
      if(data as Usuario) {
        this.usuariosService.getForgottenPassword(this.emailToSendPass).subscribe(data => {
          let response: boolean = data as boolean;
          if(response) {
            this.toastrService.success("Tu contraseña ha sido enviada a tu correo."); return;
          }
          this.toastrService.error("Tu solicitud no pudo realizarse debido a un problema.");
        }); return;
      }
      this.toastrService.error("El usuario no existe.");
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