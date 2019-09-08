import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class VistasService {
  private ApiVistasURL: string;
  private ApiGetVistaSolicitudesURL: string;
  private ApiGetVistaTokensURL: string;

  constructor(private http: HttpClient) {
    this.ApiVistasURL = "https://localhost:5001/Api/Vistas";
  }

  getSolicitudesVista(): Observable<any> {
    this.ApiGetVistaSolicitudesURL = this.ApiVistasURL + "/GetVistaSolicitudes";
    return this.http.get(this.ApiGetVistaSolicitudesURL);
  }

  getTokensVista(): Observable<any> {
    this.ApiGetVistaTokensURL = this.ApiVistasURL + "/GetVistaTokens";
    return this.http.get(this.ApiGetVistaTokensURL);
  }
}