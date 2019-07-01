import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Empleado } from '../interfaces/empleado';

@Injectable()
export class EmpleadosService {
    ApiEmpleadosURL: string;
    ApiGetNoEmpleadosURL: string;
    ApiGetEmpleadosURL: string;
    ApiGetEmpleadosActivosURL: string;
    ApiGetAsignadosPaginacionURL: string;
    GetEmpleadosPaginacionURL: string;
    ApiGetEmpleadoURL: string;
    ApiEmpleadoTrabajandoURL: string;
    ApiPostEmpleadoURL: string;
    ApiUpdateEmpleadoURL: string;
    ApiDeleteEmpleadoURL: string;

    constructor(private http: HttpClient) {
        this.ApiEmpleadosURL = "https://localhost:5001/Api/Empleados";
    }

    GetNoEmpleados(): Observable<any> {
        this.ApiGetNoEmpleadosURL = this.ApiEmpleadosURL+"/GetNoEmpleados";
        return this.http.get(this.ApiGetNoEmpleadosURL);
    }

    GetEmpleados(): Observable<any> {
        this.ApiGetEmpleadosURL = this.ApiEmpleadosURL+"/GetEmpleados";
        return this.http.get(this.ApiGetEmpleadosURL);
    }

    GetEmpleadosActivos(): Observable<any> {
        this.ApiGetEmpleadosActivosURL = this.ApiEmpleadosURL+"/GetEmpleadosActivos";
        return this.http.get(this.ApiGetEmpleadosActivosURL);
    }

    GetAsignadosPaginacion(no_pagina: number): Observable<any> {
        this.ApiGetAsignadosPaginacionURL = this.ApiEmpleadosURL
            +"/GetAsignadosPaginacion/?no_pagina="+no_pagina;
        return this.http.get(this.ApiGetAsignadosPaginacionURL);
    }

    GetEmpleadosPaginacion(no_pagina: number): Observable<any> {
      this.GetEmpleadosPaginacionURL =  this.ApiEmpleadosURL
        +"/GetEmpleadosPaginacion/?no_pagina="+no_pagina;
      return this.http.get(this.GetEmpleadosPaginacionURL)
    }

    GetEmpleado(id_empleado: number): Observable<any> {
        this.ApiGetEmpleadoURL = this.ApiEmpleadosURL
        +"/GetEmpleado/?id_empleado="+id_empleado;
        return this.http.get(this.ApiGetEmpleadoURL);
    }

    GetEmpleadoTrabajando(id_empleado: number): Observable<any> {
        this.ApiEmpleadoTrabajandoURL = this.ApiEmpleadosURL
        + "/GetEmpleadoTrabajando/?id_empleado="+id_empleado;
        return this.http.get(this.ApiEmpleadoTrabajandoURL);
    }

    PostEmpleado(empleado: Empleado): Observable<any> {
        this.ApiPostEmpleadoURL = this.ApiEmpleadosURL + "/CrearEmpleado";
        return this.http.post(this.ApiPostEmpleadoURL, empleado);
    }

    UpdateEmpleado(id_empleado: number, empleado: Empleado): Observable<any> {
        this.ApiUpdateEmpleadoURL = this.ApiEmpleadosURL
            + "/ActualizarEmpleado/?id_empleado="+id_empleado;
        return this.http.put(this.ApiUpdateEmpleadoURL, empleado);
    }

    DeleteEmpleado(id_empleado: number): Observable<any> {
        this.ApiDeleteEmpleadoURL = this.ApiEmpleadosURL
        + "/BorrarEmpleado/?id_empleado="+id_empleado;
        return this.http.delete(this.ApiDeleteEmpleadoURL);
    }
}