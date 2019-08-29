using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class Usuario {
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string correo_usuario { get; set; }
        public string password_usuario { get; set; }
        public int tipo_usuario { get; set; }
        public List<Token> tokens { get; set; }
        public List<UsuarioSolicitud> usuario_solicitudes { get; set; }
    }
}