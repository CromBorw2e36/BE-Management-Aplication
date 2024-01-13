using Microsoft.EntityFrameworkCore;
using quan_li_app.Models.SystemDB;

namespace quan_li_app.Models
{
    public class SystemContext : DbContext
    {

        public SystemContext()
        {
        }
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
        }

        public virtual DbSet<SysMenu> SysMenus { get; set; }
        public virtual DbSet<AppModule> AppModules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AppModule>(e =>
            {
                e.ToTable("AppModels");
                e.HasKey(e => e.code);
            });

            modelBuilder.Entity<SysMenu>(e =>
            {
                e.ToTable("SysMenu");
                e.HasKey(e => e.menuid);
                e.Property(e => e.menuid)
                .HasColumnName("menuid")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

                e.Property(e => e.name)
                .HasColumnType("nvarchar")
                .HasColumnName("name")
                .HasMaxLength(500);

                e.Property(e => e.isParent)
                .HasColumnName("isParent");

                e.Property(e => e.menuIDParent)
                .HasColumnType("nvarchar")
                .HasColumnName("menuIDParent")
                .HasMaxLength(250);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
