using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiORAGestionRecursos.Models {
    public class ProyectoContext: DbContext {
        public ProyectoContext(DbContextOptions<ProyectoContext> options): base(options) { }
        public DbSet<Proyecto> proyectos { get; set; }
    }
}