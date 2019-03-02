using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliminadorDirectorio
{
    class Ruta
    {
        public String path;
        public String name;
        public String type;
        public long size;
        public Ruta(String path, String name, String type, long size)
        {
            this.path = path;
            this.name = name;
            this.type = type;
            this.size = size;
        }
    }
}
