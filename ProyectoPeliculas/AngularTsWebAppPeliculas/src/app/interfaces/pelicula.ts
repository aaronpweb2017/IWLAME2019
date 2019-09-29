export interface Pelicula {
    id_pelicula: number;
    nombre_pelicula: string;
    fecha_estreno: Date;
    presupuesto: number;
    recaudacion: number;
    sinopsis: string;
    calificacion: number;
    directores: string;
    generos: string;
    id_detalle: number;
    rutaImagen: string;
}