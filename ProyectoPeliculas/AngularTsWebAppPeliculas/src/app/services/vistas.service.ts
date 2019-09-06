import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class VistasService {
  private ApiVistasURL: string;
  private ApiGetSolicitudesVistaURL: string;
  private ApiGetTokensVistaURL: string;

  constructor(private http: HttpClient) {
    this.ApiVistasURL = "https://localhost:5001/Api/Vistas";
  }

  getSolicitudesVista(): Observable<any> {
    this.ApiGetSolicitudesVistaURL = this.ApiVistasURL + "/GetSolicitudesVista";
    return this.http.get(this.ApiGetSolicitudesVistaURL);
  }

  getTokensVista(): Observable<any> {
    this.ApiGetTokensVistaURL = this.ApiVistasURL + "/GetTokensVista";
    return this.http.get(this.ApiGetTokensVistaURL);
  }
}