using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreWebApiORAGestionRecursos.Models {
    [Table("ASIGNACION")]
    public class Asignacion {
        [Key]
        public int id_asignacion { get; set; }
        
        //[Key] [ForeignKey("ID_PROYECTO")]
        //[Column(Order=1)]
        public int id_proyecto { get; set; }
        
        //[Key] [ForeignKey("ID_EMPLEADO")]
        //[Column(Order=2)]
        public int id_empleado { get; set; }

        [Column(TypeName="DATE")]
        [DisplayName("fecha_asignado")]
        public DateTime fecha_asignado { get; set; }

        [Column(TypeName="DATE")]
        [DisplayName("fecha_desasignado")]
        public DateTime fecha_desasignado { get; set; }
    }
}