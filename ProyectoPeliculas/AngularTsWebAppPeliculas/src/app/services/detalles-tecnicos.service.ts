import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Formato } from '../interfaces/detalles/formato';
import { TipoResolucion } from '../interfaces/detalles/resoluciones/tipo-resolucion';
import { ValorResolucion } from '../interfaces/detalles/resoluciones/valor-resolucion';
import { RelacionAspecto } from '../interfaces/detalles/resoluciones/relacion-aspecto';
import { Resolucion } from '../interfaces/detalles/resoluciones/resolucion';
import { DetalleTecnico } from '../interfaces/detalles/detalle-tecnico';

@Injectable()
export class DetallesTecnicosService {
  private ApiDetallesTecnicosURL: string;
  private token: string;
  private header: HttpHeaders;
  private ApiCrearFormatoURL: string;
  private ApiGetFormatosURL: string;
  private ApiActualizarFormatoURL: string;
  private ApiEliminarFormatoURL: string;
  private ApiCrearTipoResolucionURL: string;
  private ApiGetTiposResolucionURL: string;
  private ApiActualizarTipoResolucionURL: string;
  private ApiEliminarTipoResolucionURL: string;
  private ApiCrearValorResolucionURL: string;
  private ApiGetValoresResolucionURL: string;
  private ApiActualizarValorResolucionURL: string;
  private ApiEliminarValorResolucionURL: string;
  private ApiCrearRelacionAspectoURL: string;
  private ApiGetRelacionesAspectoURL: string;
  private ApiActualizarRelacionAspectoURL: string;
  private ApiEliminarRelacionAspectoURL: string;
  private ApiCrearResolucionURL: string;
  private ApiEliminarResolucionURL: string;
  private ApiCrearDetalleTecnicoURL: string;
  private ApiActualizarDetalleTecnicoURL: string;
  private ApiEliminarDetalleTecnicoURL: string;

