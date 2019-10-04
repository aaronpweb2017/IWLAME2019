using System;
using System.Threading.Tasks;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface ISolicitudes
    {
        Task<Object []> AprobarSolicitud(int id_usuario_solicitud);
    }
}