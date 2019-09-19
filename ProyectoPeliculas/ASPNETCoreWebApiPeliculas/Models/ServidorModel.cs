using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class Servidor {
        public int id_servidor { get; set; }
        public string nombre_servidor { get; set; }
        public string sitio_servidor { get; set; }
        public virtual List<Descarga> descargas { get; set; }
    }
}