import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Proyecto } from '../interfaces/proyecto';
import { header } from 'src/app/token-service';

@Injectable()
export class ProyectosService {
    ApiProyectosURL: string;
    ApiGetNoProyectosURL: string;
    ApiGetProyectosURL: string;
    ApiGetProyectosActivosURL: string;
    ApiGetProyectosPaginacionURL: string;    
    ApiGetProyectoURL: string;
    ApiGetProyectoAsignadoURL: string;
    ApiPostProyectoURL: string;
    ApiUpdateProyectoURL: string;
    ApiDeleteProyectoURL: string;

    constructor(private http: HttpClient) {
        this.ApiProyectosURL = "https://localhost:5001/Api/Proyectos"; 
    }

    GetNoProyectos(): Observable<any> {
        this.ApiGetNoProyectosURL = this.ApiProyectosURL+"/GetNoProyectos";
        return this.http.get(this.ApiGetNoProyectosURL, {headers: header});
    }

    GetProyectos(): Observable<any> {
        this.ApiGetProyectosURL = this.ApiProyectosURL+"/GetProyectos";
        return this.http.get(this.ApiGetProyectosURL, {headers: header});
    }
 
    GetProyectosActivos(): Observable<any> {
        this.ApiGetProyectosActivosURL = this.ApiProyectosURL+"/GetProyectosActivos";
        return this.http.get(this.ApiGetProyectosActivosURL, {headers: header});
    }

    GetProyectosPaginacion(no_pagina: number): Observable<any> {
        this.ApiGetProyectosPaginacionURL =  this.ApiProyectosURL
            +"/GetProyectosPaginacion/?no_pagina="+no_pagina;
        return this.http.get(this.ApiGetProyectosPaginacionURL, {headers: header});
    }    

    GetProyecto(id_proyecto: number): Observable<any> {
        this.ApiGetProyectoURL = this.ApiProyectosURL
        +"/GetProyecto/?id_proyecto="+id_proyecto;
        return this.http.get(this.ApiGetProyectoURL, {headers: header});
    }

    GetProyectoAsignado(id_proyecto: number): Observable<any> {
        this.ApiGetProyectoAsignadoURL = this.ApiProyectosURL
        +"/GetProyectoAsignado/?id_proyecto="+id_proyecto;
        return this.http.get(this.ApiGetProyectoAsignadoURL, {headers: header});
    }

    PostProyecto(proyecto: Proyecto): Observable<any> {
        this.ApiPostProyectoURL = this.ApiProyectosURL + "/CrearProyecto";
        return this.http.post(this.ApiPostProyectoURL, proyecto, {headers: header});
    }

    UpdateProyecto(id_proyecto: number, proyecto: Proyecto): Observable<any> {
        this.ApiUpdateProyectoURL = this.ApiProyectosURL
        + "/ActualizarProyecto/?id_proyecto="+id_proyecto;
        return this.http.put(this.ApiUpdateProyectoURL, proyecto, {headers: header});
    }

    DeleteProyecto(id_proyecto: number): Observable<any> {
        this.ApiDeleteProyectoURL = this.ApiProyectosURL
        + "/BorrarProyecto/?id_proyecto="+id_proyecto;
        return this.http.delete(this.ApiDeleteProyectoURL, {headers: header});
    }
}