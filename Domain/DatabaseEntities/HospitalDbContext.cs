using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Domain.DatabaseEntities;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointments> Appointments { get; set; }

    public virtual DbSet<Billings> Billings { get; set; }

    public virtual DbSet<Doctors> Doctors { get; set; }

    public virtual DbSet<Patients> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=HospitalDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC072EF2A686");

            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Patient");
        });

        modelBuilder.Entity<Billings>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Billings__3214EC0791FBDA32");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BillingDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasDefaultValue("");

            entity.HasOne(d => d.Patient).WithMany(p => p.Billings)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Billing_Patient");
        });

        modelBuilder.Entity<Doctors>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctors__3214EC07CD10F2BE");

            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Specialty)
                .HasMaxLength(100)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<Patients>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC07151D920A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
