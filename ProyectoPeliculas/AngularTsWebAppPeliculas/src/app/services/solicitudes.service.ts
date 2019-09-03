import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class SolicitudesService {
  private ApiSolicitudesURL: string;
  private ApiGetNoSolicitudesURL: string;
  private ApiGetSolicitudesPaginacionURL: string;
  private ApiAprobarSolicitudURL: string;

  constructor(private http: HttpClient) {
    this.ApiSolicitudesURL = "https://localhost:5001/Api/Solicitudes";
  }

  GetNoSolicitudes(): Observable<any> {
    this.ApiGetNoSolicitudesURL = this.ApiSolicitudesURL + "/GetNoSolicitudes";
    return this.http.get(this.ApiGetNoSolicitudesURL);
  }

  GetSolicitudesPaginacion(no_pagina: number): Observable<any> {
    this.ApiGetSolicitudesPaginacionURL = this.ApiSolicitudesURL
      + "/GetSolicitudesPaginacion/?no_pagina=" + no_pagina;
    return this.http.get(this.ApiGetSolicitudesPaginacionURL);
  }

  AprobarSolicitud(id_usuario_solicitud: number): Observable<any> {
    this.ApiAprobarSolicitudURL = this.ApiSolicitudesURL+ "/AprobarSolicitud/";
    return this.http.put(this.ApiAprobarSolicitudURL, id_usuario_solicitud);
  }
}