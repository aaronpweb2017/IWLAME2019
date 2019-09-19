using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class TipoArchivo {
        public int id_tipo_archivo { get; set; }
        public string nombre_tipo_archivo { get; set; }
        public virtual List<Descarga> descargas { get; set; }
    }
}