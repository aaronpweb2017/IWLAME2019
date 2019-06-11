import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Empleado } from '../interfaces/empleado';

@Injectable()
export class EmpleadosService {
    ApiEmpleadosUrl: string;
    ApiGetNoEmpleadosUrl: string;
    ApiGetEmpleadosUrl: string;
    GetEmpleadosPaginacionUrl: string;
    ApiGetEmpleadoUrl: string;
    ApiPostEmpleadoUrl: string;
    ApiUpdateEmpleadoUrl: string;
    ApiDeleteEmpleadoUrl: string;

    constructor(private http: HttpClient) {
        this.ApiEmpleadosUrl = "https://localhost:5001/Api/Empleados";
    }

    GetNoEmpleados(): Observable<any> {
        this.ApiGetNoEmpleadosUrl = this.ApiEmpleadosUrl+"/GetNoEmpleados"
        return this.http.get(this.ApiGetNoEmpleadosUrl);
    }

    GetEmpleados(): Observable<any> {
        this.ApiGetEmpleadosUrl = this.ApiEmpleadosUrl+"/GetEmpleados"
        return this.http.get(this.ApiGetEmpleadosUrl);
    }

    GetEmpleadosPaginacion(no_pagina: number): Observable<any> {
      this.GetEmpleadosPaginacionUrl =  this.ApiEmpleadosUrl+"/GetEmpleadosPaginacion/?no_pagina="+no_pagina;
      return this.http.get(this.GetEmpleadosPaginacionUrl)
    }

    GetEmpleado(id_empleado: number): Observable<any> {
        this.ApiGetEmpleadoUrl = this.ApiEmpleadosUrl
        +"/GetEmpleado/?id_empleado="+id_empleado;
        return this.http.get(this.ApiGetEmpleadoUrl);
    }

    PostEmpleado(empleado: Empleado): Observable<any> {
        this.ApiPostEmpleadoUrl = this.ApiEmpleadosUrl + "/CrearEmpleado";
        return this.http.post(this.ApiPostEmpleadoUrl, empleado);
    }

    UpdateEmpleado(id_empleado: number, empleado: Empleado): Observable<any> {
        this.ApiUpdateEmpleadoUrl = this.ApiEmpleadosUrl
        + "/ActualizarEmpleado/?id_empleado="+id_empleado;
        return this.http.put(this.ApiUpdateEmpleadoUrl, empleado);
    }

    DeleteEmpleado(id_empleado: number): Observable<any> {
        this.ApiDeleteEmpleadoUrl = this.ApiEmpleadosUrl
        + "/BorrarEmpleado/?id_empleado="+id_empleado;
        return this.http.delete(this.ApiDeleteEmpleadoUrl);
    }
}