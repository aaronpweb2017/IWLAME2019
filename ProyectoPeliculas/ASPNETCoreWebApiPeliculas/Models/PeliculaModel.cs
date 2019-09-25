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
        public int id_detalle { get; set; }
        public virtual DetalleTecnico detalleTecnico { get; set; }
        public virtual List<Descarga> descargas { get; set; }
    }
}