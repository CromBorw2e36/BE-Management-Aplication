using DAL_QUANLI.Models.DataDB;
using DAL_QUANLI.Models.DataDB.Movie;
using DAL_QUANLI.Models.DataDB.Movie.MasterData;
using DAL_QUANLI.Models.DataDB.Movie.Transaction;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.QuanLiNhanSu;
using quan_li_app.Models.DataDB.UserData;

namespace quan_li_app.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbContextString1 = "Data Source=DESKTOP-R2ECO11\\SQLEXPRESS;Initial Catalog=PMQuanLyData;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0";
            string DbContextString2 = "Data Source=KHANHNGUYENLAPT;Initial Catalog=PMQuanLyData;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbContextString1);
            }
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<MenuPermissions> MenuPermissions { get; set; }
        public virtual DbSet<UserInfo> UserInfomation { get; set; }
        public virtual DbSet<WorkHistory> WorkHistories { get; set; }
        public virtual DbSet<CurrentJobPosition> CurrentJobPositions { get; set; }
        public virtual DbSet<SalaryAndBenefits> SalaryAndBenefits { get; set; }
        public virtual DbSet<TOKEN> Tokens { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<SysTypeAccount> SysTypeAccounts { get; set; }
        public virtual DbSet<SysStatus> SysStatus { get; set; }
        public virtual DbSet<SysModule> SysModules { get; set; }
        public virtual DbSet<SysPermission> SysPermissions { get; set; }
        public virtual DbSet<DocumentManagement> DocumentManagements { get; set; }

        public virtual DbSet<National> Nationals { get; set; }
        public virtual DbSet<UploadFileModel> UploadFileModels { get; set; }
        public virtual DbSet<CategoryCommonModel> CategoryCommonModels { get; set; }
        //public virtual DbSet<LogTimeDataUpdateModel> LogTimeDataUpdateModels { get; set; }


        public virtual DbSet<MovieGenresModel> MovieGenresModel { get; set; }
        public virtual DbSet<MovieModel> MovieModel { get; set; }
        public virtual DbSet<MovieCommentModel> MovieCommentModel { get; set; }
        public virtual DbSet<MovieFavoritesModel> MovieFavoritesModel { get; set; }
        public virtual DbSet<MovieReactionToCommentModel> MovieReactionToCommentModel { get; set; }
        public virtual DbSet<MovieReactionToMovieModel> MovieRactionToMovieModel { get; set; }
        public virtual DbSet<MovieReivewModel> MovieReivewModel { get; set; }
        public virtual DbSet<MovieWatchHistoryModel> MovieWatchHistoryModel { get; set; }
        public virtual DbSet<LanguageModel> LanguageModel { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<National>(e =>
            {
                e.ToTable("National");
                e.HasKey(e => e.code);
                e.Property(e => e.active).HasDefaultValue(true);
            });

            modelBuilder.Entity<SysPermission>(e =>
            {
                e.ToTable("SysPermission");
                e.HasKey(e => e.code);
            });

            modelBuilder.Entity<SysModule>(e =>
            {
                e.ToTable("SysModule");
                e.HasKey(e => e.code);
            });

            modelBuilder.Entity<SysStatus>(e =>
            {
                e.ToTable("SysStatus");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<SysTypeAccount>(e =>
            {
                e.ToTable("SysTypeAccount");
                e.HasKey(e => e.code);
            });

            modelBuilder.Entity<Company>(e =>
            {
                e.ToTable("Company");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<TOKEN>(e =>
            {
                e.ToTable("Token");
                e.HasKey(e => e.id);
                e.Property(x => x.latitude).HasColumnType("decimal(18, 6)");
                e.Property(x => x.longitude).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<SalaryAndBenefits>(e =>
            {
                e.ToTable("SalaryAndBenefits");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<SalaryAndBenefits>(e =>
            {
                e.ToTable("SalaryAndBenefits");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<CurrentJobPosition>(e =>
            {
                e.ToTable("CurrentJobPosition");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<WorkHistory>(e =>
            {
                e.ToTable("WorkHistory");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<UserInfo>(e =>
            {
                e.ToTable("UserInfomation");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("Account");
                e.HasKey(e => e.account);
                e.Property(e => e.account)
                .HasMaxLength(254);
                e.Property(e => e.status)
                .HasMaxLength(254);
                e.Property(e => e.type_account)
                .HasMaxLength(254);
            });

            modelBuilder.Entity<MenuPermissions>(e =>
            {
                e.ToTable("MenuPermissions");
                e.HasKey(e => e.id);
            });


            modelBuilder.Entity<DocumentManagement>().HasNoKey();
            modelBuilder.Entity<DocumentManagement>(e =>
            {
                e.ToTable("DocumentManagement");
                //e.HasKey(e => e.code);
                e.Property(e => e.module).IsRequired();
                e.Property(e => e.tableName).IsRequired();
                e.Property(e => e.lenCode).HasDefaultValue(16);
                e.Property(e => e.primaryKeyTable).IsRequired();
                e.Property(e => e.isCompanyCode).HasDefaultValue(false);
                e.Property(e => e.isClose).HasDefaultValue(false);
            });
            modelBuilder.Entity<UploadFileModel>(e =>
            {
                e.ToTable("UploadFile");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<CategoryCommonModel>(e =>
            {
                e.ToTable("CategoryCommon");
                e.HasKey(e => e.id);
            });


            modelBuilder.Entity<MovieGenresModel>(e => {
                e.ToTable("MovieGenres");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<MovieModel>(e => {
                e.ToTable("Movie");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<MovieCommentModel>(e => {
                e.ToTable("MovieComment");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<MovieFavoritesModel>(e => {
                e.ToTable("MovieFavorites");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<MovieReactionToCommentModel>(e => {
                e.ToTable("MovieReactionToComment");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<MovieReactionToMovieModel>(e => {
                e.ToTable("MovieReactionToMovie");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<MovieReivewModel>(e => {
                e.ToTable("MovieReivew");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<MovieWatchHistoryModel>(e =>
            {
                e.ToTable("MovieWatchHistory");
                e.HasKey(e => e.id);
            });

            modelBuilder.Entity<LanguageModel>(e =>
            {
                e.ToTable("Language");
                e.HasKey(e => e.id);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
