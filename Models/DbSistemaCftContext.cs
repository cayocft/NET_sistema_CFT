using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clases_Interfaces.Models;

public partial class DbSistemaCftContext : DbContext
{
    public DbSistemaCftContext()
    {
    }

    public DbSistemaCftContext(DbContextOptions<DbSistemaCftContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Matriculado> Matriculados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asignaturas");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Código)
                .HasColumnType("int(11)")
                .HasColumnName("código");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudiantes");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Edad)
                .HasColumnType("int(11)")
                .HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(45)
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Rut)
                .HasMaxLength(15)
                .HasColumnName("rut");
        });

        modelBuilder.Entity<Matriculado>(entity =>
        {
            entity.HasKey(e => new { e.IdEstudiante, e.IdAsignatura, e.IdPrimaryKey })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("matriculados");

            entity.Property(e => e.IdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("id_estudiante");
            entity.Property(e => e.IdAsignatura)
                .HasMaxLength(45)
                .HasColumnName("id_asignatura");
            entity.Property(e => e.IdPrimaryKey)
                .HasMaxLength(45)
                .HasColumnName("id_primary key");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
