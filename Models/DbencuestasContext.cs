using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace appEncuestasEscolares.Models;

public partial class DbencuestasContext : DbContext
{
    public DbencuestasContext()
    {
    }

    public DbencuestasContext(DbContextOptions<DbencuestasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Encuestas> Encuestas { get; set; }

    public virtual DbSet<Preguntas> Preguntas { get; set; }

    public virtual DbSet<Rolesusuario> Rolesusuario { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=dbencuestas", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Encuestas>(entity =>
        {
            entity.HasKey(e => e.IdEncuesta).HasName("PRIMARY");

            entity.ToTable("encuestas");

            entity.Property(e => e.IdEncuesta).HasColumnName("idEncuesta");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.NombreEncuesta)
                .HasMaxLength(255)
                .HasColumnName("nombreEncuesta");
        });

        modelBuilder.Entity<Preguntas>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PRIMARY");

            entity.ToTable("preguntas");

            entity.HasIndex(e => e.IdEncuesta, "idEncuesta");

            entity.Property(e => e.IdPregunta).HasColumnName("idPregunta");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEncuesta).HasColumnName("idEncuesta");
            entity.Property(e => e.TextoPregunta)
                .HasMaxLength(1000)
                .HasColumnName("textoPregunta");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.Preguntas)
                .HasForeignKey(d => d.IdEncuesta)
                .HasConstraintName("preguntas_ibfk_1");
        });

        modelBuilder.Entity<Rolesusuario>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rolesusuario");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(45)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.RolId, "RolId");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.NumeroControl).HasMaxLength(45);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
