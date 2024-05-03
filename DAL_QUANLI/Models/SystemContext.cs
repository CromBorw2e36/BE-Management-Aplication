using DAL_QUANLI.Models.SystemDB.SysAction;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string SysContextString1 = "Data Source=DESKTOP-BCM4VJC;Initial Catalog=PMQuanLySys;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0";
            string SysContextString2 = "Data Source=KHANHNGUYENLAPT;Initial Catalog=PMQuanLySys;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SysContextString1);
            }
        }
        public virtual DbSet<SysMenu> SysMenus { get; set; }
        public virtual DbSet<AppModule> AppModules { get; set; }

        public virtual DbSet<SysAction> SysActions { get; set; }
        public virtual DbSet<SysGroupAction> SysGroupAction { get; set; }
        public virtual DbSet<SysDropDownAction> SysDropDownActions { get; set; }

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

                e.Property(e => e.active).HasDefaultValue(true);
            });

            modelBuilder.Entity<SysAction>(e =>
            {
                e.ToTable("SysAction");
                e.HasKey(e => e.code);
                e.Property(e => e.isDisable).HasDefaultValue(false);

            });

            modelBuilder.Entity<SysGroupAction>().HasNoKey();
            modelBuilder.Entity<SysGroupAction>(e =>
            {
                e.ToTable("SysGroupAction");
                e.Property(item => item.code).IsRequired();
                e.Property(item => item.codeAction).IsRequired();
                e.Property(item => item.orderNo).IsRequired();
                e.Property(item => item.isClocked).IsRequired()
                 .HasDefaultValue(false);
                e.Property(item => item.isDropDown).HasDefaultValue(false);
            });

            modelBuilder.Entity<SysDropDownAction>().HasNoKey();
            modelBuilder.Entity<SysDropDownAction>(e =>
            {
                e.ToTable("SysDropDownAction");
                e.Property(item => item.code).IsRequired();
                e.Property(item => item.codeAction).IsRequired();
                e.Property(item => item.orderNo).IsRequired();
                e.Property(item => item.isClocked).HasDefaultValue(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
