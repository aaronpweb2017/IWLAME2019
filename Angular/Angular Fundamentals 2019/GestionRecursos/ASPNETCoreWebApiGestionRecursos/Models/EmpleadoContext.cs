using System;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos.Models {
    public class EmpleadoContext: DbContext {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options): base(options) { } 
        public DbSet<Empleado> empleados { get; set; }
    }
}