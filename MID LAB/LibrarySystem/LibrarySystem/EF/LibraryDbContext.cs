using System;
using System.Collections.Generic;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.EF;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookLoan> BookLoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(e => e.LoanId);

            entity.ToTable("BookLoan");

            entity.Property(e => e.BorrowedAt).HasColumnType("datetime");
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.LateFee).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MemberName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
