using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class ProyectosManager : IProyectosManager
    {
        ProyectosDomainObject proyectosDO;
        public ProyectosManager(ProyectoContext proyectoContext) {
            proyectosDO = new ProyectosDomainObject(proyectoContext);
        }

        public async Task<List<Proyecto>> GetProyectos() {
            return await proyectosDO.GetProyectos();
        }

        public async Task<Proyecto> GetProyecto(int id_proyecto) {
            return await proyectosDO.GetProyecto(id_proyecto);
        }
        
        public async Task<bool> CrearProyecto(Proyecto proyecto) {
            return await proyectosDO.CrearProyecto(proyecto);
        }

        public async Task<bool> ActualizarProyecto(int id_proyecto, Proyecto proyecto) {
            return await proyectosDO.ActualizarProyecto(id_proyecto, proyecto);
        }

        public async Task<bool> BorrarProyecto(int id_proyecto) {
            return await proyectosDO.BorrarProyecto(id_proyecto);
        }
    }
}