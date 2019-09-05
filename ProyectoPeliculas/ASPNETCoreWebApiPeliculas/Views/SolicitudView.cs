using System;

namespace ASPNETCoreWebApiPeliculas.Views {
    public class VSolicitud {
        public int id { get; set; }
        public string usuario { get; set; }
        public string tipo { get; set; }
        public string status { get; set; }
        public DateTime emision { get; set; }
        public DateTime aprobacion { get; set; }
    }
}