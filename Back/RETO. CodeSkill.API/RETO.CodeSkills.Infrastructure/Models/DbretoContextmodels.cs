using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RETO.CodeSkills.Domain.Entities;

namespace RETO._CodeSkill.API.Models;

public partial class DbretoContextmodels : DbContext
{
    public DbretoContextmodels()
    {
    }

    public DbretoContextmodels(DbContextOptions<DbretoContextmodels> options)
        : base(options)
    {
    }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<LoginUsuario> LoginUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LUISAHERRERA\\SQLEXPRESS;DataBase=DBRETO;Integrated Security=True;TrustServerCertificate=true; Trusted_Connection= True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__docente__3213E83FAD10E878");

            entity.ToTable("docente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApellidoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_docente");
            entity.Property(e => e.CiudadResidenciaDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad_residencia_docente");
            entity.Property(e => e.CorreoElectronicoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_electronico_docente");
            entity.Property(e => e.EscalafonExtensionDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("escalafon_extension_docente");
            entity.Property(e => e.EscalafonTecnicoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("escalafon_tecnico_docente");
            entity.Property(e => e.IdentificacionDocente).HasColumnName("identificacion_docente");
            entity.Property(e => e.NombreDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_docente");
            entity.Property(e => e.NumeroContratoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_contrato_docente");
            entity.Property(e => e.TelefonoCelularDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono_celular_docente");
            entity.Property(e => e.TipoIdentificacionDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_identificacion_docente");
        });

        modelBuilder.Entity<LoginUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__login_us__4E3E04AD662239C4");

            entity.ToTable("login_usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ContraseñaUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseña_usuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
