import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class VistasService {
  private ApiVistasURL: string;
  private header: HttpHeaders;
  private ApiGetVistaSolicitudesURL: string;
  private ApiGetVistaTokensURL: string;
  private ApiGetVistaResolucionesURL: string;
  private ApiGetVistaDetallesTecnicosURL: string;
  private ApiGetVistaDetalleTecnicoPeliculaURL: string;
  private ApiGetVistaDescargasURL: string;
  private ApiGetVistaDescargasPeliculaURL: string;

  constructor(private http: HttpClient) {
    this.ApiVistasURL = localStorage.getItem('apiUrl') + "/Vistas";
    this.header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': localStorage.getItem('token')
    });
  }

  getVistaSolicitudes(): Observable<any[]> {
    this.ApiGetVistaSolicitudesURL = this.ApiVistasURL + "/GetVistaSolicitudes";
    return this.http.get(this.ApiGetVistaSolicitudesURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getVistaTokens(): Observable<any[]> {
    this.ApiGetVistaTokensURL = this.ApiVistasURL + "/GetVistaTokens";
    return this.http.get(this.ApiGetVistaTokensURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getVistaResoluciones(): Observable<any[]> {
    this.ApiGetVistaResolucionesURL = this.ApiVistasURL + "/GetVistaResoluciones";
    return this.http.get(this.ApiGetVistaResolucionesURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getVistaDetallesTecnicos(): Observable<any[]> {
    this.ApiGetVistaDetallesTecnicosURL = this.ApiVistasURL + "/GetVistaDetallesTecnicos";
    return this.http.get(this.ApiGetVistaDetallesTecnicosURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getVistaDetalleTecnicoPelicula(id_pelicula: number): Observable<any[]> {
    this.ApiGetVistaDetalleTecnicoPeliculaURL = this.ApiVistasURL
      + "/GetVistaDetalleTecnicoPelicula/?id_pelicula=" + id_pelicula;
    return this.http.get(this.ApiGetVistaDetalleTecnicoPeliculaURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getVistaDescargas(): Observable<any[]> {
    this.ApiGetVistaDescargasURL = this.ApiVistasURL + "/GetVistaDescargas";
    return this.http.get(this.ApiGetVistaDescargasURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getVistaDescargasPelicula(id_pelicula: number): Observable<any[]> {
    this.ApiGetVistaDescargasPeliculaURL = this.ApiVistasURL
    + "/GetVistaDescargasPelicula?id_pelicula="+ id_pelicula;
    return this.http.get(this.ApiGetVistaDescargasPeliculaURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }
}