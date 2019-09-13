using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class TipoResolucion {
        public int id_tipo_resolucion { get; set; }
        public string nombre_tipo_resolucion  { get; set; }
        public decimal porcentaje_visualizacion  { get; set; }
        public decimal porcentaje_perdida  { get; set; }
        public virtual List<Resolucion> resoluciones { get; set; }
    }
}