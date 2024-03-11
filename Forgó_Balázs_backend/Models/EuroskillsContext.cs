using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Forgó_Balázs_backend.Models;

public partial class EuroskillsContext : DbContext
{
    public EuroskillsContext()
    {
    }

    public EuroskillsContext(DbContextOptions<EuroskillsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Orszag> Orszags { get; set; }

    public virtual DbSet<Szakma> Szakmas { get; set; }

    public virtual DbSet<Versenyzo> Versenyzos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;database=euroskills;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orszag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orszag");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("id");
            entity.Property(e => e.OrszagNev)
                .HasMaxLength(31)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("orszagNev");
        });

        modelBuilder.Entity<Szakma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szakma");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("id");
            entity.Property(e => e.SzakmaNev)
                .HasMaxLength(31)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("szakmaNev");
        });

        modelBuilder.Entity<Versenyzo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("versenyzo");

            entity.HasIndex(e => e.OrszagId, "orszagId");

            entity.HasIndex(e => e.SzakmaId, "szakmaId");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(31)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nev");
            entity.Property(e => e.OrszagId)
                .HasMaxLength(2)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("orszagId");
            entity.Property(e => e.Pont)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("pont");
            entity.Property(e => e.SzakmaId)
                .HasMaxLength(2)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("szakmaId");

            entity.HasOne(d => d.Orszag).WithMany(p => p.Versenyzos)
                .HasForeignKey(d => d.OrszagId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("versenyzo_ibfk_2");

            entity.HasOne(d => d.Szakma).WithMany(p => p.Versenyzos)
                .HasForeignKey(d => d.SzakmaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("versenyzo_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
