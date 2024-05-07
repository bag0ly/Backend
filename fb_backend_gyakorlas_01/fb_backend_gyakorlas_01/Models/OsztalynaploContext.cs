using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace fb_backend_gyakorlas_01.Models;

public partial class OsztalynaploContext : DbContext
{
    public OsztalynaploContext()
    {
    }

    public OsztalynaploContext(DbContextOptions<OsztalynaploContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jegyek> Jegyeks { get; set; }

    public virtual DbSet<Tanarok> Tanaroks { get; set; }

    public virtual DbSet<Tantargyak> Tantargyaks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database= osztalynaplo;user=root;password=;ssl mode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jegyek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("jegyek");

            entity.HasIndex(e => e.IdTantargyak, "jegyek_ibfk_2");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BeirasDatuma)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date")
                .HasColumnName("beiras_datuma");
            entity.Property(e => e.IdTanarok)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("id_tanarok");
            entity.Property(e => e.IdTantargyak)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("id_tantargyak");
            entity.Property(e => e.JegySzammal)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(1)")
                .HasColumnName("jegy_szammal");
            entity.Property(e => e.JegySzoveggel)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("jegy_szoveggel");
            entity.Property(e => e.ModositasDatuma)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date")
                .HasColumnName("modositas_datuma");

            entity.HasOne(d => d.IdTanarokNavigation).WithMany(p => p.Jegyeks)
                .HasForeignKey(d => d.IdTanarok)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("jegyek_ibfk_1");

            entity.HasOne(d => d.IdTantargyakNavigation).WithMany(p => p.Jegyeks)
                .HasForeignKey(d => d.IdTantargyak)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("jegyek_ibfk_2");
        });

        modelBuilder.Entity<Tanarok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tanarok");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("email");
            entity.Property(e => e.KeresztNev)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("kereszt_nev");
            entity.Property(e => e.Nem)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nem");
            entity.Property(e => e.VezetekNev)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("vezetek_nev");
        });

        modelBuilder.Entity<Tantargyak>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tantargyak");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TantargyLeiras)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("tantargy_leiras");
            entity.Property(e => e.TantargyNev)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("tantargy_nev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
