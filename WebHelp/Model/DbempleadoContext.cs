using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebHelp.Model;

public partial class DbempleadoContext : DbContext
{
    public DbempleadoContext()
    {
    }

    public DbempleadoContext(DbContextOptions<DbempleadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pais> Pais { get; set; }
    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Subarea> Subareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__Area__2FC141AA44C2C97B");

            entity.ToTable("Area");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E8B4923BE");

            entity.ToTable("Empleado");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaContrato)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Contrato");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_Documento");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK__Empleado__IdArea__5535A963");

            entity.HasOne(d => d.IdSubareaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdSubarea)
                .HasConstraintName("FK__Empleado__IdSuba__5629CD9C");
        });

        modelBuilder.Entity<Subarea>(entity =>
        {
            entity.HasKey(e => e.IdSubarea).HasName("PK__Subarea__97DC331433C95731");

            entity.ToTable("Subarea");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
