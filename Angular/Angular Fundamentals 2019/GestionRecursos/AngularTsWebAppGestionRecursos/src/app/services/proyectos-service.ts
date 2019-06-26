import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Proyecto } from '../interfaces/proyecto';

@Injectable()
export class ProyectosService {
    ApiProyectosURL: string;
    ApiGetNoProyectosURL: string;
    ApiGetProyectosURL: string;
    GetProyectosPaginacionURL: string;    
    ApiGetProyectoURL: string;
    ApiPostProyectoURL: string;
    ApiUpdateProyectoURL: string;
    ApiDeleteProyectoURL: string;

    constructor(private http: HttpClient) {
        this.ApiProyectosURL = "https://localhost:5001/Api/Proyectos"; 
    }

    GetNoProyectos(): Observable<any> {
        this.ApiGetNoProyectosURL = this.ApiProyectosURL+"/GetNoProyectos";
        return this.http.get(this.ApiGetNoProyectosURL);
    }

    GetProyectos(): Observable<any> {
        this.ApiGetProyectosURL = this.ApiProyectosURL+"/GetProyectos";
        return this.http.get(this.ApiGetProyectosURL);
    }

    GetProyectosPaginacion(no_pagina: number): Observable<any> {
        this.GetProyectosPaginacionURL =  this.ApiProyectosURL
            +"/GetProyectosPaginacion/?no_pagina="+no_pagina;
        return this.http.get(this.GetProyectosPaginacionURL)
    }    

    GetProyecto(id_proyecto: number): Observable<any> {
        this.ApiGetProyectoURL = this.ApiProyectosURL
        +"/GetProyecto/?id_proyecto="+id_proyecto;
        return this.http.get(this.ApiGetProyectoURL);
    }

    PostProyecto(proyecto: Proyecto): Observable<any> {
        this.ApiPostProyectoURL = this.ApiProyectosURL + "/CrearProyecto";
        return this.http.post(this.ApiPostProyectoURL, proyecto);
    }

    UpdateProyecto(id_proyecto: number, proyecto: Proyecto): Observable<any> {
        this.ApiUpdateProyectoURL = this.ApiProyectosURL
        + "/ActualizarProyecto/?id_proyecto="+id_proyecto;
        return this.http.put(this.ApiUpdateProyectoURL, proyecto);
    }

    DeleteProyecto(id_proyecto: number): Observable<any> {
        this.ApiDeleteProyectoURL = this.ApiProyectosURL
        + "/BorrarProyecto/?id_proyecto="+id_proyecto;
        return this.http.delete(this.ApiDeleteProyectoURL);
    }
}