import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class SolicitudesService {
  private ApiSolicitudesURL: string;
  private header: HttpHeaders;
  private ApiAprobarSolicitudURL: string;

  constructor(private http: HttpClient) {
    this.ApiSolicitudesURL = localStorage.getItem('apiUrl') + "/Solicitudes";
    this.header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': localStorage.getItem('token')
    });
  }

  aprobarSolicitud(id_usuario_solicitud: number): Observable<any[]> {
    this.ApiAprobarSolicitudURL = this.ApiSolicitudesURL + "/AprobarSolicitud";
    return this.http.put(this.ApiAprobarSolicitudURL, id_usuario_solicitud,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }
}