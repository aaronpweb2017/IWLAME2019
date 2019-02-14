using System.Collections.Generic;

namespace SueldoPiramidal
{
    class Trabajador
    {
        public int id;
        public string nombre;
        public double ganancias;
        public List<Trabajador> lstReclutados;
        public Trabajador(int id, string na, double ga, List<Trabajador> lr)
        {
            this.id = id; this.nombre = na; ganancias = ga; lstReclutados = lr;
        }
    }
}