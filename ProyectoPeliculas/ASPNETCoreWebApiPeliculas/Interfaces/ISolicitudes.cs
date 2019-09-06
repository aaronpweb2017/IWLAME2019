using System.Threading.Tasks;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface ISolicitudes
    {
        Task<bool> AprobarSolicitud(int id_usuario_solicitud);
    }
}