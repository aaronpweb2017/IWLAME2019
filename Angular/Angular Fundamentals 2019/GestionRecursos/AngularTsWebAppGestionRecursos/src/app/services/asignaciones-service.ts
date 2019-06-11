import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Asignacion } from '../interfaces/asignacion';

@Injectable()
export class AsignacionesService {
    ApiAsignacionesUrl: string;
    ApiGetNoAsignacionesUrl: string;
    ApiGetAsignacionesUrl: string;
    GetAsignacionesPaginacionUrl: string;
    ApiGetAsignacionUrl: string;
    ApiPostAsignacionUrl: string;
    ApiUpdateAsignacionUrl: string;
    ApiDeleteAsignacionUrl: string;
    asignacion: Asignacion;

    constructor(private http: HttpClient) {
        this.ApiAsignacionesUrl = "https://localhost:5001/Api/Asignaciones";
        this.asignacion = { id_asignacion: 0, id_proyecto: 0,
            id_empleado: 0, fecha_asignado: new Date(), 
            fecha_desasignado: new Date()
        };
    }

    GetNoAsignaciones(): Observable<any> {
        this.ApiGetNoAsignacionesUrl = this.ApiAsignacionesUrl+"/GetNoAsignaciones"
        return this.http.get(this.ApiGetNoAsignacionesUrl);
    }

    GetAsignaciones(): Observable<any> {
        this.ApiGetAsignacionesUrl = this.ApiAsignacionesUrl+"/GetAsignaciones"
        return this.http.get(this.ApiGetAsignacionesUrl);
    }

    GetAsignacionesPaginacion(no_pagina: number): Observable<any> {
      this.GetAsignacionesPaginacionUrl =  this.ApiAsignacionesUrl+"/GetAsignacionesPaginacion/?no_pagina="+no_pagina;
      return this.http.get(this.GetAsignacionesPaginacionUrl)
    }

    GetAsignacion(id_asignacion: number): Observable<any> {
        this.ApiGetAsignacionUrl = this.ApiAsignacionesUrl
        +"/GetAsignacion/?id_asignacion="+id_asignacion;
        return this.http.get(this.ApiGetAsignacionUrl);
    }

    PostAsignacion(asignacion: Asignacion): Observable<any> {
        this.ApiPostAsignacionUrl = this.ApiAsignacionesUrl + "/CrearAsignacion";
        return this.http.post(this.ApiPostAsignacionUrl, asignacion);
    }

    UpdateAsignacion(id_asignacion: number, asignacion: Asignacion): Observable<any> {
        this.ApiUpdateAsignacionUrl = this.ApiAsignacionesUrl
        + "/ActualizarAsignacion/?id_asignacion="+id_asignacion;
        return this.http.put(this.ApiUpdateAsignacionUrl, asignacion);
    }

    DeleteAsignacion(id_asignacion: number): Observable<any> {
        this.ApiDeleteAsignacionUrl = this.ApiAsignacionesUrl
        + "/BorrarAsignacion/?id_asignacion="+id_asignacion;
        return this.http.delete(this.ApiDeleteAsignacionUrl);
    }
}