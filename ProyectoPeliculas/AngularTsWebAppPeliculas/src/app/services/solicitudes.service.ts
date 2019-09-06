import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class SolicitudesService {
  private ApiSolicitudesURL: string;
  private ApiAprobarSolicitudURL: string;

  constructor(private http: HttpClient) {
    this.ApiSolicitudesURL = "https://localhost:5001/Api/Solicitudes";
  }

  aprobarSolicitud(id_usuario_solicitud: number): Observable<any> {
    this.ApiAprobarSolicitudURL = this.ApiSolicitudesURL+ "/AprobarSolicitud";
    return this.http.put(this.ApiAprobarSolicitudURL, id_usuario_solicitud);
  }
}