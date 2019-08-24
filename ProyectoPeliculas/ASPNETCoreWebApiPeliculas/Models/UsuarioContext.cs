using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class UsuarioContext: DbContext {
        public UsuarioContext(DbContextOptions<UsuarioContext> options): base(options) { }
        public DbSet<Usuario> usuarios { get; set; }
    }
}