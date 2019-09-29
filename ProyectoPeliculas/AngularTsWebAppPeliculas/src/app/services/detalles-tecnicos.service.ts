import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { apiURL, header } from '../global.service';
import { Formato } from '../interfaces/detalles/formato';
import { TipoResolucion } from '../interfaces/detalles/resoluciones/tipo-resolucion';
import { ValorResolucion } from '../interfaces/detalles/resoluciones/valor-resolucion';
import { RelacionAspecto } from '../interfaces/detalles/resoluciones/relacion-aspecto';
import { Resolucion } from '../interfaces/detalles/resoluciones/resolucion';
import { DetalleTecnico } from '../interfaces/detalles/detalle-tecnico';

@Injectable()
export class DetallesTecnicosService {
  private ApiDetallesTecnicosURL: string;
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
    this.ApiDetallesTecnicosURL = apiURL + "/DetallesTecnicos";
  }

  crearFormato(formato: Formato): Observable<boolean> {
    this.ApiCrearFormatoURL = this.ApiDetallesTecnicosURL + "/CrearFormato";
    return this.http.post(this.ApiCrearFormatoURL, formato,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  getFormatos(): Observable<Formato[]> {
    this.ApiGetFormatosURL = this.ApiDetallesTecnicosURL + "/GetFormatos";
    return this.http.get(this.ApiGetFormatosURL,
      { headers: header }).pipe(map((data: any) => data as Formato[]));
  }

  actualizarFormato(formato: Formato): Observable<boolean> {
    this.ApiActualizarFormatoURL = this.ApiDetallesTecnicosURL + "/ActualizarFormato";
    return this.http.put(this.ApiActualizarFormatoURL, formato,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarFormato(id_formato: number): Observable<boolean> {
    this.ApiEliminarFormatoURL = this.ApiDetallesTecnicosURL
      + "/EliminarFormato?id_formato=" + id_formato;
    return this.http.delete(this.ApiEliminarFormatoURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearTipoResolucion(tipoResolucion: TipoResolucion): Observable<boolean> {
    this.ApiCrearTipoResolucionURL = this.ApiDetallesTecnicosURL + "/CrearTipoResolucion";
    return this.http.post(this.ApiCrearTipoResolucionURL, tipoResolucion,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  getTiposResolucion(): Observable<TipoResolucion[]> {
    this.ApiGetTiposResolucionURL = this.ApiDetallesTecnicosURL + "/GetTiposResolucion";
    return this.http.get(this.ApiGetTiposResolucionURL,
      { headers: header }).pipe(map((data: any) => data as TipoResolucion[]));
  }

  actualizarTipoResolucion(tipoResolucion: TipoResolucion): Observable<boolean> {
    this.ApiActualizarTipoResolucionURL = this.ApiDetallesTecnicosURL + "/ActualizarTipoResolucion";
    return this.http.put(this.ApiActualizarTipoResolucionURL, tipoResolucion,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarTipoResolucion(id_tipo_resolucion: number): Observable<boolean> {
    this.ApiEliminarTipoResolucionURL = this.ApiDetallesTecnicosURL
      + "/EliminarTipoResolucion?id_tipo_resolucion=" + id_tipo_resolucion;
    return this.http.delete(this.ApiEliminarTipoResolucionURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearValorResolucion(valorResolucion: ValorResolucion): Observable<boolean> {
    this.ApiCrearValorResolucionURL = this.ApiDetallesTecnicosURL + "/CrearValorResolucion";
    return this.http.post(this.ApiCrearValorResolucionURL, valorResolucion,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  getValoresResolucion(): Observable<ValorResolucion[]> {
    this.ApiGetValoresResolucionURL = this.ApiDetallesTecnicosURL + "/GetValoresResolucion";
    return this.http.get(this.ApiGetValoresResolucionURL,
      { headers: header }).pipe(map((data: any) => data as ValorResolucion[]));
  }

  actualizarValorResolucion(valorResolucion: ValorResolucion): Observable<boolean> {
    this.ApiActualizarValorResolucionURL = this.ApiDetallesTecnicosURL + "/ActualizarValorResolucion";
    return this.http.put(this.ApiActualizarValorResolucionURL, valorResolucion,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarValorResolucion(id_valor_resolucion: number): Observable<boolean> {
    this.ApiEliminarValorResolucionURL = this.ApiDetallesTecnicosURL
      + "/EliminarValorResolucion?id_valor_resolucion=" + id_valor_resolucion;
    return this.http.delete(this.ApiEliminarValorResolucionURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearRelacionAspecto(relacionAspecto: RelacionAspecto): Observable<boolean> {
    this.ApiCrearRelacionAspectoURL = this.ApiDetallesTecnicosURL + "/CrearRelacionAspecto";
    return this.http.post(this.ApiCrearRelacionAspectoURL, relacionAspecto,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  getRelacionesAspecto(): Observable<RelacionAspecto[]> {
    this.ApiGetRelacionesAspectoURL = this.ApiDetallesTecnicosURL + "/GetRelacionesAspecto";
    return this.http.get(this.ApiGetRelacionesAspectoURL,
      { headers: header }).pipe(map((data: any) => data as RelacionAspecto[]));
  }

  actualizarRelacionAspecto(relacionAspecto: RelacionAspecto): Observable<boolean> {
    this.ApiActualizarRelacionAspectoURL = this.ApiDetallesTecnicosURL + "/ActualizarRelacionAspecto";
    return this.http.put(this.ApiActualizarRelacionAspectoURL, relacionAspecto,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarRelacionAspecto(id_relacion_aspecto: number): Observable<boolean> {
    this.ApiEliminarRelacionAspectoURL = this.ApiDetallesTecnicosURL
      + "/EliminarRelacionAspecto?id_relacion_aspecto=" + id_relacion_aspecto;
    return this.http.delete(this.ApiEliminarRelacionAspectoURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearResolucion(resolucion: Resolucion): Observable<boolean> {
    this.ApiCrearResolucionURL = this.ApiDetallesTecnicosURL + "/CrearResolucion";
    return this.http.post(this.ApiCrearResolucionURL, resolucion,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarResolucion(id_tipo_resolucion: number, id_valor_resolucion:
    number, id_relacion_aspecto: number): Observable<boolean> {
    this.ApiEliminarResolucionURL = this.ApiDetallesTecnicosURL + "/EliminarResolucion"
      + "?id_tipo_resolucion=" + id_tipo_resolucion + "&id_valor_resolucion="
      + id_valor_resolucion + "&id_relacion_aspecto=" + id_relacion_aspecto;
    return this.http.delete(this.ApiEliminarResolucionURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  crearDetalleTecnico(detalleTecnico: DetalleTecnico): Observable<boolean> {
    this.ApiCrearDetalleTecnicoURL = this.ApiDetallesTecnicosURL + "/CrearDetalleTecnico";
    return this.http.post(this.ApiCrearDetalleTecnicoURL, detalleTecnico,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  actualizarDetalleTecnico(detalleTecnico: DetalleTecnico): Observable<boolean> {
    this.ApiActualizarDetalleTecnicoURL = this.ApiDetallesTecnicosURL + "/ActualizarDetalleTecnico";
    return this.http.put(this.ApiActualizarDetalleTecnicoURL, detalleTecnico,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }

  eliminarDetalleTecnico(id_detalle: number): Observable<boolean> {
    this.ApiEliminarDetalleTecnicoURL = this.ApiDetallesTecnicosURL
      + "/EliminarDetalleTecnico?id_detalle=" + id_detalle;
    return this.http.delete(this.ApiEliminarDetalleTecnicoURL,
      { headers: header }).pipe(map((data: any) => data as boolean));
  }
}