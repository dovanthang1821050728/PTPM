namespace btl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Khachhang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 128),
                        MatKhau = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TenDangNhap);
            
            CreateTable(
                "dbo.ChiNhanhCuaHang",
                c => new
                    {
                        MaCuaHang = c.Int(nullable: false, identity: true),
                        TenCuaHang = c.String(),
                        Tonghangtrongkho = c.Int(nullable: false),
                        SoLuongDaBan = c.Int(nullable: false),
                        SoLuongConLai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCuaHang);
            
            CreateTable(
                "dbo.DanhMucSanPhams",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(),
                        Tongsoluongbandau = c.Int(nullable: false),
                        SoLuongDaBan = c.Int(nullable: false),
                        SoLuongConLai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        IDsp = c.Int(nullable: false, identity: true),
                        MaSanPham = c.String(),
                        TenSanPham = c.String(),
                        GiaBan = c.String(),
                        SoLuongTrongKho = c.String(),
                        SoLuongDaBan = c.String(),
                        SoLuongConLai = c.String(),
                    })
                .PrimaryKey(t => t.IDsp);
            
            CreateTable(
                "dbo.ThongTinKhachhangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(),
                        DiaChi = c.String(),
                        SoDienThoai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ThongTinKhachhangs");
            DropTable("dbo.SanPhams");
            DropTable("dbo.DanhMucSanPhams");
            DropTable("dbo.ChiNhanhCuaHang");
            DropTable("dbo.Accounts");
        }
    }
}
