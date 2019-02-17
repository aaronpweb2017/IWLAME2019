using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundo.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Pais() { }

        public Pais(int Id, string Nombre)
        {
            this.Id = Id; this.Nombre = Nombre;
        }
    }
}
