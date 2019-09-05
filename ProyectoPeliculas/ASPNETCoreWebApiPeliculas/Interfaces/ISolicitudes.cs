using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiPeliculas.Models;
using ASPNETCoreWebApiPeliculas.Views;

namespace ASPNETCoreWebApiPeliculas 
{
    public interface ISolicitudes
    {
        Task<int> GetNoSolicitudes();
        Task<bool> AprobarSolicitud(int id_usuario_solicitud);
        Task<List<VSolicitud>> GetSolicitudesViewPaginacion(int no_pagina);
    }
}