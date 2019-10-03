import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { apiURL, header } from '../global.service';
import { TipoArchivo } from '../interfaces/descargas/tipo-archivo';
import { Servidor } from '../interfaces/descargas/servidor';
import { Descarga } from '../interfaces/descargas/descarga';
import { Enlace } from '../interfaces/descargas/enlace';

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
  private ApiCrearDescargaURL: string;
  private ApiActualizarDescargaURL: string;
  private ApiEliminarDescargaURL: string;
  private ApiCrearEnlaceURL: string;
  private ApiGetEnlacesDescargaURL: string;
  private ApiActualizarEnlaceURL: string;
  private ApiEliminarEnlaceURL: string;

  constructor(private http: HttpClient) {
    this.ApiDescargasURL = apiURL + "/Descargas";
  }

  crearTipoArchivo(tipoArchivo: TipoArchivo): Observable<any[]> {
    this.ApiCrearTipoArchivoURL = this.ApiDescargasURL + "/CrearTipoArchivo";
    return this.http.post(this.ApiCrearTipoArchivoURL, tipoArchivo,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  getTiposArchivo(): Observable<any[]> {
    this.ApiGetTiposArchivoURL = this.ApiDescargasURL + "/GetTiposArchivo";
    return this.http.get(this.ApiGetTiposArchivoURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  actualizarTipoArchivo(tipoArchivo: TipoArchivo): Observable<any[]> {
    this.ApiActualizarTipoArchivoURL = this.ApiDescargasURL + "/ActualizarTipoArchivo";
    return this.http.put(this.ApiActualizarTipoArchivoURL, tipoArchivo,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  eliminarTipoArchivo(id_tipo_archivo: number): Observable<any[]> {
    this.ApiEliminarTipoArchivoURL = this.ApiDescargasURL
      + "/EliminarTipoArchivo?id_tipo_archivo=" + id_tipo_archivo;
    return this.http.delete(this.ApiEliminarTipoArchivoURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  crearServidor(servidor: Servidor): Observable<any[]> {
    this.ApiCrearServidorURL = this.ApiDescargasURL + "/CrearServidor";
    return this.http.post(this.ApiCrearServidorURL, servidor,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  getServidores(): Observable<any[]> {
    this.ApiGetServidoresURL = this.ApiDescargasURL + "/GetServidores";
    return this.http.get(this.ApiGetServidoresURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  actualizarServidor(servidor: Servidor): Observable<any[]> {
    this.ApiActualizarServidorURL = this.ApiDescargasURL + "/ActualizarServidor";
    return this.http.put(this.ApiActualizarServidorURL, servidor,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  eliminarServidor(id_servidor: number): Observable<any[]> {
    this.ApiEliminarServidorURL = this.ApiDescargasURL
      + "/EliminarServidor?id_servidor=" + id_servidor;
    return this.http.delete(this.ApiEliminarServidorURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  crearDescarga(descarga: Descarga): Observable<any[]> {
    this.ApiCrearDescargaURL = this.ApiDescargasURL + "/CrearDescarga";
    return this.http.post(this.ApiCrearDescargaURL, descarga,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  actualizarDescarga(descarga: Descarga): Observable<any[]> {
    this.ApiActualizarDescargaURL = this.ApiDescargasURL + "/ActualizarDescarga";
    return this.http.put(this.ApiActualizarDescargaURL, descarga,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  eliminarDescarga(id_descarga: number): Observable<any[]> {
    this.ApiEliminarDescargaURL = this.ApiDescargasURL
      + "/EliminarDescarga?id_descarga=" + id_descarga;
    return this.http.delete(this.ApiEliminarDescargaURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  crearEnlace(enlace: Enlace): Observable<any[]> {
    this.ApiCrearEnlaceURL = this.ApiDescargasURL + "/CrearEnlace";
    return this.http.post(this.ApiCrearEnlaceURL, enlace,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  getEnlacesDescarga(id_descarga: number): Observable<any[]> {
    this.ApiGetEnlacesDescargaURL = this.ApiDescargasURL
      + "/GetEnlacesDescarga?id_descarga=" + id_descarga;
    return this.http.get(this.ApiGetEnlacesDescargaURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  actualizarEnlace(enlace: Enlace): Observable<any[]> {
    this.ApiActualizarEnlaceURL = this.ApiDescargasURL + "/ActualizarEnlace";
    return this.http.put(this.ApiActualizarEnlaceURL, enlace,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }

  eliminarEnlace(id_enlace: number): Observable<any[]> {
    this.ApiEliminarEnlaceURL = this.ApiDescargasURL
      + "/EliminarEnlace?id_enlace=" + id_enlace;
    return this.http.delete(this.ApiEliminarEnlaceURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }
}