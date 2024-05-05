using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PracticaNum6.Models
{
    public partial class CitaMedicaContext : DbContext
    {
        public CitaMedicaContext()
        {
        }

        public CitaMedicaContext(DbContextOptions<CitaMedicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Medico> Medicos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("server=TEFOMSI2; database=CitaMedica; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Citas__7C17FD1663EA7388");

                entity.Property(e => e.IdCita).HasColumnName("ID_Cita");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Hora");

                entity.Property(e => e.IdMedico).HasColumnName("ID_Medico");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

                entity.Property(e => e.Motivo).HasMaxLength(200);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Citas__ID_Medico__3C69FB99");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Citas__ID_Pacien__3B75D760");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medicos__EFBF88F79CB48228");

                entity.Property(e => e.IdMedico).HasColumnName("ID_Medico");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Especialidad).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(15);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__5F3650615FD416A1");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
