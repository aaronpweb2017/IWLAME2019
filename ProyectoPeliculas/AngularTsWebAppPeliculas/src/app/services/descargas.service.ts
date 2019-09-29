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

  crearTipoArchivo(tipoArchivo: TipoArchivo): Observable<boolean> {
    this.ApiCrearTipoArchivoURL = this.ApiDescargasURL + "/CrearTipoArchivo";
    return this.http.post(this.ApiCrearTipoArchivoURL, tipoArchivo,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  getTiposArchivo(): Observable<TipoArchivo[]> {
    this.ApiGetTiposArchivoURL = this.ApiDescargasURL + "/GetTiposArchivo";
    return this.http.get(this.ApiGetTiposArchivoURL,
      { headers: header }).pipe(map((data: any) => data as TipoArchivo[]));
  }

  actualizarTipoArchivo(tipoArchivo: TipoArchivo): Observable<boolean> {
    this.ApiActualizarTipoArchivoURL = this.ApiDescargasURL + "/ActualizarTipoArchivo";
    return this.http.put(this.ApiActualizarTipoArchivoURL, tipoArchivo,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarTipoArchivo(id_tipo_archivo: number): Observable<boolean> {
    this.ApiEliminarTipoArchivoURL = this.ApiDescargasURL
      + "/EliminarTipoArchivo?id_tipo_archivo=" + id_tipo_archivo;
    return this.http.delete(this.ApiEliminarTipoArchivoURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearServidor(servidor: Servidor): Observable<boolean> {
    this.ApiCrearServidorURL = this.ApiDescargasURL + "/CrearServidor";
    return this.http.post(this.ApiCrearServidorURL, servidor,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  getServidores(): Observable<Servidor[]> {
    this.ApiGetServidoresURL = this.ApiDescargasURL + "/GetServidores";
    return this.http.get(this.ApiGetServidoresURL,
      { headers: header }).pipe(map((data: any) => data as Servidor[]));
  }

  actualizarServidor(servidor: Servidor): Observable<boolean> {
    this.ApiActualizarServidorURL = this.ApiDescargasURL + "/ActualizarServidor";
    return this.http.put(this.ApiActualizarServidorURL, servidor,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarServidor(id_servidor: number): Observable<boolean> {
    this.ApiEliminarServidorURL = this.ApiDescargasURL
      + "/EliminarServidor?id_servidor=" + id_servidor;
    return this.http.delete(this.ApiEliminarServidorURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearDescarga(descarga: Descarga): Observable<boolean> {
    this.ApiCrearDescargaURL = this.ApiDescargasURL + "/CrearDescarga";
    return this.http.post(this.ApiCrearDescargaURL, descarga,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  actualizarDescarga(descarga: Descarga): Observable<boolean> {
    this.ApiActualizarDescargaURL = this.ApiDescargasURL + "/ActualizarDescarga";
    return this.http.put(this.ApiActualizarDescargaURL, descarga,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarDescarga(id_descarga: number): Observable<boolean> {
    this.ApiEliminarDescargaURL = this.ApiDescargasURL
      + "/EliminarDescarga?id_descarga=" + id_descarga;
    return this.http.delete(this.ApiEliminarDescargaURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearEnlace(enlace: Enlace): Observable<boolean> {
    this.ApiCrearEnlaceURL = this.ApiDescargasURL + "/CrearEnlace";
    return this.http.post(this.ApiCrearEnlaceURL, enlace,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  getEnlacesDescarga(id_descarga: number): Observable<Enlace[]> {
    this.ApiGetEnlacesDescargaURL = this.ApiDescargasURL
      + "/GetEnlacesDescarga?id_descarga=" + id_descarga;
    return this.http.get(this.ApiGetEnlacesDescargaURL,
      { headers: header }).pipe(map((data: any) => data as Enlace[]));
  }

  actualizarEnlace(enlace: Enlace): Observable<boolean> {
    this.ApiActualizarEnlaceURL = this.ApiDescargasURL + "/ActualizarEnlace";
    return this.http.put(this.ApiActualizarEnlaceURL, enlace,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarEnlace(id_enlace: number): Observable<any[]> {
    this.ApiEliminarEnlaceURL = this.ApiDescargasURL
      + "/EliminarEnlace?id_enlace=" + id_enlace;
    return this.http.delete(this.ApiEliminarEnlaceURL,
      { headers: header }).pipe(map((data: any) => data as any[]));
  }
}