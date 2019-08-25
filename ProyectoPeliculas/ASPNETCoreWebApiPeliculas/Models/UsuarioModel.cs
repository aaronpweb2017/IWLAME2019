using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreWebApiPeliculas.Models {
    [Table("USUARIO")]
    public class Usuario {
        [Key]
        public int id_usuario { get; set; }
        
        [Column(TypeName="VARCHAR(50)")]
        [DisplayName("nombre_usuario")]
        public string nombre_usuario { get; set; }

        [Column(TypeName="VARCHAR(50)")]
        [DisplayName("correo_usuario")]
        public string correo_usuario { get; set; }

        [Column(TypeName="VARCHAR(32)")]
        [DisplayName("password_usuario")]
        public string password_usuario { get; set; }

        [Column(TypeName="INT")]
        [DisplayName("tipo_usuario")]
        public int tipo_usuario { get; set; }
        
        [Column(TypeName="VARCHAR(100)")]
        [DisplayName("token_usuario")]
        public string token_usuario { get; set; }

        [Column(TypeName="INT")]
        [DisplayName("solicitud_usuario")]
        public int solicitud_usuario { get; set; }

        [Column(TypeName="INT")]
        [DisplayName("aprobacion_usuario")]
        public int aprobacion_usuario { get; set; }
    }
}