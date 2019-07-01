using System.Threading.Tasks;
using System.Collections.Generic;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos 
{
    public class ProyectosDAO
    {
        ProyectosRepository proyectosRepository;
        public ProyectosDAO(ProyectoContext proyectoContext) {
            proyectosRepository = new ProyectosRepository(proyectoContext);
        }

        public async Task<int> GetNoProyectos() {    
            return await proyectosRepository.GetNoProyectos();
        }

        public async Task<List<Proyecto>> GetProyectos() {
            return await proyectosRepository.GetProyectos();
        }
        
        public async Task<List<Proyecto>> GetProyectosActivos() {
            return await proyectosRepository.GetProyectosActivos();
        }

        public async Task<List<Proyecto>> GetProyectosPaginacion(int no_pagina) {
            return await proyectosRepository.GetProyectosPaginacion(no_pagina);
        }        

        public async Task<Proyecto> GetProyecto(int id_proyecto) {
            return await proyectosRepository.GetProyecto(id_proyecto);
        }
        
        public async Task<bool> CrearProyecto(Proyecto proyecto) {
            return await proyectosRepository.CrearProyecto(proyecto);
        }

        public async Task<bool> ActualizarProyecto(int id_proyecto, Proyecto proyecto) {
            return await proyectosRepository.ActualizarProyecto(id_proyecto, proyecto);
        }

        public async Task<bool> BorrarProyecto(int id_proyecto) {
            return await proyectosRepository.BorrarProyecto(id_proyecto);
        }
    }
}