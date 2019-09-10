import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Usuario } from '../interfaces/usuario';
import { apiURL } from '../global.service';

@Injectable()
export class UsuariosService {
  private ApiUsuariosURL: string;
  private ApiCrearUsuarioURL: string;
  private ApiGetUsuarioURL: string;
  private ApiGetUsuariosURL: string;
  private ApiActualizarUsuarioURL: string;
  private ApiGetDecryptedPasswordURL: string;
  private ApiSolicitudTokenURL: string;
  private ApiGetTokenAuthenticationURL: string;
  private ApiGetForgottenPasswordURL: string;
  
  constructor(private http: HttpClient) {
    this.ApiUsuariosURL = apiURL+"/Usuarios";
  }

  crearUsuario(usuario: Usuario): Observable<boolean> {
    this.ApiCrearUsuarioURL = this.ApiUsuariosURL + "/CrearUsuario";
    return this.http.post(this.ApiCrearUsuarioURL, usuario).pipe(
      map((data: any) => data as boolean)
    );
  }

  getUsuario(username_email: string): Observable<Usuario> {
    this.ApiGetUsuarioURL = this.ApiUsuariosURL
    + "/GetUsuario/?username_email="+username_email;
    return this.http.get(this.ApiGetUsuarioURL).pipe(
      map((data: any) => data as Usuario)
    );
  }
  
  getUsuarios(): Observable<Usuario[]> {
    this.ApiGetUsuariosURL = this.ApiUsuariosURL+ "/GetUsuarios";
    return this.http.get(this.ApiGetUsuariosURL).pipe(
      map((data: any) => data as Usuario[])
    ); 
  }

  actualizarUsuario(usuario: Usuario): Observable<boolean> {
    this.ApiActualizarUsuarioURL = this.ApiUsuariosURL + "/ActualizarUsuario";
    return this.http.put(this.ApiActualizarUsuarioURL, usuario).pipe(
      map((data: any) => data as boolean)
    );
  }

  getDecryptedPassword(id_usuario: number): Observable<string> {
    this.ApiGetDecryptedPasswordURL = this.ApiUsuariosURL
    + "/GetDecryptedPassword/?id_usuario="+id_usuario;
    return this.http.get(this.ApiGetDecryptedPasswordURL).pipe(
      map((data: any) => data as string)
    );
  }

  solicitudToken(usuario: Usuario): Observable<boolean> {
    this.ApiSolicitudTokenURL = this.ApiUsuariosURL + "/SolicitudToken";
    return this.http.post(this.ApiSolicitudTokenURL, usuario).pipe(
      map((data: any) => data as boolean)
    );
  }

  getTokenAuthentication(usuario: Usuario): Observable<string> {
    this.ApiGetTokenAuthenticationURL = this.ApiUsuariosURL + "/GetTokenAuthentication";
    return this.http.post(this.ApiGetTokenAuthenticationURL, usuario,
      { responseType: 'text' }).pipe(map((data: any) => data as string)
    );
  }

  getForgottenPassword(correo_usuario: string): Observable<boolean> {
    this.ApiGetForgottenPasswordURL = this.ApiUsuariosURL
      + "/GetForgottenPassword/?correo_usuario="+correo_usuario;
    return this.http.get(this.ApiGetForgottenPasswordURL).pipe(
      map((data: any) => data as boolean)
    );
  }
}