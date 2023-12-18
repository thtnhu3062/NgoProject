using Microsoft.EntityFrameworkCore;
using NgoProjectLib;

namespace NgoProject.Context
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Banner> banners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string str = "Server=.;Database=NgoProject;Uid=sa;pwd=200422;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(str);
        }

    }
}
