using System;

namespace ASPNETCoreWebApiPeliculas.Views {
    public class VToken {
        public int id { get; set; }
        public string codigo { get; set; }
        public DateTime emision { get; set; }
        public DateTime expiracion { get; set; }
        public string usuario { get; set; }
    }
}