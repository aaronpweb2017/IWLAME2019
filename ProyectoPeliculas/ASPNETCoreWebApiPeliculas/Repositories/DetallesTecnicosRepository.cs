using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Models;

namespace ASPNETCoreWebApiPeliculas 
{
    public class DetallesTecnicosRepository : IDetallesTecnicos
    {
        private readonly ApplicationDbContext AppDbContext;
        public DetallesTecnicosRepository(ApplicationDbContext AppDbContext) {
            this.AppDbContext = AppDbContext;
        }

        public async Task<bool> CrearFormato(Formato formato) {
            bool response = false;
            try {
                await AppDbContext.formatos.AddAsync(formato);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<Formato>> GetFormatos() {
            return await AppDbContext.formatos.ToListAsync();
        }

        public async Task<bool> ActualizarFormato(Formato formato) {
            bool response = false;
            try {
                Formato formatToUpdate = await AppDbContext.formatos.Where(f =>
                    f.id_formato == formato.id_formato).FirstOrDefaultAsync();
                formatToUpdate.nombre_formato = formato.nombre_formato;
                AppDbContext.formatos.Update(formatToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarFormato(int id_formato) {
            bool response = false;
            try {
                Formato formatToDelete = await AppDbContext.formatos.Where(f =>
                    f.id_formato == id_formato).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                    dt.id_formato == formatToDelete.id_formato).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                AppDbContext.formatos.Remove(formatToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }
        
        public async Task<bool> CrearTipoResolucion(TipoResolucion tipoResolucion) {
            bool response = false;
            try {
                await AppDbContext.tiposResolucion.AddAsync(tipoResolucion);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<TipoResolucion>> GetTiposResolucion() {
            return await AppDbContext.tiposResolucion.ToListAsync();
        }

        public async Task<bool> ActualizarTipoResolucion(TipoResolucion tipoResolucion) {
            bool response = false;
            try {
                TipoResolucion resolutionTypeToUpdate = await AppDbContext.tiposResolucion.Where(tr =>
                    tr.id_tipo_resolucion == tipoResolucion.id_tipo_resolucion).FirstOrDefaultAsync();
                resolutionTypeToUpdate.nombre_tipo_resolucion = tipoResolucion.nombre_tipo_resolucion;
                resolutionTypeToUpdate.porcentaje_visualizacion = tipoResolucion.porcentaje_visualizacion;
                resolutionTypeToUpdate.porcentaje_perdida = tipoResolucion.porcentaje_perdida;
                AppDbContext.tiposResolucion.Update(resolutionTypeToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarTipoResolucion(int id_tipo_resolucion) {
            bool response = false;
            try {
                TipoResolucion resolutionTypeToDelete = await AppDbContext.tiposResolucion.Where(tr =>
                tr.id_tipo_resolucion == id_tipo_resolucion).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                dt.id_tipo_resolucion == resolutionTypeToDelete.id_tipo_resolucion).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_tipo_resolucion == resolutionTypeToDelete.id_tipo_resolucion).ToListAsync();
                foreach(Resolucion resolucion in resoluciones)
                    AppDbContext.resoluciones.Remove(resolucion);
                AppDbContext.tiposResolucion.Remove(resolutionTypeToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }

        public async Task<bool> CrearValorResolucion(ValorResolucion valorResolucion) {
            bool response = false;
            try {
                await AppDbContext.valoresResolucion.AddAsync(valorResolucion);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<ValorResolucion>> GetValoresResolucion() {
            return await AppDbContext.valoresResolucion.ToListAsync();
        }

        public async Task<bool> ActualizarValorResolucion(ValorResolucion valorResolucion) {
            bool response = false;
            try {
                ValorResolucion resolutionValueToUpdate = await AppDbContext.valoresResolucion.Where(vr =>
                    vr.id_valor_resolucion == valorResolucion.id_valor_resolucion).FirstOrDefaultAsync();
                resolutionValueToUpdate.valor_resolucion = valorResolucion.valor_resolucion;
                AppDbContext.valoresResolucion.Update(resolutionValueToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarValorResolucion(int id_valor_resolucion) {
            bool response = false;
            try {
                ValorResolucion resolutionValueToDelete = await AppDbContext.valoresResolucion.Where(vr =>
                    vr.id_valor_resolucion == id_valor_resolucion).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                dt.id_valor_resolucion == resolutionValueToDelete.id_valor_resolucion).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_valor_resolucion == resolutionValueToDelete.id_valor_resolucion).ToListAsync();
                foreach(Resolucion resolucion in resoluciones)
                    AppDbContext.resoluciones.Remove(resolucion);
                AppDbContext.valoresResolucion.Remove(resolutionValueToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }

        public async Task<bool> CrearRelacionAspecto(RelacionAspecto relacionAspecto) {
            bool response = false;
            try {
                await AppDbContext.relacionesAspecto.AddAsync(relacionAspecto);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<List<RelacionAspecto>> GetRelacionesAspecto() {
            return await AppDbContext.relacionesAspecto.ToListAsync();
        }

        public async Task<bool> ActualizarRelacionAspecto(RelacionAspecto relacionAspecto) {
            bool response = false;
            try {
                RelacionAspecto aspectRatioToUpdate = await AppDbContext.relacionesAspecto.Where(ra =>
                    ra.id_relacion_aspecto == relacionAspecto.id_relacion_aspecto).FirstOrDefaultAsync();
                aspectRatioToUpdate.valor_relacion_aspecto = relacionAspecto.valor_relacion_aspecto;
                AppDbContext.relacionesAspecto.Update(aspectRatioToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarRelacionAspecto(int id_relacion_aspecto) {
            bool response = false;
            try {
                RelacionAspecto aspectRatioToDelete = await AppDbContext.relacionesAspecto.Where(ra =>
                    ra.id_relacion_aspecto == id_relacion_aspecto).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                dt.id_relacion_aspecto == aspectRatioToDelete.id_relacion_aspecto).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_relacion_aspecto == aspectRatioToDelete.id_relacion_aspecto).ToListAsync();
                foreach(Resolucion resolucion in resoluciones)
                    AppDbContext.resoluciones.Remove(resolucion);
                AppDbContext.relacionesAspecto.Remove(aspectRatioToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }

        public async Task<bool> CrearResolucion(Resolucion resolucion) {
            bool response = false;
            try {
                await AppDbContext.resoluciones.AddAsync(resolucion);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarResolucion(int id_tipo_resolucion, int id_valor_resolucion, int id_relacion_aspecto) {
            bool response = false;
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
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                AppDbContext.resoluciones.Remove(resolutionToToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }

        public async Task<bool> CrearDetalleTecnico(DetalleTecnico detalleTecnico) {
            bool response = false;
            try {
                await AppDbContext.detallesTecnicos.AddAsync(detalleTecnico);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> ActualizarDetalleTecnico(DetalleTecnico detalleTecnico) {
            bool response = false;
            try {
                DetalleTecnico technicalDetailToUpdate = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_detalle == detalleTecnico.id_detalle).FirstOrDefaultAsync();
                technicalDetailToUpdate.id_formato = detalleTecnico.id_formato;
                technicalDetailToUpdate.id_tipo_resolucion = detalleTecnico.id_tipo_resolucion;
                technicalDetailToUpdate.id_valor_resolucion = detalleTecnico.id_valor_resolucion;
                technicalDetailToUpdate.id_relacion_aspecto = detalleTecnico.id_relacion_aspecto;
                AppDbContext.detallesTecnicos.Update(technicalDetailToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarDetalleTecnico(int id_detalle) {
            bool response = false;
            try {
                DetalleTecnico technicalDetailToDelete = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_detalle == id_detalle).FirstOrDefaultAsync();
                List<Pelicula> peliculas = await AppDbContext.peliculas.Where(p => 
                    p.id_detalle == technicalDetailToDelete.id_detalle).ToListAsync();
                foreach(Pelicula pelicula in peliculas) {
                    //Llama al método EliminarPelicula(pelicula.id_pelicula) de PeliculasRepository
                }
                AppDbContext.detallesTecnicos.Remove(technicalDetailToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }
    }
}