using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrimeraWebApi.Models;

namespace PrimeraWebApi.Data;

public partial class CamionerosDbContext : DbContext
{
    public CamionerosDbContext()
    {
    }

    public CamionerosDbContext(DbContextOptions<CamionerosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Camione> Camiones { get; set; }

    public virtual DbSet<Camionero> Camioneros { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Materiale> Materiales { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCamione> UsuarioCamiones { get; set; }

    public virtual DbSet<UsuarioCamionero> UsuarioCamioneros { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    public virtual DbSet<VistaCamionerosMasDinero> VistaCamionerosMasDineros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Workstation Id=CamionerosDB.mssql.somee.com;Packet Size=4096;User Id=Luil_SQLLogin_1;Pwd=lurenny246;Data Source=CamionerosDB.mssql.somee.com;Persist Security Info=False;Initial Catalog=CamionerosDB;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Camione>(entity =>
        {
            entity.HasKey(e => e.IdCamion).HasName("PK__Camiones__91093EF0776570A0");

            entity.Property(e => e.IdCamion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Camion");
            entity.Property(e => e.IdCamionero).HasColumnName("ID_Camionero");
            entity.Property(e => e.MatriculaCamion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Matricula_Camion");

            entity.HasOne(d => d.IdCamioneroNavigation).WithMany(p => p.Camiones)
                .HasForeignKey(d => d.IdCamionero)
                .HasConstraintName("FK__Camiones__ID_Cam__52593CB8");
        });

        modelBuilder.Entity<Camionero>(entity =>
        {
            entity.HasKey(e => e.IdCamionero).HasName("PK__Camioner__90B5B215AD512CDC");

            entity.Property(e => e.IdCamionero)
                .ValueGeneratedNever()
                .HasColumnName("ID_Camionero");
            entity.Property(e => e.IdDocumento).HasColumnName("ID_Documento");
            entity.Property(e => e.NombreCamionero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Camionero");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.Camioneros)
                .HasForeignKey(d => d.IdDocumento)
                .HasConstraintName("FK__Camionero__ID_Do__4F7CD00D");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDocumento).HasName("PK__Document__B79DF372A3D40B83");

            entity.Property(e => e.IdDocumento)
                .ValueGeneratedNever()
                .HasColumnName("ID_Documento");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_Tipo_Documento");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Numero_Documento");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK__Documento__ID_Ti__4CA06362");
        });

        modelBuilder.Entity<Materiale>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PK__Material__A7F521BB18C24288");

            entity.Property(e => e.IdMaterial)
                .ValueGeneratedNever()
                .HasColumnName("ID_Material");
            entity.Property(e => e.NombreMaterial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Material");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__AE88B429E79FADB8");

            entity.HasIndex(e => e.IdViaje, "idx_Pagos_ID_Viaje");

            entity.Property(e => e.IdPago)
                .ValueGeneratedNever()
                .HasColumnName("ID_Pago");
            entity.Property(e => e.IdViaje).HasColumnName("ID_Viaje");
            entity.Property(e => e.MontoPagado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_Pagado");
            entity.Property(e => e.MontoPendiente)
                .HasComputedColumnSql("([Total_Pagar]-[Monto_Pagado])", false)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Monto_Pendiente");
            entity.Property(e => e.TotalPagar)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Pagar");

            entity.HasOne(d => d.IdViajeNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdViaje)
                .HasConstraintName("FK__Pagos__ID_Viaje__5AEE82B9");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__Tipo_Doc__AA55134746F5D261");

            entity.ToTable("Tipo_Documentos");

            entity.Property(e => e.IdTipoDocumento)
                .ValueGeneratedNever()
                .HasColumnName("ID_Tipo_Documento");
            entity.Property(e => e.NombreTipoDocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Tipo_Documento");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__DE4431C54D155716");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE08B187448").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(300);
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasDefaultValue("Usuario");
        });

        modelBuilder.Entity<UsuarioCamione>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdCamion }).HasName("PK__Usuario___C754A22A6AD84190");

            entity.ToTable("Usuario_Camiones");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.IdCamion).HasColumnName("ID_Camion");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdCamionNavigation).WithMany(p => p.UsuarioCamiones)
                .HasForeignKey(d => d.IdCamion)
                .HasConstraintName("FK_UCam_Camion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioCamiones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_UCam_Usuario");
        });

        modelBuilder.Entity<UsuarioCamionero>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdCamionero }).HasName("PK__Usuario___974F6AE4FA0D9340");

            entity.ToTable("Usuario_Camioneros");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.IdCamionero).HasColumnName("ID_Camionero");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdCamioneroNavigation).WithMany(p => p.UsuarioCamioneros)
                .HasForeignKey(d => d.IdCamionero)
                .HasConstraintName("FK_UC_Camionero");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioCamioneros)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_UC_Usuario");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.IdViaje).HasName("PK__Viajes__DBBCA144B7D1435F");

            entity.HasIndex(e => e.Fecha, "idx_Viajes_Fecha");

            entity.HasIndex(e => e.IdCamion, "idx_Viajes_ID_Camion");

            entity.Property(e => e.IdViaje)
                .ValueGeneratedNever()
                .HasColumnName("ID_Viaje");
            entity.Property(e => e.CantidadMaterial)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Cantidad_Material");
            entity.Property(e => e.Destino)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdCamion).HasColumnName("ID_Camion");
            entity.Property(e => e.IdMaterial).HasColumnName("ID_Material");
            entity.Property(e => e.Origen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalKilometros).HasColumnName("Total_Kilometros");

            entity.HasOne(d => d.IdCamionNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdCamion)
                .HasConstraintName("FK__Viajes__ID_Camio__571DF1D5");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdMaterial)
                .HasConstraintName("FK__Viajes__ID_Mater__5812160E");
        });

        modelBuilder.Entity<VistaCamionerosMasDinero>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vista_Camioneros_Mas_Dinero");

            entity.Property(e => e.IdCamionero).HasColumnName("ID_Camionero");
            entity.Property(e => e.NombreCamionero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Camionero");
            entity.Property(e => e.TotalGenerado)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Total_Generado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
