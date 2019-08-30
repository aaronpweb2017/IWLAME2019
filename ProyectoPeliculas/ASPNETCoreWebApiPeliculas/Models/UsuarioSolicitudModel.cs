using System;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class UsuarioSolicitud {
        public int id_usuario_solicitud { get; set; }
        public int id_usuario { get; set; }
        public virtual Usuario usuario { get; set; }
        public int id_solicitud { get; set; }
        public virtual Solicitud solicitud { get; set; }
        public int status_solicitud { get; set; }
        public DateTime emision_solicitud { get; set; }
        public DateTime aprobacion_solicitud { get; set; }
    }
}