using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public interface IProyectosManager
    {
        Task<int> GetNoProyectos();
        Task<List<Proyecto>> GetProyectos();
        Task<List<Proyecto>> GetProyectosPaginacion(int no_pagina);        
        Task<Proyecto> GetProyecto(int id_proyecto);
        Task<bool> CrearProyecto(Proyecto proyecto);
        Task<bool> ActualizarProyecto(int id_proyecto, Proyecto proyecto);
        Task<bool> BorrarProyecto(int id_proyecto);
    } 
}