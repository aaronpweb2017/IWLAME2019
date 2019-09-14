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
        public DbSet<TipoResolucion> tiposResolucion { get; set; }
        public DbSet<ValorResolucion> valoresResolucion { get; set; }
        public DbSet<RelacionAspecto> relacionesAspecto { get; set; }
        public DbSet<Resolucion> resoluciones { get; set; }
        public DbSet<Formato> formatos { get; set; }
        public DbSet<DetalleTecnico> detallesTecnicos { get; set; }
        public DbSet<VSolicitud> vSolicitudes { get; set; }
        public DbSet<VToken> vTokens { get; set; }
        public DbSet<VResolucion> vResoluciones { get; set; }
        public DbSet<VDetalleTecnico> vDetallesTecnicos { get; set; }
        
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

            //Table Formato Configuration:
            modelBuilder.Entity<Formato>().ToTable("Formato");
            modelBuilder.Entity<Formato>().Property(f => f.id_formato).
            HasColumnName("id_formato").HasColumnType("INT");
            modelBuilder.Entity<Formato>().Property(f => f.nombre_formato).
            HasColumnName("nombre_formato").HasColumnType("VARCHAR").HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Formato>().HasKey(f => f.id_formato).HasName("id_formato_PK_CSTR");

            //Table TipoResolucion Configuration:
            modelBuilder.Entity<TipoResolucion>().ToTable("TipoResolucion");
            modelBuilder.Entity<TipoResolucion>().Property(tr => tr.id_tipo_resolucion).
            HasColumnName("id_tipo_resolucion").HasColumnType("INT");
            modelBuilder.Entity<TipoResolucion>().Property(tr => tr.nombre_tipo_resolucion).
            HasColumnName("nombre_tipo_resolucion").HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<TipoResolucion>().Property(tr => tr.porcentaje_visualizacion).
            HasColumnName("porcentaje_visualizacion").HasColumnType("DECIMAL(6,3)").IsRequired();
            modelBuilder.Entity<TipoResolucion>().Property(tr => tr.porcentaje_perdida).
            HasColumnName("porcentaje_perdida").HasColumnType("DECIMAL(6,3)").IsRequired();
            modelBuilder.Entity<TipoResolucion>().HasKey(tr => tr.id_tipo_resolucion).HasName("id_tipo_resolucion_PK_CSTR");

            //Table ValorResolucion Configuration:
            modelBuilder.Entity<ValorResolucion>().ToTable("ValorResolucion");
            modelBuilder.Entity<ValorResolucion>().Property(vr => vr.id_valor_resolucion).
            HasColumnName("id_valor_resolucion").HasColumnType("INT");
            modelBuilder.Entity<ValorResolucion>().Property(vr => vr.valor_resolucion).
            HasColumnName("valor_resolucion").HasColumnType("VARCHAR").HasMaxLength(10).IsRequired();
            modelBuilder.Entity<ValorResolucion>().HasKey(vr => vr.id_valor_resolucion).HasName("id_valor_resolucion_PK_CSTR");
            
            //Table RelacionAspecto Configuration:
            modelBuilder.Entity<RelacionAspecto>().ToTable("RelacionAspecto");
            modelBuilder.Entity<RelacionAspecto>().Property(ra => ra.id_relacion_aspecto).
            HasColumnName("id_relacion_aspecto").HasColumnType("INT");
            modelBuilder.Entity<RelacionAspecto>().Property(ra => ra.valor_relacion_aspecto).
            HasColumnName("valor_relacion_aspecto").HasColumnType("VARCHAR").HasMaxLength(10).IsRequired();
            modelBuilder.Entity<RelacionAspecto>().HasKey(ra => ra.id_relacion_aspecto).HasName("id_relacion_aspecto_PK_CSTR");

            //Table Resolucion Configuration:
            modelBuilder.Entity<Resolucion>().ToTable("Resolucion");
            modelBuilder.Entity<Resolucion>().Property(r => r.id_tipo_resolucion).
            HasColumnName("id_tipo_resolucion").HasColumnType("INT");
            modelBuilder.Entity<Resolucion>().Property(r => r.id_valor_resolucion).
            HasColumnName("id_valor_resolucion").HasColumnType("INT");
            modelBuilder.Entity<Resolucion>().Property(r => r.id_relacion_aspecto).
            HasColumnName("id_relacion_aspecto").HasColumnType("INT");
            modelBuilder.Entity<Resolucion>().HasKey(r => new {r.id_tipo_resolucion,
            r.id_valor_resolucion, r.id_relacion_aspecto}).HasName("id_tipo_valor_relacion_PK_CSTR");
            modelBuilder.Entity<Resolucion>().HasOne(r => r.tipoResolucion).WithMany(tr => tr.resoluciones).
            HasForeignKey(r => r.id_tipo_resolucion).HasConstraintName("id_tipo_resolucion_FK_CSTR");
            modelBuilder.Entity<Resolucion>().HasOne(r => r.valorResolucion).WithMany(vr => vr.resoluciones).
            HasForeignKey(r => r.id_valor_resolucion).HasConstraintName("id_valor_resolucion_FK_CSTR");
            modelBuilder.Entity<Resolucion>().HasOne(r => r.relacionAspecto).WithMany(ra => ra.resoluciones).
            HasForeignKey(r => r.id_relacion_aspecto).HasConstraintName("id_relacion_aspecto_FK_CSTR");

            //Table DetalleTecnico Configuration:
            modelBuilder.Entity<DetalleTecnico>().ToTable("DetalleTecnico");
            modelBuilder.Entity<DetalleTecnico>().Property(dt => dt.id_detalle).
            HasColumnName("id_detalle").HasColumnType("INT");
            modelBuilder.Entity<DetalleTecnico>().Property(dt => dt.id_formato).
            HasColumnName("id_formato").HasColumnType("INT");
            modelBuilder.Entity<DetalleTecnico>().Property(dt => dt.id_tipo_resolucion).
            HasColumnName("id_tipo_resolucion").HasColumnType("INT");
            modelBuilder.Entity<DetalleTecnico>().Property(dt => dt.id_valor_resolucion).
            HasColumnName("id_valor_resolucion").HasColumnType("INT");
            modelBuilder.Entity<DetalleTecnico>().Property(dt => dt.id_relacion_aspecto).
            HasColumnName("id_relacion_aspecto").HasColumnType("INT");
            modelBuilder.Entity<DetalleTecnico>().HasKey(dt => dt.id_detalle).HasName("id_detalle_PK_CSTR");
            modelBuilder.Entity<DetalleTecnico>().HasOne(dt => dt.formato).WithMany(f => f.detallesTecnicos).
            HasForeignKey(dt => dt.id_formato).HasConstraintName("id_formato_FK_CSTR");
            modelBuilder.Entity<DetalleTecnico>().HasOne(dt => dt.resolucion).WithMany(r => r.detallesTecnicos).
            HasForeignKey(dt => new {dt.id_tipo_resolucion, dt.id_valor_resolucion,
            dt.id_relacion_aspecto}).HasConstraintName("id_tipo_valor_relacion_FK_CSTR");

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

            //View VResolucion Configuration:
            modelBuilder.Entity<VResolucion>().ToTable("VResolucion");
            modelBuilder.Entity<VResolucion>().Property(vr => vr.tipo).
            HasColumnName("tipo").HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<VResolucion>().Property(vr => vr.valor).
            HasColumnName("valor").HasColumnType("VARCHAR").HasMaxLength(10);
            modelBuilder.Entity<VResolucion>().Property(vr => vr.aspecto).
            HasColumnName("aspecto").HasColumnType("VARCHAR").HasMaxLength(10);
            modelBuilder.Entity<VResolucion>().HasKey(vr => new {vr.tipo, vr.valor, vr.aspecto});
            
            //View VDetalleTecnico Configuration:
            modelBuilder.Entity<VDetalleTecnico>().ToTable("VDetalleTecnico");
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.id).
            HasColumnName("id").HasColumnType("INT");
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.formato).
            HasColumnName("formato").HasColumnType("VARCHAR").HasMaxLength(10);
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.tipo).
            HasColumnName("tipo").HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.valor).
            HasColumnName("valor").HasColumnType("VARCHAR").HasMaxLength(10);
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.aspecto).
            HasColumnName("aspecto").HasColumnType("VARCHAR").HasMaxLength(10);
        }
    }
}