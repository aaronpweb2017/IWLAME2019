import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { apiURL } from '../global.service';
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

    crearPelicula(pelicula: Pelicula): Observable<boolean> {
        this.ApiCrearPeliculaURL = this.ApiPeliculasURL + "/CrearPelicula";
        return this.http.post(this.ApiCrearPeliculaURL, pelicula
        ).pipe(map((data: any) => data as boolean));
    }

    getPeliculas(): Observable<Pelicula[]> {
        this.ApiGetPeliculasURL = this.ApiPeliculasURL + "/GetPeliculas";
        return this.http.get(this.ApiGetPeliculasURL
        ).pipe(map((data: any) => data as Pelicula[]));
    }

    actualizarPelicula(pelicula: Pelicula): Observable<boolean> {
        this.ApiActualizarPeliculaURL = this.ApiPeliculasURL + "/ActualizarPelicula";
        return this.http.put(this.ApiActualizarPeliculaURL, pelicula
        ).pipe(map((data: any) => data as boolean));
    }

    eliminarPelicula(id_pelicula: number): Observable<boolean> {
        this.ApiEliminarPeliculaURL = this.ApiPeliculasURL
            + "/EliminarPelicula?id_pelicula=" + id_pelicula;
        return this.http.delete(this.ApiEliminarPeliculaURL
        ).pipe(map((data: any) => data as boolean));
    }
}