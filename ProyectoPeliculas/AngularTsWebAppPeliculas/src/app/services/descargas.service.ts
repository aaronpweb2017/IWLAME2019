import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { apiURL } from '../global.service';
import { TipoArchivo } from '../interfaces/descargas/tipo-archivo';
import { Servidor } from '../interfaces/descargas/servidor';

@Injectable()
export class DescargasService {
  private ApiDescargasURL: string;
  private ApiCrearTipoArchivoURL: string;
  private ApiGetTiposArchivoURL: string;
  private ApiActualizarTipoArchivoURL: string;
  private ApiEliminarTipoArchivoURL: string;

  private ApiCrearServidorURL: string;
  private ApiGetServidoresURL: string;
  private ApiActualizarServidorURL: string;
  private ApiEliminarServidorURL: string;

  constructor(private http: HttpClient) {
    this.ApiDescargasURL = apiURL+"/Descargas";
  }

  crearTipoArchivo(tipoArchivo: TipoArchivo): Observable<boolean> {
    this.ApiCrearTipoArchivoURL = this.ApiDescargasURL + "/CrearTipoArchivo";
    return this.http.post(this.ApiCrearTipoArchivoURL, tipoArchivo
    ).pipe(map((data: any) => data as boolean));
  }

  getTiposArchivo(): Observable<TipoArchivo[]> {
    this.ApiGetTiposArchivoURL = this.ApiDescargasURL+ "/GetTiposArchivo";
    return this.http.get(this.ApiGetTiposArchivoURL
    ).pipe(map((data: any) => data as TipoArchivo[]));
  }

  actualizarTipoArchivo(tipoArchivo: TipoArchivo): Observable<boolean> {
    this.ApiActualizarTipoArchivoURL = this.ApiDescargasURL + "/ActualizarTipoArchivo";
    return this.http.put(this.ApiActualizarTipoArchivoURL, tipoArchivo
    ).pipe(map((data: any) => data as boolean));
  }

  eliminarTipoArchivo(id_tipo_archivo: number): Observable<boolean> {
    this.ApiEliminarTipoArchivoURL = this.ApiDescargasURL
      + "/EliminarTipoArchivo?id_tipo_archivo="+id_tipo_archivo;
    return this.http.delete(this.ApiEliminarTipoArchivoURL
    ).pipe(map((data: any) => data as boolean));
  }

  crearServidor(servidor: Servidor): Observable<boolean> {
    this.ApiCrearServidorURL = this.ApiDescargasURL + "/CrearServidor";
    return this.http.post(this.ApiCrearServidorURL, servidor
    ).pipe(map((data: any) => data as boolean));
  }

  getServidores(): Observable<Servidor[]> {
    this.ApiGetServidoresURL = this.ApiDescargasURL+ "/GetServidores";
    return this.http.get(this.ApiGetServidoresURL
    ).pipe(map((data: any) => data as Servidor[]));
  }

  actualizarServidor(servidor: Servidor): Observable<boolean> {
    this.ApiActualizarServidorURL = this.ApiDescargasURL + "/ActualizarServidor";
    return this.http.put(this.ApiActualizarServidorURL, servidor
    ).pipe(map((data: any) => data as boolean));
  }

  eliminarServidor(id_servidor: number): Observable<boolean> {
    this.ApiEliminarServidorURL = this.ApiDescargasURL
      + "/EliminarServidor?id_servidor="+id_servidor;
    return this.http.delete(this.ApiEliminarServidorURL
    ).pipe(map((data: any) => data as boolean));
  }
}