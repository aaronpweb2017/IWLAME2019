using System;
using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {    
    public class Pelicula {
        public int id_pelicula { get; set; }
        public string nombre_pelicula { get; set; }
        public DateTime fecha_estreno { get; set; }
        public Decimal presupuesto { get; set; }
        public Decimal recaudacion { get; set; }
        public string sinopsis { get; set; }
        public Decimal calificacion { get; set; }
        public string directores { get; set; }
        public string generos { get; set; }
        public string idiomas { get; set; }
        public string productoras { get; set; }
        public string actores { get; set; }
        public string pais { get; set; }
        public string audios { get; set; }
        public string subtitulos { get; set; }
        public Decimal peso { get; set; }
        public int id_detalle { get; set; }
        public virtual DetalleTecnico detalleTecnico { get; set; }
        public virtual List<Descarga> descargas { get; set; }
    }
}