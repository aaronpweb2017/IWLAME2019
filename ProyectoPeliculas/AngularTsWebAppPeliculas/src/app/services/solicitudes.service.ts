import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { apiURL, header } from '../global.service';

@Injectable()
export class SolicitudesService {
  private ApiSolicitudesURL: string;
  private ApiAprobarSolicitudURL: string;

  constructor(private http: HttpClient) {
    this.ApiSolicitudesURL = apiURL+"/Solicitudes";
  }

  aprobarSolicitud(id_usuario_solicitud: number): Observable<boolean> {
    this.ApiAprobarSolicitudURL = this.ApiSolicitudesURL+ "/AprobarSolicitud";
    return this.http.put(this.ApiAprobarSolicitudURL, id_usuario_solicitud,
    {headers: header}).pipe(map((data: any) => data as boolean));
  }
}