import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Pelicula } from '../interfaces/pelicula';

@Injectable()
export class PeliculasService {
    private ApiPeliculasURL: string;
    private token: string;
    private header: HttpHeaders;
    private ApiCrearPeliculaURL: string;
    private ApiGetPeliculasURL: string;
    private ApiActualizarPeliculaURL: string;
    private ApiEliminarPeliculaURL: string;

    constructor(private http: HttpClient) {
        this.ApiPeliculasURL = localStorage.getItem('apiUrl') + "/Peliculas";
        this.header = new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': localStorage.getItem('token')
        });
    }

    crearPelicula(pelicula: Pelicula): Observable<any[]> {
        this.ApiCrearPeliculaURL = this.ApiPeliculasURL + "/CrearPelicula";
        return this.http.post(this.ApiCrearPeliculaURL, pelicula,
            { headers: this.header }).pipe(map((data: any) => data as any[]));
    }

    getPeliculas(): Observable<any[]> {
        this.ApiGetPeliculasURL = this.ApiPeliculasURL + "/GetPeliculas";
        return this.http.get(this.ApiGetPeliculasURL,
            { headers: this.header }).pipe(map((data: any) => data as any[]));
    }

    actualizarPelicula(pelicula: Pelicula): Observable<any[]> {
        this.ApiActualizarPeliculaURL = this.ApiPeliculasURL + "/ActualizarPelicula";
        return this.http.put(this.ApiActualizarPeliculaURL, pelicula,
            { headers: this.header }).pipe(map((data: any) => data as any[]));
    }

    eliminarPelicula(id_pelicula: number): Observable<any[]> {
        this.ApiEliminarPeliculaURL = this.ApiPeliculasURL
            + "/EliminarPelicula?id_pelicula=" + id_pelicula;
        return this.http.delete(this.ApiEliminarPeliculaURL,
            { headers: this.header }).pipe(map((data: any) => data as any[]));
    }
}