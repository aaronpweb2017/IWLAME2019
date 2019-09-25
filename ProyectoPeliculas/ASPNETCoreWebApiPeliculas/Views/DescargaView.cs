namespace ASPNETCoreWebApiPeliculas.Views {
    public class VDescarga {
        public int id_descarga { get; set; }
        public string password_descarga  { get; set; }
        public int id_tipo_archivo { get; set; }
        public string nombre_tipo_archivo  { get; set; }
        public int id_servidor { get; set; }
        public string nombre_servidor { get; set; }
        public int id_pelicula { get; set; }
        public string nombre_pelicula  { get; set; }
    }
}