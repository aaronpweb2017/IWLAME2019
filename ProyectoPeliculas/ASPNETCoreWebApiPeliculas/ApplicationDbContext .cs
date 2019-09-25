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
        public DbSet<Formato> formatos { get; set; }
        public DbSet<TipoResolucion> tiposResolucion { get; set; }
        public DbSet<ValorResolucion> valoresResolucion { get; set; }
        public DbSet<RelacionAspecto> relacionesAspecto { get; set; }
        public DbSet<Resolucion> resoluciones { get; set; }
        public DbSet<DetalleTecnico> detallesTecnicos { get; set; }
        public DbSet<Pelicula> peliculas { get; set; }
        public DbSet<TipoArchivo> tiposArchivo { get; set; }
        public DbSet<Servidor> servidores { get; set; }
        public DbSet<Descarga> descargas { get; set; }
        public DbSet<Enlace> enlaces { get; set; }
        public DbSet<VSolicitud> vSolicitudes { get; set; }
        public DbSet<VToken> vTokens { get; set; }
        public DbSet<VResolucion> vResoluciones { get; set; }
        public DbSet<VDetalleTecnico> vDetallesTecnicos { get; set; }
        public DbSet<VDescarga> vDescargas { get; set; }
        
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
            HasColumnName("emision_token").HasColumnType("DATETIME2").IsRequired();
            modelBuilder.Entity<Token>().Property(t => t.expiracion_token).
            HasColumnName("expiracion_token").HasColumnType("DATETIME2").IsRequired();
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

            //Table Pelicula Configuration:
            modelBuilder.Entity<Pelicula>().ToTable("Pelicula");
            modelBuilder.Entity<Pelicula>().Property(p => p.id_pelicula).
            HasColumnName("id_pelicula").HasColumnType("INT");
            modelBuilder.Entity<Pelicula>().Property(p => p.nombre_pelicula).
            HasColumnName("nombre_pelicula").HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Pelicula>().Property(p => p.fecha_estreno).
            HasColumnName("fecha_estreno").HasColumnType("DATETIME2").IsRequired();
            modelBuilder.Entity<Pelicula>().Property(p => p.presupuesto).
            HasColumnName("presupuesto").HasColumnType("MONEY");
            modelBuilder.Entity<Pelicula>().Property(p => p.recaudacion).
            HasColumnName("recaudacion").HasColumnType("MONEY");
            modelBuilder.Entity<Pelicula>().Property(p => p.sinopsis).
            HasColumnName("sinopsis").HasColumnType("VARCHAR").HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Pelicula>().Property(p => p.calificacion).
            HasColumnName("calificacion").HasColumnType("DECIMAL(6,3)");
            modelBuilder.Entity<Pelicula>().Property(p => p.id_detalle).
            HasColumnName("id_detalle").HasColumnType("INT");
            modelBuilder.Entity<Pelicula>().HasKey(p => p.id_pelicula).HasName("id_pelicula_PK_CSTR");
            modelBuilder.Entity<Pelicula>().HasOne<DetalleTecnico>(p => p.detalleTecnico).
            WithMany(dt => dt.peliculas).HasForeignKey(p => p.id_detalle).HasConstraintName("id_detalle_FK_CSTR");

            //Table TipoArchivo Configuration:
            modelBuilder.Entity<TipoArchivo>().ToTable("TipoArchivo");
            modelBuilder.Entity<TipoArchivo>().Property(ta => ta.id_tipo_archivo).
            HasColumnName("id_tipo_archivo").HasColumnType("INT");
            modelBuilder.Entity<TipoArchivo>().Property(ta => ta.nombre_tipo_archivo).
            HasColumnName("nombre_tipo_archivo").HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<TipoArchivo>().HasKey(ta => ta.id_tipo_archivo).HasName("id_tipo_archivo_PK_CSTR");

            //Table Servidor Configuration:
            modelBuilder.Entity<Servidor>().ToTable("Servidor");
            modelBuilder.Entity<Servidor>().Property(s => s.id_servidor).
            HasColumnName("id_servidor").HasColumnType("INT");
            modelBuilder.Entity<Servidor>().Property(s => s.nombre_servidor).
            HasColumnName("nombre_servidor").HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Servidor>().Property(s => s.sitio_servidor).
            HasColumnName("sitio_servidor ").HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Servidor>().HasKey(s => s.id_servidor).HasName("id_servidor_PK_CSTR");

            //Table Descarga Configuration:
            modelBuilder.Entity<Descarga>().ToTable("Descarga");
            modelBuilder.Entity<Descarga>().Property(d => d.id_descarga).
            HasColumnName("id_descarga").HasColumnType("INT");
            modelBuilder.Entity<Descarga>().Property(d => d.password_descarga).
            HasColumnName("password_descarga").HasColumnType("VARCHAR").HasMaxLength(32);
            modelBuilder.Entity<Descarga>().Property(d => d.id_tipo_archivo).
            HasColumnName("id_tipo_archivo").HasColumnType("INT");
            modelBuilder.Entity<Descarga>().Property(d => d.id_servidor).
            HasColumnName("id_servidor").HasColumnType("INT");
            modelBuilder.Entity<Descarga>().Property(d => d.id_pelicula).
            HasColumnName("id_pelicula").HasColumnType("INT");
            modelBuilder.Entity<Descarga>().HasKey(d => d.id_descarga).HasName("id_descarga_PK_CSTR");
            modelBuilder.Entity<Descarga>().HasOne<TipoArchivo>(d => d.tipoArchivo).
            WithMany(ta => ta.descargas).HasForeignKey(d => d.id_tipo_archivo).HasConstraintName("id_tipo_archivo_FK_CSTR");
            modelBuilder.Entity<Descarga>().HasOne<Servidor>(d => d.servidor).
            WithMany(s => s.descargas).HasForeignKey(d => d.id_servidor).HasConstraintName("id_servidor_FK_CSTR");
            modelBuilder.Entity<Descarga>().HasOne<Pelicula>(d => d.pelicula).
            WithMany(p => p.descargas).HasForeignKey(d => d.id_pelicula).HasConstraintName("id_pelicula_FK_CSTR");

            //Table Enlace Configuration:
            modelBuilder.Entity<Enlace>().ToTable("Enlace");
            modelBuilder.Entity<Enlace>().Property(e => e.id_enlace).
            HasColumnName("id_enlace").HasColumnType("INT");
            modelBuilder.Entity<Enlace>().Property(e => e.valor_enlace).
            HasColumnName("valor_enlace").HasColumnType("VARCHAR").HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Enlace>().Property(e => e.status_enlace).
            HasColumnName("status_enlace").HasColumnType("INT").IsRequired();
            modelBuilder.Entity<Enlace>().Property(e => e.id_descarga).
            HasColumnName("id_descarga").HasColumnType("INT");
            modelBuilder.Entity<Enlace>().HasKey(e => e.id_enlace).HasName("id_enlace_PK_CSTR");
            modelBuilder.Entity<Enlace>().HasOne<Descarga>(e => e.descarga).
            WithMany(d => d.enlaces).HasForeignKey(e => e.id_descarga).HasConstraintName("id_descarga_FK_CSTR");

            //View VSolicitud Configuration:
            modelBuilder.Entity<VSolicitud>().ToTable("VSolicitud");
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.id_usuario_solicitud).
            HasColumnName("id_usuario_solicitud").HasColumnType("INT");
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.nombre_usuario).
            HasColumnName("nombre_usuario").HasColumnType("VARCHAR").HasMaxLength(70);
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.nombre_solicitud).
            HasColumnName("nombre_solicitud").HasColumnType("VARCHAR").HasMaxLength(30);
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.status_solicitud).
            HasColumnName("status_solicitud").HasColumnType("INT");
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.emision_solicitud).
            HasColumnName("emision_solicitud").HasColumnType("DATETIME2");
            modelBuilder.Entity<VSolicitud>().Property(vs => vs.aprobacion_solicitud).
            HasColumnName("aprobacion_solicitud").HasColumnType("DATETIME2");
            modelBuilder.Entity<VSolicitud>().HasKey(vs => vs.id_usuario_solicitud);

            //View VToken Configuration:
            modelBuilder.Entity<VToken>().ToTable("VToken");
            modelBuilder.Entity<VToken>().Property(vt => vt.id_token).
            HasColumnName("id_token").HasColumnType("INT");
            modelBuilder.Entity<VToken>().Property(vt => vt.valor_token).
            HasColumnName("valor_token").HasColumnType("VARCHAR").HasMaxLength(180);
            modelBuilder.Entity<VToken>().Property(vt => vt.emision_token).
            HasColumnName("emision_token").HasColumnType("DATETIME2");
            modelBuilder.Entity<VToken>().Property(vt => vt.expiracion_token).
            HasColumnName("expiracion_token").HasColumnType("DATETIME2");
            modelBuilder.Entity<VToken>().Property(vt => vt.nombre_usuario).
            HasColumnName("nombre_usuario").HasColumnType("VARCHAR").HasMaxLength(70);
            modelBuilder.Entity<VToken>().HasKey(vt => vt.id_token);

            //View VResolucion Configuration:
            modelBuilder.Entity<VResolucion>().ToTable("VResolucion");
            modelBuilder.Entity<VResolucion>().Property(vr => vr.id_tipo_resolucion).
            HasColumnName("id_tipo_resolucion").HasColumnType("INT");
            modelBuilder.Entity<VResolucion>().Property(vr => vr.nombre_tipo_resolucion).
            HasColumnName("nombre_tipo_resolucion").HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<VResolucion>().Property(vr => vr.id_valor_resolucion).
            HasColumnName("id_valor_resolucion").HasColumnType("INT");
            modelBuilder.Entity<VResolucion>().Property(vr => vr.valor_resolucion).
            HasColumnName("valor_resolucion").HasColumnType("VARCHAR").HasMaxLength(10);    
            modelBuilder.Entity<VResolucion>().Property(vr => vr.id_relacion_aspecto).
            HasColumnName("id_relacion_aspecto").HasColumnType("INT");  
            modelBuilder.Entity<VResolucion>().Property(vr => vr.valor_relacion_aspecto).
            HasColumnName("valor_relacion_aspecto").HasColumnType("VARCHAR").HasMaxLength(10);
            modelBuilder.Entity<VResolucion>().HasKey(vr => new {vr.id_tipo_resolucion, vr.id_valor_resolucion, vr.id_relacion_aspecto});
            
            //View VDetalleTecnico Configuration:
            modelBuilder.Entity<VDetalleTecnico>().ToTable("VDetalleTecnico");
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.id_detalle).
            HasColumnName("id_detalle").HasColumnType("INT");
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.id_formato).
            HasColumnName("id_formato").HasColumnType("INT");
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.nombre_formato).
            HasColumnName("nombre_formato").HasColumnType("VARCHAR").HasMaxLength(10);
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.id_tipo_resolucion).
            HasColumnName("id_tipo_resolucion").HasColumnType("INT");
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.nombre_tipo_resolucion).
            HasColumnName("nombre_tipo_resolucion").HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.id_valor_resolucion).
            HasColumnName("id_valor_resolucion").HasColumnType("INT");
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.valor_resolucion).
            HasColumnName("valor_resolucion").HasColumnType("VARCHAR").HasMaxLength(10);    
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.id_relacion_aspecto).
            HasColumnName("id_relacion_aspecto").HasColumnType("INT");  
            modelBuilder.Entity<VDetalleTecnico>().Property(dt => dt.valor_relacion_aspecto).
            HasColumnName("valor_relacion_aspecto").HasColumnType("VARCHAR").HasMaxLength(10);
            modelBuilder.Entity<VDetalleTecnico>().HasKey(dt => dt.id_detalle);
            
            //View VDetalleTecnico Configuration:
            modelBuilder.Entity<VDescarga>().ToTable("VDescarga");
            modelBuilder.Entity<VDescarga>().Property(d => d.id_descarga).
            HasColumnName("id_descarga").HasColumnType("INT");
            modelBuilder.Entity<VDescarga>().Property(d => d.password_descarga).
            HasColumnName("password_descarga").HasColumnType("VARCHAR").HasMaxLength(32);
            modelBuilder.Entity<VDescarga>().Property(d => d.id_tipo_archivo).
            HasColumnName("id_tipo_archivo").HasColumnType("INT");
            modelBuilder.Entity<VDescarga>().Property(d => d.nombre_tipo_archivo).
            HasColumnName("nombre_tipo_archivo").HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<VDescarga>().Property(d => d.id_servidor).
            HasColumnName("id_servidor").HasColumnType("INT");
            modelBuilder.Entity<VDescarga>().Property(d => d.nombre_servidor).
            HasColumnName("nombre_servidor").HasColumnType("VARCHAR").HasMaxLength(20);    
            modelBuilder.Entity<VDescarga>().Property(d => d.id_pelicula).
            HasColumnName("id_pelicula").HasColumnType("INT");  
            modelBuilder.Entity<VDescarga>().Property(d => d.nombre_pelicula).
            HasColumnName("nombre_pelicula").HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<VDescarga>().HasKey(d => d.id_descarga);
        }
    }
}