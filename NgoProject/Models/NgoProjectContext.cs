using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NgoProject.Models;

public partial class NgoProjectContext : DbContext
{
    public NgoProjectContext()
    {
    }

    public NgoProjectContext(DbContextOptions<NgoProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aboutu> Aboutus { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Banner1> Banners1 { get; set; }

    public virtual DbSet<Bannerss> Bannersses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Donate> Donates { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Ourpartner> Ourpartners { get; set; }

    public virtual DbSet<SendFeedback> SendFeedbacks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.;database=NgoProject;uid=sa;pwd=123;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aboutu>(entity =>
        {
            entity.HasKey(e => e.AboutusId).HasName("PK__Aboutus__261B8B37EFEA7E5A");

            entity.Property(e => e.AboutusId).HasColumnName("AboutusID");
            entity.Property(e => e.AboutusContent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AboutusDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.AboutusImage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AboutusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E881A5E9B0");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdminAvatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdminName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdminPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.IdOne);

            entity.ToTable("banner");
        });

        modelBuilder.Entity<Banner1>(entity =>
        {
            entity.HasKey(e => e.BanerId).HasName("PK__Banners__5E7BACEB407516FA");

            entity.ToTable("Banners");

            entity.Property(e => e.BanerId).HasColumnName("BanerID");
            entity.Property(e => e.BanerContent)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BanerImage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BanerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Bannerss>(entity =>
        {
            entity.HasKey(e => e.IdTwo);

            entity.ToTable("bannerss");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B8CF2EE7F");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Donate>(entity =>
        {
            entity.HasKey(e => e.DonateId).HasName("PK__Donates__AECF0640E73C6914");

            entity.Property(e => e.DonateId).HasColumnName("DonateID");
            entity.Property(e => e.DonateDate).HasColumnType("datetime");
            entity.Property(e => e.DonateMoney)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NewsId).HasColumnName("NewsID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.News).WithMany(p => p.Donates)
                .HasForeignKey(d => d.NewsId)
                .HasConstraintName("FK__Donates__NewsID__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.Donates)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Donates__UserID__5629CD9C");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__feedback__6A4BEDF6A2BE9B84");

            entity.ToTable("feedbacks");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.FeedbackEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackMessage)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackSubject)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__feedbacks__UserI__5AEE82B9");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__954EBDD3C0A9390B");

            entity.Property(e => e.NewsId).HasColumnName("NewsID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.NewsContent)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.NewsDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.NewsImage1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NewsImage2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NewsImage3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NewsName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OurpartnerId).HasColumnName("OurpartnerID");

            entity.HasOne(d => d.Category).WithMany(p => p.News)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__News__CategoryID__52593CB8");

            entity.HasOne(d => d.Ourpartner).WithMany(p => p.News)
                .HasForeignKey(d => d.OurpartnerId)
                .HasConstraintName("FK__News__Ourpartner__5165187F");
        });

        modelBuilder.Entity<Ourpartner>(entity =>
        {
            entity.HasKey(e => e.OurpartnerId).HasName("PK__Ourpartn__B54C0C267F311AE5");

            entity.Property(e => e.OurpartnerId).HasColumnName("OurpartnerID");
            entity.Property(e => e.OurpartnerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OurpartnerAddressWeb)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OurpartnerLogo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OurpartnerMail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OurpartnerName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OurpartnerPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SendFeedback>(entity =>
        {
            entity.HasKey(e => e.To);

            entity.ToTable("sendFeedback");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC9186C58A");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserAvatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