  constructor(private http: HttpClient) {
    this.ApiDetallesTecnicosURL = localStorage.getItem('apiUrl') + "/DetallesTecnicos";
    this.header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': localStorage.getItem('token')
    });
  }

  crearFormato(formato: Formato): Observable<any[]> {
    this.ApiCrearFormatoURL = this.ApiDetallesTecnicosURL + "/CrearFormato";
    return this.http.post(this.ApiCrearFormatoURL, formato,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getFormatos(): Observable<any[]> {
    this.ApiGetFormatosURL = this.ApiDetallesTecnicosURL + "/GetFormatos";
    return this.http.get(this.ApiGetFormatosURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  actualizarFormato(formato: Formato): Observable<any[]> {
    this.ApiActualizarFormatoURL = this.ApiDetallesTecnicosURL + "/ActualizarFormato";
    return this.http.put(this.ApiActualizarFormatoURL, formato,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  eliminarFormato(id_formato: number): Observable<any[]> {
    this.ApiEliminarFormatoURL = this.ApiDetallesTecnicosURL
      + "/EliminarFormato?id_formato=" + id_formato;
    return this.http.delete(this.ApiEliminarFormatoURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  crearTipoResolucion(tipoResolucion: TipoResolucion): Observable<any[]> {
    this.ApiCrearTipoResolucionURL = this.ApiDetallesTecnicosURL + "/CrearTipoResolucion";
    return this.http.post(this.ApiCrearTipoResolucionURL, tipoResolucion,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getTiposResolucion(): Observable<any[]> {
    this.ApiGetTiposResolucionURL = this.ApiDetallesTecnicosURL + "/GetTiposResolucion";
    return this.http.get(this.ApiGetTiposResolucionURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  actualizarTipoResolucion(tipoResolucion: TipoResolucion): Observable<any[]> {
    this.ApiActualizarTipoResolucionURL = this.ApiDetallesTecnicosURL + "/ActualizarTipoResolucion";
    return this.http.put(this.ApiActualizarTipoResolucionURL, tipoResolucion,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  eliminarTipoResolucion(id_tipo_resolucion: number): Observable<any[]> {
    this.ApiEliminarTipoResolucionURL = this.ApiDetallesTecnicosURL
      + "/EliminarTipoResolucion?id_tipo_resolucion=" + id_tipo_resolucion;
    return this.http.delete(this.ApiEliminarTipoResolucionURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  crearValorResolucion(valorResolucion: ValorResolucion): Observable<any[]> {
    this.ApiCrearValorResolucionURL = this.ApiDetallesTecnicosURL + "/CrearValorResolucion";
    return this.http.post(this.ApiCrearValorResolucionURL, valorResolucion,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getValoresResolucion(): Observable<any[]> {
    this.ApiGetValoresResolucionURL = this.ApiDetallesTecnicosURL + "/GetValoresResolucion";
    return this.http.get(this.ApiGetValoresResolucionURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  actualizarValorResolucion(valorResolucion: ValorResolucion): Observable<any[]> {
    this.ApiActualizarValorResolucionURL = this.ApiDetallesTecnicosURL + "/ActualizarValorResolucion";
    return this.http.put(this.ApiActualizarValorResolucionURL, valorResolucion,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  eliminarValorResolucion(id_valor_resolucion: number): Observable<any[]> {
    this.ApiEliminarValorResolucionURL = this.ApiDetallesTecnicosURL
      + "/EliminarValorResolucion?id_valor_resolucion=" + id_valor_resolucion;
    return this.http.delete(this.ApiEliminarValorResolucionURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  crearRelacionAspecto(relacionAspecto: RelacionAspecto): Observable<any[]> {
    this.ApiCrearRelacionAspectoURL = this.ApiDetallesTecnicosURL + "/CrearRelacionAspecto";
    return this.http.post(this.ApiCrearRelacionAspectoURL, relacionAspecto,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  getRelacionesAspecto(): Observable<any[]> {
    this.ApiGetRelacionesAspectoURL = this.ApiDetallesTecnicosURL + "/GetRelacionesAspecto";
    return this.http.get(this.ApiGetRelacionesAspectoURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  actualizarRelacionAspecto(relacionAspecto: RelacionAspecto): Observable<any[]> {
    this.ApiActualizarRelacionAspectoURL = this.ApiDetallesTecnicosURL + "/ActualizarRelacionAspecto";
    return this.http.put(this.ApiActualizarRelacionAspectoURL, relacionAspecto,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  eliminarRelacionAspecto(id_relacion_aspecto: number): Observable<any[]> {
    this.ApiEliminarRelacionAspectoURL = this.ApiDetallesTecnicosURL
      + "/EliminarRelacionAspecto?id_relacion_aspecto=" + id_relacion_aspecto;
    return this.http.delete(this.ApiEliminarRelacionAspectoURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  crearResolucion(resolucion: Resolucion): Observable<any[]> {
    this.ApiCrearResolucionURL = this.ApiDetallesTecnicosURL + "/CrearResolucion";
    return this.http.post(this.ApiCrearResolucionURL, resolucion,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  eliminarResolucion(id_tipo_resolucion: number, id_valor_resolucion:
    number, id_relacion_aspecto: number): Observable<any[]> {
    this.ApiEliminarResolucionURL = this.ApiDetallesTecnicosURL + "/EliminarResolucion"
      + "?id_tipo_resolucion=" + id_tipo_resolucion + "&id_valor_resolucion="
      + id_valor_resolucion + "&id_relacion_aspecto=" + id_relacion_aspecto;
    return this.http.delete(this.ApiEliminarResolucionURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  crearDetalleTecnico(detalleTecnico: DetalleTecnico): Observable<any[]> {
    this.ApiCrearDetalleTecnicoURL = this.ApiDetallesTecnicosURL + "/CrearDetalleTecnico";
    return this.http.post(this.ApiCrearDetalleTecnicoURL, detalleTecnico,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  actualizarDetalleTecnico(detalleTecnico: DetalleTecnico): Observable<any[]> {
    this.ApiActualizarDetalleTecnicoURL = this.ApiDetallesTecnicosURL + "/ActualizarDetalleTecnico";
    return this.http.put(this.ApiActualizarDetalleTecnicoURL, detalleTecnico,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }

  eliminarDetalleTecnico(id_detalle: number): Observable<any[]> {
    this.ApiEliminarDetalleTecnicoURL = this.ApiDetallesTecnicosURL
      + "/EliminarDetalleTecnico?id_detalle=" + id_detalle;
    return this.http.delete(this.ApiEliminarDetalleTecnicoURL,
      { headers: this.header }).pipe(map((data: any) => data as any[]));
  }
}