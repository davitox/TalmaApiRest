using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Talma.Core.Entities;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Evaluacion> Evaluacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=SYSTEM;Password=Oracl321/*-;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe)));");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008316");

            entity.ToTable("ESTUDIANTE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.Edad)
                .HasPrecision(3)
                .HasColumnName("EDAD");
            entity.Property(e => e.FechaHoraModificacion)
                .HasPrecision(6)
                .HasColumnName("FECHA_HORA_MODIFICACION");
            entity.Property(e => e.FechaHoraRegistro)
                .HasPrecision(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP\n")
                .HasColumnName("FECHA_HORA_REGISTRO");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_COMPLETO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.NumDocumentoIdentidad)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("NUM_DOCUMENTO_IDENTIDAD");
        });

        modelBuilder.Entity<Evaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008321");

            entity.ToTable("EVALUACION");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.FechaHoraModificacion)
                .HasPrecision(6)
                .HasColumnName("FECHA_HORA_MODIFICACION");
            entity.Property(e => e.FechaHoraRegistro)
                .HasPrecision(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("FECHA_HORA_REGISTRO");
            entity.Property(e => e.IdUsuario)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Nota1)
                .HasColumnType("NUMBER(4,2)")
                .HasColumnName("NOTA1");
            entity.Property(e => e.Nota2)
                .HasColumnType("NUMBER(4,2)")
                .HasColumnName("NOTA2");
            entity.Property(e => e.Nota3)
                .HasColumnType("NUMBER(4,2)")
                .HasColumnName("NOTA3");
            entity.Property(e => e.Promedio)
                .HasColumnType("NUMBER(4,2)")
                .HasColumnName("PROMEDIO");
        });
        modelBuilder.HasSequence("LOGMNR_DIDS$");
        modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");
        modelBuilder.HasSequence("LOGMNR_SEQ$");
        modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");
        modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
