import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Usuario } from '../interfaces/usuario';

@Injectable()
export class UsuariosService {
  private ApiUsuariosURL: string;
  private ApiCrearUsuarioURL: string;
  private ApiGetUsuarioURL: string;
  private ApiGetUsuariosURL: string;
  
  private ApiGetDecryptedPasswordURL: string;

  private ApiSolicitudTokenURL: string;
  private ApiGetTokenAuthenticationURL: string;
  private ApiSendForgottenPasswordURL: string;
  
  constructor(private http: HttpClient) {
    this.ApiUsuariosURL = "https://localhost:5001/Api/Usuarios";
  }

  crearUsuario(usuario: Usuario): Observable<any> {
    this.ApiCrearUsuarioURL = this.ApiUsuariosURL + "/CrearUsuario";
    return this.http.post(this.ApiCrearUsuarioURL, usuario);
  }

  getUsuario(username_email: string): Observable<any> {
    this.ApiGetUsuarioURL = this.ApiUsuariosURL
    + "/GetUsuario/?username_email="+username_email;
    return this.http.get(this.ApiGetUsuarioURL); 
  }
  
  getUsuarios(): Observable<Usuario[]> {
    this.ApiGetUsuariosURL = this.ApiUsuariosURL+ "/GetUsuarios";
    return this.http.get(this.ApiGetUsuariosURL).pipe(
      map((data: any) => data as Usuario[])
    ); 
  }

  getDecryptedPassword(id_usuario: number): Observable<string> {
    this.ApiGetDecryptedPasswordURL = this.ApiUsuariosURL
    + "/GetDecryptedPassword/?id_usuario="+id_usuario;
    return this.http.get(this.ApiGetDecryptedPasswordURL).pipe(
      map((data: any) => data as string)
    );
  }

  solicitudToken(usuario: Usuario): Observable<any> {
    this.ApiSolicitudTokenURL = this.ApiUsuariosURL + "/SolicitudToken";
    return this.http.post(this.ApiSolicitudTokenURL, usuario);
  }

  getTokenAuthentication(usuario: Usuario): Observable<any> {
    this.ApiGetTokenAuthenticationURL = this.ApiUsuariosURL + "/GetTokenAuthentication";
    return this.http.post(this.ApiGetTokenAuthenticationURL, usuario, { responseType: 'text' });
  }

  getForgottenPassword(correo_usuario: string): Observable<any> {
    this.ApiSendForgottenPasswordURL = this.ApiUsuariosURL
      + "/GetForgottenPassword/?correo_usuario="+correo_usuario;
    return this.http.get(this.ApiSendForgottenPasswordURL);
  }
}