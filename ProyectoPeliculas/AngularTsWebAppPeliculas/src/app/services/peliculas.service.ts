import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { apiURL, header } from '../global.service';
import { Pelicula } from '../interfaces/pelicula';

@Injectable()
export class PeliculasService {
    private ApiPeliculasURL: string;
    private ApiCrearPeliculaURL: string;
    private ApiGetPeliculasURL: string;
    private ApiActualizarPeliculaURL: string;
    private ApiEliminarPeliculaURL: string;

    constructor(private http: HttpClient) {
        this.ApiPeliculasURL = apiURL + "/Peliculas";
    }

    crearPelicula(pelicula: Pelicula): Observable<any[]> {
        this.ApiCrearPeliculaURL = this.ApiPeliculasURL + "/CrearPelicula";
        return this.http.post(this.ApiCrearPeliculaURL, pelicula,
            { headers: header }).pipe(map((data: any) => data as any[]));
    }

    getPeliculas(): Observable<any[]> {
        this.ApiGetPeliculasURL = this.ApiPeliculasURL + "/GetPeliculas";
        return this.http.get(this.ApiGetPeliculasURL,
            { headers: header }).pipe(map((data: any) => data as any[]));
    }

    actualizarPelicula(pelicula: Pelicula): Observable<any[]> {
        this.ApiActualizarPeliculaURL = this.ApiPeliculasURL + "/ActualizarPelicula";
        return this.http.put(this.ApiActualizarPeliculaURL, pelicula,
            { headers: header }).pipe(map((data: any) => data as any[]));
    }

    eliminarPelicula(id_pelicula: number): Observable<any[]> {
        this.ApiEliminarPeliculaURL = this.ApiPeliculasURL
            + "/EliminarPelicula?id_pelicula=" + id_pelicula;
        return this.http.delete(this.ApiEliminarPeliculaURL,
            { headers: header }).pipe(map((data: any) => data as any[]));
    }
}