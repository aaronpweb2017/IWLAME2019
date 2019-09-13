using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class Formato {
        public int id_formato { get; set; }
        public string nombre_formato  { get; set; }
        public virtual List<DetalleTecnico> detallesTecnicos { get; set; }
    }
}