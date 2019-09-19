using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class DetalleTecnico {
        public int id_detalle { get; set; }
        public int id_formato { get; set; }
        public Formato formato { get; set; }
        public int id_tipo_resolucion { get; set; }
        public int id_valor_resolucion { get; set; }
        public int id_relacion_aspecto { get; set; }
        public virtual Resolucion resolucion { get; set; }
        public virtual List<Pelicula> peliculas { get; set; }
    }
}