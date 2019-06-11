using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreWebApiORAGestionRecursos.Models {
    [Table("PROYECTO")]
    public class Proyecto {
        [Key]
        public int id_proyecto { get; set; }

        [Column(TypeName="VARCHAR(50)")]
        [DisplayName("nombre")]
        public string nombre { get; set; }
        
        [Column(TypeName="VARCHAR(200)")]
        [DisplayName("descripcion")]
        public string descripcion { get; set; }

        [Column(TypeName="DATE")]
        [DisplayName("fecha_inicio")]
        public DateTime fecha_inicio { get; set; }

        [Column(TypeName="DATE")]
        [DisplayName("fecha_fin")]
        public DateTime fecha_fin { get; set; }

        [Column(TypeName="INT")]
        [DisplayName("status")]
        public int status { get; set; }
    }
}