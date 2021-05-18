namespace btl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ThongTinKhachhangs", "SoDienThoai", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ThongTinKhachhangs", "SoDienThoai", c => c.Int(nullable: false));
        }
    }
}
