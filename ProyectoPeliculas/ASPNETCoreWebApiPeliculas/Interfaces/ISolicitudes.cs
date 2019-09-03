using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface ISolicitudes
    {
        Task<int> GetNoSolicitudes();
        Task<List<UsuarioSolicitud>> GetSolicitudesPaginacion(int no_pagina);
        Task<bool> AprobarSolicitud(int id_usuario_solicitud);
    } 
}