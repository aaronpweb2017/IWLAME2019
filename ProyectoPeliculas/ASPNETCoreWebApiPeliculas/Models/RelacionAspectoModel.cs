using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class RelacionAspecto {
        public int id_relacion_aspecto { get; set; }
        public string valor_relacion_aspecto  { get; set; }
        public virtual List<Resolucion> resoluciones { get; set; }
    }
}