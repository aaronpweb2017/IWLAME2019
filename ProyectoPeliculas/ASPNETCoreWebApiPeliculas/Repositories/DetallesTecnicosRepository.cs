using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Models;
using System.Collections.Generic;

namespace ASPNETCoreWebApiPeliculas 
{
    public class DetallesTecnicosRepository : IDetallesTecnicos
    {
        private readonly ApplicationDbContext AppDbContext;
        private readonly IPeliculas peliculas;
        public DetallesTecnicosRepository(ApplicationDbContext AppDbContext, IPeliculas peliculas) {
            this.AppDbContext = AppDbContext; this.peliculas = peliculas;
        }

        public async Task<Object []> CrearFormato(Formato formato) {
            Object [] response = new Object [2];
            try {
                await AppDbContext.formatos.AddAsync(formato);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetFormatos() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.formatos.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> ActualizarFormato(Formato formato) {
            Object [] response = new Object [2];
            try {
                Formato formatToUpdate = await AppDbContext.formatos.Where(f =>
                    f.id_formato == formato.id_formato).FirstOrDefaultAsync();
                formatToUpdate.nombre_formato = formato.nombre_formato;
                AppDbContext.formatos.Update(formatToUpdate); 
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarFormato(int id_formato) {
            Object [] response = new Object [2];
            try {
                Formato formatToDelete = await AppDbContext.formatos.Where(f =>
                    f.id_formato == id_formato).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                    dt.id_formato == formatToDelete.id_formato).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    await EliminarDetalleTecnico(detalleTecnico.id_detalle);
                AppDbContext.formatos.Remove(formatToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;  
        }
        
        public async Task<Object []> CrearTipoResolucion(TipoResolucion tipoResolucion) {
            Object [] response = new Object [2];
            try {
                await AppDbContext.tiposResolucion.AddAsync(tipoResolucion);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetTiposResolucion() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.tiposResolucion.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> ActualizarTipoResolucion(TipoResolucion tipoResolucion) {
            Object [] response = new Object [2];
            try {
                TipoResolucion resolutionTypeToUpdate = await AppDbContext.tiposResolucion.Where(tr =>
                    tr.id_tipo_resolucion == tipoResolucion.id_tipo_resolucion).FirstOrDefaultAsync();
                resolutionTypeToUpdate.nombre_tipo_resolucion = tipoResolucion.nombre_tipo_resolucion;
                resolutionTypeToUpdate.porcentaje_visualizacion = tipoResolucion.porcentaje_visualizacion;
                resolutionTypeToUpdate.porcentaje_perdida = tipoResolucion.porcentaje_perdida;
                AppDbContext.tiposResolucion.Update(resolutionTypeToUpdate); 
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarTipoResolucion(int id_tipo_resolucion) {
            Object [] response = new Object [2];
            try {
                TipoResolucion resolutionTypeToDelete = await AppDbContext.tiposResolucion.Where(tr =>
                tr.id_tipo_resolucion == id_tipo_resolucion).FirstOrDefaultAsync();
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_tipo_resolucion == resolutionTypeToDelete.id_tipo_resolucion).ToListAsync();
                foreach(Resolucion resolucion in resoluciones) {
                    await EliminarResolucion(resolucion.id_tipo_resolucion,
                    resolucion.id_valor_resolucion, resolucion.id_relacion_aspecto);
                }
                AppDbContext.tiposResolucion.Remove(resolutionTypeToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;  
        }

        public async Task<Object []> CrearValorResolucion(ValorResolucion valorResolucion) {
            Object [] response = new Object [2];
            try {
                await AppDbContext.valoresResolucion.AddAsync(valorResolucion);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetValoresResolucion() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.valoresResolucion.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> ActualizarValorResolucion(ValorResolucion valorResolucion) {
            Object [] response = new Object [2];
            try {
                ValorResolucion resolutionValueToUpdate = await AppDbContext.valoresResolucion.Where(vr =>
                    vr.id_valor_resolucion == valorResolucion.id_valor_resolucion).FirstOrDefaultAsync();
                resolutionValueToUpdate.valor_resolucion = valorResolucion.valor_resolucion;
                AppDbContext.valoresResolucion.Update(resolutionValueToUpdate); 
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarValorResolucion(int id_valor_resolucion) {
            Object [] response = new Object [2];
            try {
                ValorResolucion resolutionValueToDelete = await AppDbContext.valoresResolucion.Where(vr =>
                    vr.id_valor_resolucion == id_valor_resolucion).FirstOrDefaultAsync();
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_valor_resolucion == resolutionValueToDelete.id_valor_resolucion).ToListAsync();
                foreach(Resolucion resolucion in resoluciones) {
                    await EliminarResolucion(resolucion.id_tipo_resolucion,
                    resolucion.id_valor_resolucion, resolucion.id_relacion_aspecto);
                }
                AppDbContext.valoresResolucion.Remove(resolutionValueToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;  
        }

        public async Task<Object []> CrearRelacionAspecto(RelacionAspecto relacionAspecto) {
            Object [] response = new Object [2];
            try {
                await AppDbContext.relacionesAspecto.AddAsync(relacionAspecto);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> GetRelacionesAspecto() {
            Object [] response = new Object [2];
            try {
                response[0] = await AppDbContext.relacionesAspecto.ToListAsync();
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> ActualizarRelacionAspecto(RelacionAspecto relacionAspecto) {
            Object [] response = new Object [2];
            try {
                RelacionAspecto aspectRatioToUpdate = await AppDbContext.relacionesAspecto.Where(ra =>
                    ra.id_relacion_aspecto == relacionAspecto.id_relacion_aspecto).FirstOrDefaultAsync();
                aspectRatioToUpdate.valor_relacion_aspecto = relacionAspecto.valor_relacion_aspecto;
                AppDbContext.relacionesAspecto.Update(aspectRatioToUpdate); 
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarRelacionAspecto(int id_relacion_aspecto) {
            Object [] response = new Object [2];
            try {
                RelacionAspecto aspectRatioToDelete = await AppDbContext.relacionesAspecto.Where(ra =>
                    ra.id_relacion_aspecto == id_relacion_aspecto).FirstOrDefaultAsync();
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_relacion_aspecto == aspectRatioToDelete.id_relacion_aspecto).ToListAsync();
                foreach(Resolucion resolucion in resoluciones) {
                    await EliminarResolucion(resolucion.id_tipo_resolucion,
                    resolucion.id_valor_resolucion, resolucion.id_relacion_aspecto);
                }
                AppDbContext.relacionesAspecto.Remove(aspectRatioToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;  
        }

        public async Task<Object []> CrearResolucion(Resolucion resolucion) {
            Object [] response = new Object [2];
            try {
                await AppDbContext.resoluciones.AddAsync(resolucion);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarResolucion(int id_tipo_resolucion, int id_valor_resolucion, int id_relacion_aspecto) {
            Object [] response = new Object [2];
            try {
                Resolucion resolutionToToDelete = await AppDbContext.resoluciones.Where(r =>
                    r.id_tipo_resolucion == id_tipo_resolucion &&
                    r.id_valor_resolucion == id_valor_resolucion &&
                    r.id_relacion_aspecto == id_relacion_aspecto).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_tipo_resolucion == resolutionToToDelete.id_tipo_resolucion &&
                    dt.id_valor_resolucion == resolutionToToDelete.id_valor_resolucion &&
                    dt.id_relacion_aspecto == resolutionToToDelete.id_relacion_aspecto).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    await EliminarDetalleTecnico(detalleTecnico.id_detalle);
                AppDbContext.resoluciones.Remove(resolutionToToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;  
        }

        public async Task<Object []> CrearDetalleTecnico(DetalleTecnico detalleTecnico) {
            Object [] response = new Object [2];
            try {
                await AppDbContext.detallesTecnicos.AddAsync(detalleTecnico);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> ActualizarDetalleTecnico(DetalleTecnico detalleTecnico) {
            Object [] response = new Object [2];
            try {
                DetalleTecnico technicalDetailToUpdate = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_detalle == detalleTecnico.id_detalle).FirstOrDefaultAsync();
                technicalDetailToUpdate.id_formato = detalleTecnico.id_formato;
                technicalDetailToUpdate.id_tipo_resolucion = detalleTecnico.id_tipo_resolucion;
                technicalDetailToUpdate.id_valor_resolucion = detalleTecnico.id_valor_resolucion;
                technicalDetailToUpdate.id_relacion_aspecto = detalleTecnico.id_relacion_aspecto;
                AppDbContext.detallesTecnicos.Update(technicalDetailToUpdate); 
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;
        }

        public async Task<Object []> EliminarDetalleTecnico(int id_detalle) {
            Object [] response = new Object [2];
            try {
                DetalleTecnico technicalDetailToDelete = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_detalle == id_detalle).FirstOrDefaultAsync();
                List<Pelicula> peliculas = await AppDbContext.peliculas.Where(p => 
                    p.id_detalle == technicalDetailToDelete.id_detalle).ToListAsync();
                foreach(Pelicula pelicula in peliculas)
                    await this.peliculas.EliminarPelicula(pelicula.id_pelicula);
                AppDbContext.detallesTecnicos.Remove(technicalDetailToDelete);
                await AppDbContext.SaveChangesAsync();
                response[0] = true;
            }
            catch(Exception exception) {
                response[1] = (exception.InnerException != null) ?
                exception.InnerException.Message : exception.Message;
            }
            return response;  
        }
    }
}