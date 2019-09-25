namespace ASPNETCoreWebApiPeliculas.Views {
    public class VDetalleTecnico {
        public int id_detalle { get; set; }
        public int id_formato { get; set; }
        public string nombre_formato  { get; set; }
        public int id_tipo_resolucion { get; set; }
        public string nombre_tipo_resolucion  { get; set; }
        public int id_valor_resolucion { get; set; }
        public string valor_resolucion { get; set; }
        public int id_relacion_aspecto { get; set; }
        public string valor_relacion_aspecto  { get; set; }
    }
}