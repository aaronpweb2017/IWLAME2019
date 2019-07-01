using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreWebApiORAGestionRecursos.Models {
    [Table("EMPLEADO")]
    public class Empleado {
        [Key]
        public int id_empleado { get; set; }
        [Column(TypeName="VARCHAR(20)")]
        [DisplayName("nombre")]
        public string nombre { get; set; }
        
        [Column(TypeName="VARCHAR(20)")]
        [DisplayName("apellido")]
        public string apellido { get; set; }
        
        [Column(TypeName="VARCHAR(100)")]
        [DisplayName("direccion")]
        public string direccion { get; set; }
        
        [Column(TypeName="VARCHAR(14)")]
        [DisplayName("telefono")]
        public string telefono { get; set; }
        
        [Column(TypeName="INT")]
        [DisplayName("sueldo")]
        public int sueldo { get; set; }
        
        [Column(TypeName="INT")]
        [DisplayName("status")]
        public int status { get; set; }
    }
}