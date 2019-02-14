namespace SueldoPiramidal
{
    class NodoTrabajador
    {
        public Trabajador info;
        public int idm, idf;
        public NodoTrabajador(Trabajador info, int idm, int idf)
        {
            this.info = info; this.idm = idm; this.idf = idf;
        }
    }
}