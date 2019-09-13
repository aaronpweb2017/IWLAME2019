using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas.Models {

    public class Resolucion {
        public int id_tipo_resolucion { get; set; }
        public virtual TipoResolucion tipoResolucion { get; set; }
        public int id_valor_resolucion { get; set; }
        public virtual ValorResolucion valorResolucion { get; set; }
        public int id_relacion_aspecto { get; set; }
        public virtual RelacionAspecto relacionAspecto { get; set; }
        public virtual List<DetalleTecnico> detallesTecnicos { get; set; }
    }
}