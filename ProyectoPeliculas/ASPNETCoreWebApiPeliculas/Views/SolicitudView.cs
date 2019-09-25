using System;

namespace ASPNETCoreWebApiPeliculas.Views {
    public class VSolicitud {
        public int id_usuario_solicitud { get; set; }
        public string nombre_usuario { get; set; }
        public string nombre_solicitud { get; set; }
        public int status_solicitud { get; set; }
        public DateTime emision_solicitud { get; set; }
        public DateTime aprobacion_solicitud { get; set; }
    }
}