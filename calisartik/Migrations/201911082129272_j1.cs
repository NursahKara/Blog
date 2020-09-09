namespace calisartik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.iletisims", "Ad", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.iletisims", "OlusturmaTarihi", c => c.DateTime(nullable: false));
            DropColumn("dbo.iletisims", "adSoyad");
            DropColumn("dbo.iletisims", "tarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.iletisims", "tarih", c => c.DateTime(nullable: false));
            AddColumn("dbo.iletisims", "adSoyad", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.iletisims", "OlusturmaTarihi");
            DropColumn("dbo.iletisims", "Ad");
        }
    }
}
