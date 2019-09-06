using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApiPeliculas.Models;
using ASPNETCoreWebApiPeliculas.Views;

namespace ASPNETCoreWebApiPeliculas {
    public class ApplicationDbContext: DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Token> tokens { get; set; }
        public DbSet<Solicitud> solicitudes { get; set; }
        public DbSet<UsuarioSolicitud> usuariosSolicitudes { get; set; }
        public DbSet<VSolicitud> vSolicitudes { get; set; }
        public DbSet<VToken> vTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Table Usuario Configuration:
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().Property(u => u.id_usuario).
            HasColumnName("id_usuario").HasColumnType("INT");
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
            HasColumnName("id_token").HasColumnType("INT");
            modelBuilder.Entity<Token>().Property(t => t.valor_token).
            HasColumnName("valor_token").HasColumnType("VARCHAR").HasMaxLength(180).IsRequired();
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
            HasColumnName("id_solicitud").HasColumnType("INT");
            modelBuilder.Entity<Solicitud>().Property(s => s.nombre_solicitud).
            HasColumnName("nombre_solicitud").HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Solicitud>().HasKey(s => s.id_solicitud).HasName("id_solicitud_PK_CSTR");
            
            //Table UsuarioSolicitud Configuration:
            modelBuilder.Entity<UsuarioSolicitud>().ToTable("UsuarioSolicitud");
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.id_usuario_solicitud).
            HasColumnName("id_usuario_solicitud").HasColumnType("INT");
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.id_usuario).
            HasColumnName("id_usuario").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.id_solicitud).
            HasColumnName("id_solicitud").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.status_solicitud).
            HasColumnName("status_solicitud").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.emision_solicitud).
            HasColumnName("emision_solicitud").HasColumnType("DATETIME2").IsRequired();
            modelBuilder.Entity<UsuarioSolicitud>().Property(us => us.aprobacion_solicitud).
            HasColumnName("aprobacion_solicitud").HasColumnType("DATETIME2");
            modelBuilder.Entity<UsuarioSolicitud>().HasKey(us => us.id_usuario_solicitud).HasName("id_usuario_solicitud_PK_CSTR");
            modelBuilder.Entity<UsuarioSolicitud>().HasOne(us => us.usuario).WithMany(u => u.usuario_solicitudes).
                HasForeignKey(us => us.id_usuario).HasConstraintName("id_usuario_us_FK_CSTR");
            modelBuilder.Entity<UsuarioSolicitud>().HasOne(us => us.solicitud).WithMany(s => s.usuario_solicitudes).
                HasForeignKey(us => us.id_solicitud).HasConstraintName("id_solicitud_FK_CSTR");

            //View VSolicitud Configuration:
            modelBuilder.Entity<VSolicitud>().ToTable("VSolicitud");
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.id).
            HasColumnName("id").HasColumnType("INT");
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.usuario).
            HasColumnName("usuario").HasColumnType("VARCHAR").HasMaxLength(70);
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.tipo).
            HasColumnName("tipo").HasColumnType("VARCHAR").HasMaxLength(30);
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.status).
            HasColumnName("status").HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.emision).
            HasColumnName("emision").HasColumnType("DATETIME2");
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.aprobacion).
            HasColumnName("aprobacion").HasColumnType("DATETIME2");

            //View VToken Configuration:
            modelBuilder.Entity<VToken>().ToTable("VToken");
            modelBuilder.Entity<VToken>().Property(vt => vt.id).
            HasColumnName("id").HasColumnType("INT");
            modelBuilder.Entity<VToken>().Property(vt => vt.codigo).
            HasColumnName("codigo").HasColumnType("VARCHAR").HasMaxLength(180);
            modelBuilder.Entity<VToken>().Property(vt => vt.emision).
            HasColumnName("emision").HasColumnType("DATETIME");
            modelBuilder.Entity<VToken>().Property(vt => vt.expiracion).
            HasColumnName("expiracion").HasColumnType("DATETIME");
            modelBuilder.Entity<VToken>().Property(vt => vt.usuario).
            HasColumnName("usuario").HasColumnType("VARCHAR").HasMaxLength(70);
        }
    }
}