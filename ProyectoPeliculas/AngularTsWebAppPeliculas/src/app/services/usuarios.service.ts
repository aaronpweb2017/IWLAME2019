import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Usuario } from '../interfaces/usuario';

@Injectable()
export class UsuariosService {
  private ApiUsuariosURL: string;
  private ApiGetTokenAuthenticationURL: string;
  private ApiCrearUsuarioURL: string;
  private ApiSolicitudTokenURL: string;

  constructor(private http: HttpClient) {
    this.ApiUsuariosURL = "https://localhost:5001/Api/Usuarios";
  }

  getTokenAuthentication(usuario: Usuario): Observable<any> {
    this.ApiGetTokenAuthenticationURL = this.ApiUsuariosURL + "/GetTokenAuthentication";
    return this.http.post(this.ApiGetTokenAuthenticationURL, usuario, { responseType: 'text' });
  }

  crearUsuario(usuario: Usuario): Observable<any> {
    this.ApiCrearUsuarioURL = this.ApiUsuariosURL + "/CrearUsuario";
    return this.http.post(this.ApiCrearUsuarioURL, usuario);
  }

  solicitudToken(usuario: Usuario): Observable<any> {
    this.ApiSolicitudTokenURL = this.ApiUsuariosURL + "/SolicitudToken";
    return this.http.post(this.ApiSolicitudTokenURL, usuario);
  }
}