using System;

namespace ASPNETCoreWebApiPeliculas.Views {
    public class VToken {
        public int id_token { get; set; }
        public string valor_token { get; set; }
        public DateTime emision_token { get; set; }
        public DateTime expiracion_token { get; set; }
        public string nombre_usuario { get; set; }
    }
}