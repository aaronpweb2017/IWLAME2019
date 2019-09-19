namespace ASPNETCoreWebApiPeliculas.Models {
    public class Enlace {
        public int id_enlace { get; set; }
        public string valor_enlace { get; set; }
        public int status_enlace { get; set; }
        public int id_descarga { get; set; }
        public Descarga descarga;
    }
}