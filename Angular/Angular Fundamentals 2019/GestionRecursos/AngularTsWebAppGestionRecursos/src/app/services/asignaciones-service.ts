import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Asignacion } from '../interfaces/asignacion';

@Injectable()
export class AsignacionesService {
    ApiAsignacionesURL: string;
    ApiGetNoAsignacionesURL: string;
    ApiGetAsignacionesURL: string;
    GetAsignacionesPaginacionURL: string;
    ApiGetAsignacionURL: string;
    ApiPostAsignacionURL: string;
    ApiUpdateAsignacionURL: string;
    ApiDeleteAsignacionURL: string;
    asignacion: Asignacion;

    constructor(private http: HttpClient) {
        this.ApiAsignacionesURL = "https://localhost:5001/Api/Asignaciones";
        this.asignacion = { id_asignacion: 0, id_proyecto: 0,
            id_empleado: 0, fecha_asignado: new Date(), 
            fecha_desasignado: new Date()
        };
    }

    GetNoAsignaciones(): Observable<any> {
        this.ApiGetNoAsignacionesURL = this.ApiAsignacionesURL+"/GetNoAsignaciones";
        return this.http.get(this.ApiGetNoAsignacionesURL);
    }

    GetAsignaciones(): Observable<any> {
        this.ApiGetAsignacionesURL = this.ApiAsignacionesURL+"/GetAsignaciones";
        return this.http.get(this.ApiGetAsignacionesURL);
    }

    GetAsignacionesPaginacion(no_pagina: number): Observable<any> {
      this.GetAsignacionesPaginacionURL =  this.ApiAsignacionesURL
        +"/GetAsignacionesPaginacion/?no_pagina="+no_pagina;
      return this.http.get(this.GetAsignacionesPaginacionURL)
    }

    GetAsignacion(id_asignacion: number): Observable<any> {
        this.ApiGetAsignacionURL = this.ApiAsignacionesURL
        +"/GetAsignacion/?id_asignacion="+id_asignacion;
        return this.http.get(this.ApiGetAsignacionURL);
    }

    PostAsignacion(asignacion: Asignacion): Observable<any> {
        this.ApiPostAsignacionURL = this.ApiAsignacionesURL + "/CrearAsignacion";
        return this.http.post(this.ApiPostAsignacionURL, asignacion);
    }

    UpdateAsignacion(id_asignacion: number, asignacion: Asignacion): Observable<any> {
        this.ApiUpdateAsignacionURL = this.ApiAsignacionesURL
        + "/ActualizarAsignacion/?id_asignacion="+id_asignacion;
        return this.http.put(this.ApiUpdateAsignacionURL, asignacion);
    }

    DeleteAsignacion(id_asignacion: number): Observable<any> {
        this.ApiDeleteAsignacionURL = this.ApiAsignacionesURL
        + "/BorrarAsignacion/?id_asignacion="+id_asignacion;
        return this.http.delete(this.ApiDeleteAsignacionURL);
    }
}