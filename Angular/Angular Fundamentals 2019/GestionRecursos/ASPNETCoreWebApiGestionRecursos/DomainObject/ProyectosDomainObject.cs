using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class ProyectosDomainObject
    {
        ProyectosDAO proyectosDAO;
        public ProyectosDomainObject(ProyectoContext proyectoContext) {
            proyectosDAO = new ProyectosDAO(proyectoContext);
        }

        public async Task<List<Proyecto>> GetProyectos() {
            return await proyectosDAO.GetProyectos();
        }

        public async Task<Proyecto> GetProyecto(int id_proyecto) {
            return await proyectosDAO.GetProyecto(id_proyecto);
        }
        
        public async Task<bool> CrearProyecto(Proyecto proyecto) {
            return await proyectosDAO.CrearProyecto(proyecto);
        }

        public async Task<bool> ActualizarProyecto(int id_proyecto, Proyecto proyecto) {
            return await proyectosDAO.ActualizarProyecto(id_proyecto, proyecto);
        }

        public async Task<bool> BorrarProyecto(int id_proyecto) {
            return await proyectosDAO.BorrarProyecto(id_proyecto);
        }
    }
}