using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class ValorResolucion {
        public int id_valor_resolucion { get; set; }
        public string valor_resolucion  { get; set; }
        public virtual List<Resolucion> resoluciones { get; set; }
    }
}