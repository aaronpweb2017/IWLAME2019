using System;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos.Models {
    public class AsignacionContext: DbContext {
        public AsignacionContext(DbContextOptions<AsignacionContext> options): base(options) { } 
        public DbSet<Asignacion> asignaciones { get; set; }
    }
}