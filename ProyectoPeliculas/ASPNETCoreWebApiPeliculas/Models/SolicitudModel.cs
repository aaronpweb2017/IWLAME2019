using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class Solicitud {
        public int id_solicitud { get; set; }
        public string nombre_solicitud  { get; set; }
        public virtual List<UsuarioSolicitud> usuario_solicitudes { get; set; }
    }
}