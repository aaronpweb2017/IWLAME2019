using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliminadorDirectorio
{
    class NodoRuta
    {
        public Ruta info;
        public int idm, idf;
        public NodoRuta(Ruta info, int idm, int idf)
        {
            this.info = info; this.idm = idm; this.idf = idf;
        }
    }
}