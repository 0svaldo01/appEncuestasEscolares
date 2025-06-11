using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace appEncuestasEscolares.Models;

public partial class EndbContext : DbContext
{
    public EndbContext()
    {
    }

    public EndbContext(DbContextOptions<EndbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Encuestas> Encuestas { get; set; }

    public virtual DbSet<Preguntas> Preguntas { get; set; }

    public virtual DbSet<RespuestasDetalle> RespuestasDetalle { get; set; }

    public virtual DbSet<RespuestasEncuesta> RespuestasEncuesta { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<VDashboardEncuestas> VDashboardEncuestas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=endb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Encuestas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("encuestas");

            entity.HasIndex(e => e.Aplicada, "idx_aplicada");

            entity.HasIndex(e => e.CreadoPorId, "idx_creado_por");

            entity.HasIndex(e => e.Eliminada, "idx_eliminada");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aplicada)
                .HasDefaultValueSql("'0'")
                .HasColumnName("aplicada");
            entity.Property(e => e.CreadoPorId).HasColumnName("creado_por_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Eliminada)
                .HasDefaultValueSql("'0'")
                .HasColumnName("eliminada");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CreadoPor).WithMany(p => p.Encuestas)
                .HasForeignKey(d => d.CreadoPorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("encuestas_ibfk_1");
        });

        modelBuilder.Entity<Preguntas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("preguntas");

            entity.HasIndex(e => new { e.EncuestaId, e.Orden }, "idx_encuesta_orden");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EncuestaId).HasColumnName("encuesta_id");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.TextoPregunta)
                .HasColumnType("text")
                .HasColumnName("texto_pregunta");

            entity.HasOne(d => d.Encuesta).WithMany(p => p.Preguntas)
                .HasForeignKey(d => d.EncuestaId)
                .HasConstraintName("preguntas_ibfk_1");
        });

        modelBuilder.Entity<RespuestasDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("respuestas_detalle");

            entity.HasIndex(e => e.Calificacion, "idx_calificacion");

            entity.HasIndex(e => e.PreguntaId, "pregunta_id");

            entity.HasIndex(e => new { e.RespuestaEncuestaId, e.PreguntaId }, "uk_respuesta_pregunta").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.PreguntaId).HasColumnName("pregunta_id");
            entity.Property(e => e.RespuestaEncuestaId).HasColumnName("respuesta_encuesta_id");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.RespuestasDetalle)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("respuestas_detalle_ibfk_2");

            entity.HasOne(d => d.RespuestaEncuesta).WithMany(p => p.RespuestasDetalle)
                .HasForeignKey(d => d.RespuestaEncuestaId)
                .HasConstraintName("respuestas_detalle_ibfk_1");
        });

        modelBuilder.Entity<RespuestasEncuesta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("respuestas_encuesta");

            entity.HasIndex(e => e.AplicadaPorId, "idx_aplicada_por");

            entity.HasIndex(e => e.FechaRespuesta, "idx_fecha_respuesta");

            entity.HasIndex(e => e.NumeroControl, "idx_numero_control");

            entity.HasIndex(e => new { e.EncuestaId, e.NumeroControl }, "uk_encuesta_control").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AplicadaPorId).HasColumnName("aplicada_por_id");
            entity.Property(e => e.EncuestaId).HasColumnName("encuesta_id");
            entity.Property(e => e.FechaRespuesta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_respuesta");
            entity.Property(e => e.NombreEstudiante)
                .HasMaxLength(100)
                .HasColumnName("nombre_estudiante");
            entity.Property(e => e.NumeroControl)
                .HasMaxLength(20)
                .HasColumnName("numero_control");

            entity.HasOne(d => d.AplicadaPor).WithMany(p => p.RespuestasEncuesta)
                .HasForeignKey(d => d.AplicadaPorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("respuestas_encuesta_ibfk_2");

            entity.HasOne(d => d.Encuesta).WithMany(p => p.RespuestasEncuesta)
                .HasForeignKey(d => d.EncuestaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("respuestas_encuesta_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Rol, "idx_rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Rol)
                .HasDefaultValueSql("'Encuestador'")
                .HasColumnType("enum('Encuestador','Encuestado')")
                .HasColumnName("rol");
        });

        modelBuilder.Entity<VDashboardEncuestas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_dashboard_encuestas");

            entity.Property(e => e.Aplicada)
                .HasDefaultValueSql("'0'")
                .HasColumnName("aplicada");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(100)
                .HasColumnName("creado_por");
            entity.Property(e => e.Eliminada)
                .HasDefaultValueSql("'0'")
                .HasColumnName("eliminada");
            entity.Property(e => e.EncuestadoresActivos).HasColumnName("encuestadores_activos");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");
            entity.Property(e => e.TotalRespuestas).HasColumnName("total_respuestas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
