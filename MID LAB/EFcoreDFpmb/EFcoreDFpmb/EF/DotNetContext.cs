using System;
using System.Collections.Generic;
using EFcoreDFpmb.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcoreDFpmb.EF;

public partial class DotNetContext : DbContext
{
    public DotNetContext()
    {
    }

    public DotNetContext(DbContextOptions<DotNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Depertment> Depertments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .HasColumnName("Course Name");
        });

        modelBuilder.Entity<Depertment>(entity =>
        {
            entity.ToTable("Depertment");

            entity.Property(e => e.DeptName).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("students");

            entity.Property(e => e.Cgpa).HasColumnName("CGPA");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
