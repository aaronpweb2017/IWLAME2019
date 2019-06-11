import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Proyecto } from '../interfaces/proyecto';

@Injectable()
export class ProyectosService {
    ApiProyectosUrl: string;
    ApiGetNoProyectosUrl: string;
    ApiGetProyectosUrl: string;
    GetProyectosPaginacionUrl: string;    
    ApiGetProyectoUrl: string;
    ApiPostProyectoUrl: string;
    ApiUpdateProyectoUrl: string;
    ApiDeleteProyectoUrl: string;

    constructor(private http: HttpClient) {
        this.ApiProyectosUrl = "https://localhost:5001/Api/Proyectos"; 
    }

    GetNoProyectos(): Observable<any> {
        this.ApiGetNoProyectosUrl = this.ApiProyectosUrl+"/GetNoProyectos"
        return this.http.get(this.ApiGetNoProyectosUrl);
    }

    GetProyectos(): Observable<any> {
        this.ApiGetProyectosUrl = this.ApiProyectosUrl+"/GetProyectos"
        return this.http.get(this.ApiGetProyectosUrl);
    }

    GetProyectosPaginacion(no_pagina: number): Observable<any> {
        this.GetProyectosPaginacionUrl =  this.ApiProyectosUrl+"/GetProyectosPaginacion/?no_pagina="+no_pagina;
        return this.http.get(this.GetProyectosPaginacionUrl)
    }    

    GetProyecto(id_proyecto: number): Observable<any> {
        this.ApiGetProyectoUrl = this.ApiProyectosUrl
        +"/GetProyecto/?id_proyecto="+id_proyecto;
        return this.http.get(this.ApiGetProyectoUrl);
    }

    PostProyecto(proyecto: Proyecto): Observable<any> {
        this.ApiPostProyectoUrl = this.ApiProyectosUrl + "/CrearProyecto";
        return this.http.post(this.ApiPostProyectoUrl, proyecto);
    }

    UpdateProyecto(id_proyecto: number, proyecto: Proyecto): Observable<any> {
        this.ApiUpdateProyectoUrl = this.ApiProyectosUrl
        + "/ActualizarProyecto/?id_proyecto="+id_proyecto;
        return this.http.put(this.ApiUpdateProyectoUrl, proyecto);
    }

    DeleteProyecto(id_proyecto: number): Observable<any> {
        this.ApiDeleteProyectoUrl = this.ApiProyectosUrl
        + "/BorrarProyecto/?id_proyecto="+id_proyecto;
        return this.http.delete(this.ApiDeleteProyectoUrl);
    }
}