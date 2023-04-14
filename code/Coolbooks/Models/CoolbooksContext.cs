﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Models;

public partial class CoolbooksContext : DbContext
{
    public CoolbooksContext(DbContextOptions<CoolbooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<SiteUser> SiteUsers { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__70DAFC14B58393B4");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.Firstname).HasMaxLength(250);
            entity.Property(e => e.Lastname).HasMaxLength(250);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C227170EF5E0");

            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Imagepath).HasMaxLength(250);
            entity.Property(e => e.Isbn)
                .HasMaxLength(250)
                .HasColumnName("ISBN");
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Book__AuthorID__412EB0B6");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Book__GenreID__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.Books)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Book__UserID__4316F928");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__0385055EFAA7EF7A");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE012501BE");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Book).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Review__BookID__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Review__UserID__44FF419A");
        });

        modelBuilder.Entity<SiteUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__SiteUser__1788CCAC2972D2D1");

            entity.ToTable("SiteUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(250);
            entity.Property(e => e.UserinfoId).HasColumnName("UserinfoID");

            entity.HasOne(d => d.Userinfo).WithMany(p => p.SiteUsers)
                .HasForeignKey(d => d.UserinfoId)
                .HasConstraintName("FK__SiteUser__Userin__45F365D3");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.UserInfoId).HasName("PK__Userinfo__D07EF2C43612288A");

            entity.ToTable("Userinfo");

            entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(250);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}