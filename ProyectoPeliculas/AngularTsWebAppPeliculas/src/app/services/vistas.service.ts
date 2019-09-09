import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { apiURL, header } from '../global.service';
import { Solicitud } from '../interfaces/solicitud';
import { Token } from '../interfaces/token';

@Injectable()
export class VistasService {
  private ApiVistasURL: string;
  private ApiGetVistaSolicitudesURL: string;
  private ApiGetVistaTokensURL: string;

  constructor(private http: HttpClient) {
    this.ApiVistasURL = apiURL+"/Vistas";
  }

  getSolicitudesVista(): Observable<Solicitud[]> {
    this.ApiGetVistaSolicitudesURL = this.ApiVistasURL + "/GetVistaSolicitudes";
    return this.http.get(this.ApiGetVistaSolicitudesURL).
      pipe(map((data: any) => data as Solicitud[]));
    //this.ApiGetVistaSolicitudesURL = this.ApiVistasURL + "/GetVistaSolicitudes";
    //return this.http.get(this.ApiGetVistaSolicitudesURL,
    //{ headers: header }).pipe(map((data: any) => data as Solicitud[]));
  }

  getTokensVista(): Observable<Token[]> {
    this.ApiGetVistaTokensURL = this.ApiVistasURL + "/GetVistaTokens";
    return this.http.get(this.ApiGetVistaTokensURL).
      pipe(map((data: any) => data as Token[]));
    //this.ApiGetVistaTokensURL = this.ApiVistasURL + "/GetVistaTokens";
    //return this.http.get(this.ApiGetVistaTokensURL,
    //{ headers: header }).pipe(map((data: any) => data as Token[]));
  }
}