import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { apiURL } from '../global.service';
import { TipoArchivo } from '../interfaces/descargas/tipo-archivo';

@Injectable()
export class DescargasService {
  private ApiDescargasURL: string;
  private ApiCrearTipoArchivoURL: string;
  private ApiGetTiposArchivoURL: string;
  private ApiActualizarTipoArchivoURL: string;
  private ApiEliminarTipoArchivoURL: string;

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
}