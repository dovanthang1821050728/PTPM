namespace btl.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KhachhangDbContext : DbContext
    {
        public KhachhangDbContext()
            : base("name=KhachhangDbContext")
        {
        }

        public  virtual DbSet<ChiNhanhCuaHang> ChiNhanhCuaHangs { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThongTinKhachhang> ThongTinKhachhangs { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
