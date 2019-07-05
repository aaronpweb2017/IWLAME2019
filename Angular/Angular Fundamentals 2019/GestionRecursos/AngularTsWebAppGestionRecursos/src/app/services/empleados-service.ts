import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Empleado } from '../interfaces/empleado';
import { header } from 'src/app/token-service';

@Injectable()
export class EmpleadosService {
    ApiUserAuthenticateURL: string;
    ApiEmpleadosURL: string;
    ApiGetNoEmpleadosURL: string;
    ApiGetEmpleadosURL: string;
    ApiGetEmpleadosActivosURL: string;
    ApiGetAsignadosPaginacionURL: string;
    ApiGetEmpleadosPaginacionURL: string;
    ApiGetEmpleadoURL: string;
    ApiEmpleadoTrabajandoURL: string;
    ApiPostEmpleadoURL: string;
    ApiUpdateEmpleadoURL: string;
    ApiDeleteEmpleadoURL: string;

    constructor(private http: HttpClient) {
        this.ApiEmpleadosURL = "https://localhost:5001/Api/Empleados";
        this.ApiUserAuthenticateURL = "https://localhost:5001/Api/Users/GetTokenAuthentication";
    }

    GetTokenAuthentication(empleado: Empleado): Observable<any> {
        return this.http.post(this.ApiUserAuthenticateURL,
            empleado, { responseType: 'text' });
    }

    GetNoEmpleados(): Observable<any> {
        this.ApiGetNoEmpleadosURL = this.ApiEmpleadosURL + "/GetNoEmpleados";
        return this.http.get(this.ApiGetNoEmpleadosURL, {headers: header});
    }

    GetEmpleados(): Observable<any> {
        this.ApiGetEmpleadosURL = this.ApiEmpleadosURL + "/GetEmpleados";
        return this.http.get(this.ApiGetEmpleadosURL, {headers: header});
    }

    GetEmpleadosActivos(): Observable<any> {
        this.ApiGetEmpleadosActivosURL = this.ApiEmpleadosURL + "/GetEmpleadosActivos";
        return this.http.get(this.ApiGetEmpleadosActivosURL, {headers: header});
    }

    GetAsignadosPaginacion(no_pagina: number): Observable<any> {
        this.ApiGetAsignadosPaginacionURL = this.ApiEmpleadosURL
            + "/GetAsignadosPaginacion/?no_pagina=" + no_pagina;
        return this.http.get(this.ApiGetAsignadosPaginacionURL, {headers: header});
    }

    GetEmpleadosPaginacion(no_pagina: number): Observable<any> {
        this.ApiGetEmpleadosPaginacionURL = this.ApiEmpleadosURL
            + "/GetEmpleadosPaginacion/?no_pagina=" + no_pagina;
        return this.http.get(this.ApiGetEmpleadosPaginacionURL, {headers: header});
    }

    GetEmpleado(id_empleado: number): Observable<any> {
        this.ApiGetEmpleadoURL = this.ApiEmpleadosURL
            + "/GetEmpleado/?id_empleado=" + id_empleado;
        return this.http.get(this.ApiGetEmpleadoURL, {headers: header});
    }

    GetEmpleadoTrabajando(id_empleado: number): Observable<any> {
        this.ApiEmpleadoTrabajandoURL = this.ApiEmpleadosURL
            + "/GetEmpleadoTrabajando/?id_empleado=" + id_empleado;
        return this.http.get(this.ApiEmpleadoTrabajandoURL, {headers: header});
    }

    PostEmpleado(empleado: Empleado): Observable<any> {
        this.ApiPostEmpleadoURL = this.ApiEmpleadosURL + "/CrearEmpleado";
        return this.http.post(this.ApiPostEmpleadoURL, empleado, {headers: header});
    }

    UpdateEmpleado(id_empleado: number, empleado: Empleado): Observable<any> {
        this.ApiUpdateEmpleadoURL = this.ApiEmpleadosURL
            + "/ActualizarEmpleado/?id_empleado=" + id_empleado;
        return this.http.put(this.ApiUpdateEmpleadoURL, empleado, {headers: header});
    }

    DeleteEmpleado(id_empleado: number): Observable<any> {
        this.ApiDeleteEmpleadoURL = this.ApiEmpleadosURL
            + "/BorrarEmpleado/?id_empleado=" + id_empleado;
        return this.http.delete(this.ApiDeleteEmpleadoURL, {headers: header});
    }
}