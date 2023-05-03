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


    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<SiteUser> SiteUsers { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AspNetRole)
                .HasForeignKey<AspNetRole>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AspNetRoles__Id__619B8048");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__70DAFC149ECBC155");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.Firstname).HasMaxLength(250);
            entity.Property(e => e.Lastname).HasMaxLength(250);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C2279D36E751");

            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.Imagepath).HasMaxLength(250);
            entity.Property(e => e.Isbn)
                .HasMaxLength(250)
                .HasColumnName("ISBN");
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Book__AuthorID__44FF419A");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Book__GenreID__45F365D3");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Book__Id__5629CD9C");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFAAEC7A3071");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.ParentCommentId).HasColumnName("ParentCommentID");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Text).HasMaxLength(250);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Comment__Id__5535A963");

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment)
                .HasForeignKey(d => d.ParentCommentId)
                .HasConstraintName("FK__Comment__ParentC__46E78A0C");

            entity.HasOne(d => d.Review).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("FK__Comment__ReviewI__47DBAE45");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__0385055EF285F2D2");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("PK__Like__A2922CF406398427");

            entity.ToTable("Like");

            entity.Property(e => e.LikeId).HasColumnName("LikeID");
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.Like1)
                .HasMaxLength(50)
                .HasColumnName("Like");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

            entity.HasOne(d => d.Comment).WithMany(p => p.Likes)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK__Like__CommentID__48CFD27E");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Like__Id__5441852A");

            entity.HasOne(d => d.Review).WithMany(p => p.Likes)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("FK__Like__ReviewID__49C3F6B7");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE000BFC9C");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Book).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Review__BookID__4AB81AF0");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Review__Id__534D60F1");
        });

        modelBuilder.Entity<SiteUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__SiteUser__1788CCAC7116D69A");

            entity.ToTable("SiteUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(250);
            entity.Property(e => e.UserinfoId).HasColumnName("UserinfoID");

            entity.HasOne(d => d.Userinfo).WithMany(p => p.SiteUsers)
                .HasForeignKey(d => d.UserinfoId)
                .HasConstraintName("FK__SiteUser__Userin__4BAC3F29");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.UserInfoId).HasName("PK__Userinfo__D07EF2C4B6FEAD5C");

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