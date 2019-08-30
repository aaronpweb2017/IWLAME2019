using System;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class Token {
        public int id_token { get; set; }
        public string valor_token  { get; set; }
        public DateTime emision_token { get; set; }
        public DateTime expiracion_token { get; set; }
        public int id_usuario { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}