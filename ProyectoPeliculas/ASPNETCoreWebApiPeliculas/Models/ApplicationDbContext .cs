using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApiPeliculas.Models {
    public class ApplicationDbContext: DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Token> tokens { get; set; }
        public DbSet<Solicitud> solicitudes { get; set; }
        public DbSet<UsuarioSolicitud> usuariosSolicitudes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Table Usuario Configuration:
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().Property(u => u.id_usuario).
            HasColumnName("id_usuario").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.nombre_usuario).
            HasColumnName("nombre_usuario").HasColumnType("VARCHAR").HasMaxLength(70).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.correo_usuario).
            HasColumnName("correo_usuario").HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.password_usuario).
            HasColumnName("password_usuario").HasColumnType("VARCHAR").HasMaxLength(32).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.tipo_usuario).
            HasColumnName("tipo_usuario").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<Usuario>().HasKey(u => u.id_usuario).HasName("id_usuario_PK_CSTR");
            
            //Table Token Configuration:
            modelBuilder.Entity<Token>().ToTable("Token");
            modelBuilder.Entity<Token>().Property(t => t.id_token).
            HasColumnName("id_token").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<Token>().Property(t => t.valor_token).
            HasColumnName("valor_token").HasColumnType("VARCHAR").HasMaxLength(175).IsRequired();
            modelBuilder.Entity<Token>().Property(t => t.emision_token).
            HasColumnName("emision_token").HasColumnType("DATETIME").IsRequired();
            modelBuilder.Entity<Token>().Property(t => t.expiracion_token).
            HasColumnName("expiracion_token").HasColumnType("DATETIME").IsRequired();
            modelBuilder.Entity<Token>().Property(t => t.id_usuario).
            HasColumnName("id_usuario").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<Token>().HasKey(t => t.id_token).HasName("id_token_PK_CSTR");
            modelBuilder.Entity<Token>().HasOne<Usuario>(t => t.usuario).
            WithMany(u => u.tokens).HasForeignKey(t => t.id_usuario).HasConstraintName("id_usuario_tk_FK_CSTR");

            //Table Solicitud Configuration:
            modelBuilder.Entity<Solicitud>().ToTable("Solicitud");
            modelBuilder.Entity<Solicitud>().Property(s => s.id_solicitud).
            HasColumnName("id_solicitud").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<Solicitud>().Property(s => s.nombre_solicitud).
            HasColumnName("nombre_solicitud").HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Solicitud>().HasKey(s => s.id_solicitud).HasName("id_solicitud_PK_CSTR");
            
            //Table UsuarioSolicitud Configuration:
            modelBuilder.Entity<UsuarioSolicitud>().ToTable("UsuarioSolicitud");
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.id_solicitud).
            HasColumnName("id_solicitud").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.id_usuario).
            HasColumnName("id_usuario").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.status_solicitud).
            HasColumnName("status_solicitud").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.emision_solicitud).
            HasColumnName("emision_solicitud").HasColumnType("DATETIME").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.aprobacion_solicitud).
            HasColumnName("aprobacion_solicitud").HasColumnType("DATETIME");
            modelBuilder.Entity<UsuarioSolicitud>().HasKey(us => new { us.id_usuario,
               us.id_solicitud}).HasName("id_usuario_solicitud_PK_CSTR");
            modelBuilder.Entity<UsuarioSolicitud>().HasOne(us => us.usuario).WithMany(u => u.usuario_solicitudes).
                HasForeignKey(us => us.id_usuario).HasConstraintName("id_usuario_us_FK_CSTR");
            modelBuilder.Entity<UsuarioSolicitud>().HasOne(us => us.solicitud).WithMany(s => s.usuario_solicitudes).
                HasForeignKey(us => us.id_solicitud).HasConstraintName("id_solicitud_FK_CSTR");
        }
    }
}