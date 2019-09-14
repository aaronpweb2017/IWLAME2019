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
                Formato formatoToUpdate = await AppDbContext.formatos.Where(f =>
                    f.id_formato == formato.id_formato).FirstOrDefaultAsync();
                formatoToUpdate.nombre_formato = formato.nombre_formato;
                AppDbContext.formatos.Update(formatoToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarFormato(Formato formato) {
            bool response = false;
            try {
                Formato formatoToDelete = await AppDbContext.formatos.Where(f =>
                    f.id_formato == formato.id_formato).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                    dt.id_formato == formatoToDelete.id_formato).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                AppDbContext.formatos.Remove(formatoToDelete);
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
                TipoResolucion tipoResolucionToUpdate = await AppDbContext.tiposResolucion.Where(tr =>
                    tr.id_tipo_resolucion == tipoResolucion.id_tipo_resolucion).FirstOrDefaultAsync();
                tipoResolucionToUpdate.nombre_tipo_resolucion = tipoResolucion.nombre_tipo_resolucion;
                tipoResolucionToUpdate.porcentaje_visualizacion = tipoResolucion.porcentaje_visualizacion;
                tipoResolucionToUpdate.porcentaje_perdida = tipoResolucion.porcentaje_perdida;
                AppDbContext.tiposResolucion.Update(tipoResolucionToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarTipoResolucion(TipoResolucion tipoResolucion) {
            bool response = false;
            try {
                TipoResolucion tipoResolucionToDelete = await AppDbContext.tiposResolucion.Where(tr =>
                tr.id_tipo_resolucion == tipoResolucion.id_tipo_resolucion).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                dt.id_tipo_resolucion == tipoResolucionToDelete.id_tipo_resolucion).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_tipo_resolucion == tipoResolucionToDelete.id_tipo_resolucion).ToListAsync();
                foreach(Resolucion resolucion in resoluciones)
                    AppDbContext.resoluciones.Remove(resolucion);
                AppDbContext.tiposResolucion.Remove(tipoResolucionToDelete);
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
                ValorResolucion valorResolucionToUpdate = await AppDbContext.valoresResolucion.Where(vr =>
                    vr.id_valor_resolucion == valorResolucion.id_valor_resolucion).FirstOrDefaultAsync();
                valorResolucionToUpdate.valor_resolucion = valorResolucion.valor_resolucion;
                AppDbContext.valoresResolucion.Update(valorResolucionToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarValorResolucion(ValorResolucion valorResolucion) {
            bool response = false;
            try {
                ValorResolucion valorResolucionToDelete = await AppDbContext.valoresResolucion.Where(vr =>
                    vr.id_valor_resolucion == valorResolucion.id_valor_resolucion).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                dt.id_valor_resolucion == valorResolucionToDelete.id_valor_resolucion).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_valor_resolucion == valorResolucionToDelete.id_valor_resolucion).ToListAsync();
                foreach(Resolucion resolucion in resoluciones)
                    AppDbContext.resoluciones.Remove(resolucion);
                AppDbContext.valoresResolucion.Remove(valorResolucionToDelete);
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
                RelacionAspecto relacionAspectoToUpdate = await AppDbContext.relacionesAspecto.Where(ra =>
                    ra.id_relacion_aspecto == relacionAspecto.id_relacion_aspecto).FirstOrDefaultAsync();
                relacionAspectoToUpdate.valor_relacion_aspecto = relacionAspecto.valor_relacion_aspecto;
                AppDbContext.relacionesAspecto.Update(relacionAspectoToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarRelacionAspecto(RelacionAspecto relacionAspecto) {
            bool response = false;
            try {
                RelacionAspecto relacionAspectoToDelete = await AppDbContext.relacionesAspecto.Where(ra =>
                    ra.id_relacion_aspecto == relacionAspecto.id_relacion_aspecto).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt => 
                dt.id_relacion_aspecto == relacionAspectoToDelete.id_relacion_aspecto).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                List<Resolucion> resoluciones = await AppDbContext.resoluciones.Where(r => 
                r.id_relacion_aspecto == relacionAspectoToDelete.id_relacion_aspecto).ToListAsync();
                foreach(Resolucion resolucion in resoluciones)
                    AppDbContext.resoluciones.Remove(resolucion);
                AppDbContext.relacionesAspecto.Remove(relacionAspectoToDelete);
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

        public async Task<List<Resolucion>> GetResoluciones() {
            return await AppDbContext.resoluciones.ToListAsync();
        }

        public async Task<bool> EliminarResolucion(Resolucion resolucion) {
            bool response = false;
            try {
                Resolucion resolucionToToDelete = await AppDbContext.resoluciones.Where(r =>
                    r.id_tipo_resolucion == resolucion.id_tipo_resolucion &&
                    r.id_valor_resolucion == resolucion.id_valor_resolucion &&
                    r.id_relacion_aspecto == resolucion.id_relacion_aspecto).FirstOrDefaultAsync();
                List<DetalleTecnico> detallesTecnicos = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_tipo_resolucion == resolucionToToDelete.id_tipo_resolucion &&
                    dt.id_valor_resolucion == resolucionToToDelete.id_valor_resolucion &&
                    dt.id_relacion_aspecto == resolucionToToDelete.id_relacion_aspecto).ToListAsync();
                foreach(DetalleTecnico detalleTecnico in detallesTecnicos)
                    AppDbContext.detallesTecnicos.Remove(detalleTecnico);
                AppDbContext.resoluciones.Remove(resolucionToToDelete);
                await AppDbContext.SaveChangesAsync();
                response = true;
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

        public async Task<List<DetalleTecnico>> GetDetallesTecnicos() {
            return await AppDbContext.detallesTecnicos.ToListAsync();
        }

        public async Task<bool> ActualizarDetalleTecnico(DetalleTecnico detalleTecnico) {
            bool response = false;
            try {
                DetalleTecnico detalleTecnicoToUpdate = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_detalle == detalleTecnico.id_detalle).FirstOrDefaultAsync();
                detalleTecnicoToUpdate.id_formato = detalleTecnico.id_formato;
                detalleTecnicoToUpdate.id_tipo_resolucion = detalleTecnico.id_tipo_resolucion;
                detalleTecnicoToUpdate.id_valor_resolucion = detalleTecnico.id_valor_resolucion;
                detalleTecnicoToUpdate.id_relacion_aspecto = detalleTecnico.id_relacion_aspecto;
                AppDbContext.detallesTecnicos.Update(detalleTecnicoToUpdate); 
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;
        }

        public async Task<bool> EliminarDetalleTecnico(DetalleTecnico detalleTecnico) {
            bool response = false;
            try {
                DetalleTecnico detalleTecnicoToToDelete = await AppDbContext.detallesTecnicos.Where(dt =>
                    dt.id_detalle == detalleTecnico.id_detalle).FirstOrDefaultAsync();
                AppDbContext.detallesTecnicos.Remove(detalleTecnicoToToDelete);
                await AppDbContext.SaveChangesAsync(); response = true;
            }
            catch(Exception exception) {
                Console.WriteLine("Exception msj: "+exception.Message);
            }
            return response;  
        }
    }
}