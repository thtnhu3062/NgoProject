using Microsoft.EntityFrameworkCore;
using NgoProject.Models;


namespace NgoProject.Context
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<BannerTable>? banner { get; set; }

        public virtual DbSet<BannerTabless>? banners { get; set; }

        public virtual DbSet<SendFeedback>? sendFeedback { get; set; }

  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            string str = "Server=.;Database=NgoProject;Uid=sa;pwd=123;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(str);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<NgoProject.Models.Category>? Category { get; set; }

    }
}
