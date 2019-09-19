using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class Descarga {
        public int id_descarga { get; set; }
        public string password_descarga { get; set; }
        public int id_tipo_archivo { get; set; }
        public virtual TipoArchivo tipoArchivo { get; set; }
        public int id_servidor { get; set; }
        public virtual Servidor servidor { get; set; }
        public int id_pelicula { get; set; }
        public virtual Pelicula pelicula { get; set; }
        public virtual List<Enlace> enlaces { get; set; }
    }
}