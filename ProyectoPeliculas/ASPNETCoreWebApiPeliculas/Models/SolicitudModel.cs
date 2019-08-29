using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class Solicitud {
        public int id_solicitud { get; set; }
        public int nombre_solicitud  { get; set; }
        public List<UsuarioSolicitud> usuario_solicitudes { get; set; }
    }
}