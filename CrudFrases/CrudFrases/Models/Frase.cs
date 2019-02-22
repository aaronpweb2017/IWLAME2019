using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFrases.Models
{
    public class Frase
    {
        public Frase() { }

        public Frase(string Valor)
        {
            this.Valor = Valor;
        }

        public int Id { get; set;  }

        public string Valor { get; set;  }
    }
}
