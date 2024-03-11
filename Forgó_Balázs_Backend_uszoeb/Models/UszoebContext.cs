using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Forgó_Balázs_Backend_uszoeb.Models;

public partial class UszoebContext : DbContext
{
    public UszoebContext()
    {
    }

    public UszoebContext(DbContextOptions<UszoebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Orszagok> Orszagoks { get; set; }

    public virtual DbSet<Szamok> Szamoks { get; set; }

    public virtual DbSet<Versenyzok> Versenyzoks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;database=uszoeb;user=root;password=;ssl-mode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orszagok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orszagok");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(60)
                .HasColumnName("nev");
            entity.Property(e => e.Nobid)
                .HasMaxLength(3)
                .HasColumnName("nobid");
        });

        modelBuilder.Entity<Szamok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szamok");

            entity.HasIndex(e => e.VersenyzoId, "versenyzoId");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(40)
                .HasColumnName("nev");
            entity.Property(e => e.VersenyzoId)
                .HasColumnType("int(11)")
                .HasColumnName("versenyzoId");

            entity.HasOne(d => d.Versenyzo).WithMany(p => p.Szamoks)
                .HasForeignKey(d => d.VersenyzoId)
                .HasConstraintName("szamok_ibfk_1");
        });

        modelBuilder.Entity<Versenyzok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("versenyzok");

            entity.HasIndex(e => e.OrszagId, "orszagId");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nem)
                .HasColumnType("text")
                .HasColumnName("nem");
            entity.Property(e => e.Nev)
                .HasMaxLength(60)
                .HasColumnName("nev");
            entity.Property(e => e.OrszagId)
                .HasColumnType("int(11)")
                .HasColumnName("orszagId");

            entity.HasOne(d => d.Orszag).WithMany(p => p.Versenyzoks)
                .HasForeignKey(d => d.OrszagId)
                .HasConstraintName("versenyzok_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
