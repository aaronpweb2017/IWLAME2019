import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { apiURL, header } from '../global.service';
import { VSolicitud } from '../interfaces/views/v-solicitud';
import { VToken } from '../interfaces/views/v-token';
import { VResolucion } from '../interfaces/views/v-resolucion';
import { VDetalleTecnico } from '../interfaces/views/v-detalle-tecnico';
import { VDescarga } from '../interfaces/views/v-descarga';

@Injectable()
export class VistasService {
  private ApiVistasURL: string;
  private ApiGetVistaSolicitudesURL: string;
  private ApiGetVistaTokensURL: string;
  private ApiGetVistaResolucionesURL: string;
  private ApiGetVistaDetallesTecnicosURL: string;
  private ApiGetVistaDescargasURL: string;

  constructor(private http: HttpClient) {
    this.ApiVistasURL = apiURL+"/Vistas";
  }

  getVistaSolicitudes(): Observable<VSolicitud[]> {
    this.ApiGetVistaSolicitudesURL = this.ApiVistasURL + "/GetVistaSolicitudes";
    return this.http.get(this.ApiGetVistaSolicitudesURL
    ).pipe(map((data: any) => data as VSolicitud[]));
  }

  getVistaTokens(): Observable<VToken[]> {
    this.ApiGetVistaTokensURL = this.ApiVistasURL + "/GetVistaTokens";
    return this.http.get(this.ApiGetVistaTokensURL
    ).pipe(map((data: any) => data as VToken[]));
  }

  getVistaResoluciones(): Observable<VResolucion[]> {
    this.ApiGetVistaResolucionesURL = this.ApiVistasURL + "/GetVistaResoluciones";
    return this.http.get(this.ApiGetVistaResolucionesURL
    ).pipe(map((data: any) => data as VResolucion[]));
  }

  getVistaDetallesTecnicos(): Observable<VDetalleTecnico[]> {
    this.ApiGetVistaDetallesTecnicosURL = this.ApiVistasURL + "/GetVistaDetallesTecnicos";
    return this.http.get(this.ApiGetVistaDetallesTecnicosURL
    ).pipe(map((data: any) => data as VDetalleTecnico[]));
  }

  getVistaDescargas(): Observable<VDescarga[]> {
    this.ApiGetVistaDescargasURL = this.ApiVistasURL + "/GetVistaDescargas";
    return this.http.get(this.ApiGetVistaDescargasURL
    ).pipe(map((data: any) => data as VDescarga[]));
  }
}