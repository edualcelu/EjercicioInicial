
using arquetipo.Entity.Dto;
using arquetipo.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace arquetipo.Repository.Context
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; } = null!;
         public virtual DbSet<AsignaCliente> AsignaClientes { get; set; } = null!;
        public virtual DbSet<Automovil> Automovils { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Ejecutivo> Ejecutivos { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<PatioAuto> PatioAutos { get; set; } = null!;
        public virtual DbSet<SolicitudCredito> SolicitudCreditos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AsignaCliente>(entity =>
            {
                entity.HasKey(e => e.AcIDAsignaCliente)
                    .HasName("PK__Asignacion_Cliente");

                entity.Property(e => e.AcIDAsignaCliente).HasColumnName("ac_ID_asigna_cliente");

                entity.ToTable("Asigna_Cliente");

                entity.Property(e => e.AcFechaAsignacion)
                    .HasColumnType("datetime")
                    .HasColumnName("ac_Fecha_Asignacion");

                entity.Property(e => e.AcIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ac_Identificacion");

                entity.Property(e => e.AcNumeroPatio).HasColumnName("ac_Numero_Patio");

                entity.HasOne(d => d.AcIdentificacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AcIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacion_Cliente");

                entity.HasOne(d => d.AcNumeroPatioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AcNumeroPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacion_Patio");
            });

            modelBuilder.Entity<Automovil>(entity =>
            {
                entity.HasKey(e => e.AuPlaca)
                    .HasName("PK__Automovi__E78A12B60E85D82D");

                entity.ToTable("Automovil");

                entity.Property(e => e.AuPlaca)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("au_Placa");

                entity.Property(e => e.AuAvaluo)
                    .HasColumnType("money")
                    .HasColumnName("au_Avaluo");

                entity.Property(e => e.AuCilindraje)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("au_Cilindraje");

                entity.Property(e => e.AuCodigoMarca).HasColumnName("au_Codigo_Marca");

                entity.Property(e => e.AuModelo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("au_Modelo");

                entity.Property(e => e.AuNumeroChasis)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("au_Numero_Chasis");

                entity.Property(e => e.AuTipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("au_Tipo");

                entity.HasOne(d => d.AuCodigoMarcaNavigation)
                    .WithMany(p => p.Automovils)
                    .HasForeignKey(d => d.AuCodigoMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Automoil_Marca");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClIdentificacion)
                    .HasName("PK__Cliente__4E3FBF169D0E35A5");

                entity.ToTable("Cliente");

                entity.Property(e => e.ClIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cl_Identificacion");

                entity.Property(e => e.ClApellidos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cl_Apellidos");

                entity.Property(e => e.ClDireccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cl_Direccion");

                entity.Property(e => e.ClEdad).HasColumnName("cl_Edad");

                entity.Property(e => e.ClEstadoCivil)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_Estado_Civil");

                entity.Property(e => e.ClFechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("cl_Fecha_Nacimiento");

                entity.Property(e => e.ClIdentificacionConyuge)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cl_Identificacion_Conyuge");

                entity.Property(e => e.ClNombreConyuge)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cl_Nombre_Conyuge");

                entity.Property(e => e.ClNombres)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cl_Nombres");

                entity.Property(e => e.ClSujetoCredito).HasColumnName("cl_Sujeto_Credito");

                entity.Property(e => e.ClTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cl_Telefono");
            });

            modelBuilder.Entity<Ejecutivo>(entity =>
            {
                entity.HasKey(e => e.EIdentificacion)
                    .HasName("PK__Ejecutiv__AF45F611ECF084C8");

                entity.ToTable("Ejecutivo");

                entity.Property(e => e.EIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("e_Identificacion");

                entity.Property(e => e.EApellidos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("e_Apellidos");

                entity.Property(e => e.ECelular)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("e_Celular");

                entity.Property(e => e.EDireccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("e_Direccion");

                entity.Property(e => e.EEdad).HasColumnName("e_Edad");

                entity.Property(e => e.ENombres)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("e_Nombres");

                entity.Property(e => e.ENumeroPatio).HasColumnName("e_Numero_Patio");

                entity.Property(e => e.ETelefonoConvencional)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("e_Telefono_Convencional");

                entity.HasOne(d => d.ENumeroPatioNavigation)
                    .WithMany(p => p.Ejecutivos)
                    .HasForeignKey(d => d.ENumeroPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ejecutivo_Patio");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MaCodigo)
                    .HasName("PK__Marca__770238F2A4B62853");

                entity.ToTable("Marca");

                entity.Property(e => e.MaCodigo).HasColumnName("ma_Codigo");

                entity.Property(e => e.MaNombreMarca)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ma_Nombre_Marca");
            });

            modelBuilder.Entity<PatioAuto>(entity =>
            {
                entity.HasKey(e => e.PaNumeroPatio)
                    .HasName("PK__Patio_Au__44A736C0439EF230");

                entity.ToTable("Patio_Autos");

                entity.Property(e => e.PaNumeroPatio).HasColumnName("pa_Numero_Patio");

                entity.Property(e => e.PaDireccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pa_Direccion");

                entity.Property(e => e.PaNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pa_Nombre");

                entity.Property(e => e.PaTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pa_Telefono");
            });

            modelBuilder.Entity<SolicitudCredito>(entity =>
            {
                entity.HasKey(e => e.ScIdSolicitudCredito)
                    .HasName("PK__Solicitud_Credito");

                entity.ToTable("Solicitud_Credito");

                entity.Property(e => e.ScCuotas).HasColumnName("sc_Cuotas");

                entity.Property(e => e.ScEntrada)
                    .HasColumnType("money")
                    .HasColumnName("sc_Entrada");

                entity.Property(e => e.ScFechaElaboracion)
                    .HasColumnType("datetime")
                    .HasColumnName("sc_Fecha_Elaboracion");

                entity.Property(e => e.ScIdSolicitudCredito)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sc_ID_Solicitud_Credito");

                entity.Property(e => e.ScIdentificacionCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sc_Identificacion_Cliente");

                entity.Property(e => e.ScIdentificacionEjecutivo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sc_Identificacion_Ejecutivo");

                entity.Property(e => e.ScMesesPlazo).HasColumnName("sc_Meses_Plazo");

                entity.Property(e => e.ScNumeroPatio).HasColumnName("sc_Numero_Patio");

                entity.Property(e => e.ScObservacion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sc_Observacion");

                entity.Property(e => e.ScPlaca)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sc_Placa");

                entity.Property(e => e.ScEstadoSolicitud)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sc_Estado_Solicitud");
                

                entity.Property(e => e.ScSolicitudActiva).HasColumnName("sc_Solicitud_activa");

                entity.HasOne(d => d.ScIdentificacionClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ScIdentificacionCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Cliente");

                entity.HasOne(d => d.ScIdentificacionEjecutivoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ScIdentificacionEjecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Ejecutivo");

                entity.HasOne(d => d.ScNumeroPatioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ScNumeroPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Patio");

                entity.HasOne(d => d.ScPlacaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ScPlaca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Vehiculo");
            });
        }
    }
}
