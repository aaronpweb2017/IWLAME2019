import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Asignacion } from '../interfaces/asignacion';
import { header } from 'src/app/token-service';

@Injectable()
export class AsignacionesService {
    ApiAsignacionesURL: string;
    ApiGetNoAsignacionesURL: string;
    ApiGetAsignacionesURL: string;
    ApiGetAsignacionesPaginacionURL: string;
    ApiGetProyectosPaginacionURL: string;
    ApiGetEmpleadosPaginacionURL: string;
    ApiGetAsignacionURL: string;
    ApiPostAsignacionURL: string;
    ApiUpdateAsignacionURL: string;
    ApiDeleteAsignacionURL: string;

    constructor(private http: HttpClient) {
        this.ApiAsignacionesURL = "https://localhost:5001/Api/Asignaciones";
    }

    GetNoAsignaciones(): Observable<any> {
        this.ApiGetNoAsignacionesURL = this.ApiAsignacionesURL + "/GetNoAsignaciones";
        return this.http.get(this.ApiGetNoAsignacionesURL, {headers: header});
    }

    GetAsignaciones(): Observable<any> {
        this.ApiGetAsignacionesURL = this.ApiAsignacionesURL + "/GetAsignaciones";
        return this.http.get(this.ApiGetAsignacionesURL, {headers: header});
    }

    GetAsignacionesPaginacion(no_pagina: number): Observable<any> {
        this.ApiGetAsignacionesPaginacionURL = this.ApiAsignacionesURL
            + "/GetAsignacionesPaginacion/?no_pagina=" + no_pagina;
        return this.http.get(this.ApiGetAsignacionesPaginacionURL, {headers: header});
    }

    GetProyectosPaginacion(no_pagina: number): Observable<any> {
        this.ApiGetProyectosPaginacionURL = this.ApiAsignacionesURL
        + "/GetProyectosPaginacion/?no_pagina=" + no_pagina;
        return this.http.get(this.ApiGetProyectosPaginacionURL, {headers: header});
    }

    GetEmpleadosPaginacion(no_pagina: number): Observable<any> {
        this.ApiGetEmpleadosPaginacionURL = this.ApiAsignacionesURL
        + "/GetEmpleadosPaginacion/?no_pagina=" + no_pagina;
        return this.http.get(this.ApiGetEmpleadosPaginacionURL, {headers: header});
    }

    GetAsignacion(id_asignacion: number): Observable<any> {
        this.ApiGetAsignacionURL = this.ApiAsignacionesURL
            + "/GetAsignacion/?id_asignacion=" + id_asignacion;
        return this.http.get(this.ApiGetAsignacionURL, {headers: header});
    }

    PostAsignacion(asignacion: Asignacion): Observable<any> {
        this.ApiPostAsignacionURL = this.ApiAsignacionesURL + "/CrearAsignacion";
        return this.http.post(this.ApiPostAsignacionURL, asignacion, {headers: header});
    }

    UpdateAsignacion(id_asignacion: number, asignacion: Asignacion): Observable<any> {
        this.ApiUpdateAsignacionURL = this.ApiAsignacionesURL
            + "/ActualizarAsignacion/?id_asignacion=" + id_asignacion;
        return this.http.put(this.ApiUpdateAsignacionURL, asignacion, {headers: header});
    }

    DeleteAsignacion(id_asignacion: number): Observable<any> {
        this.ApiDeleteAsignacionURL = this.ApiAsignacionesURL
            + "/BorrarAsignacion/?id_asignacion=" + id_asignacion;
        return this.http.delete(this.ApiDeleteAsignacionURL, {headers: header});
    }
}