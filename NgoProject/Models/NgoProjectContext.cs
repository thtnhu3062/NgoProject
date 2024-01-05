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


    public virtual DbSet<Bannerss> Bannersses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Donate> Donates { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Ourpartner> Ourpartners { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.;database=NgoProject;uid=sa;pwd=123;trustServerCertificate=true");

}