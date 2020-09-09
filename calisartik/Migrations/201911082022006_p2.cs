namespace calisartik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yorums", "kullanici", c => c.String());
            DropColumn("dbo.Yorums", "kullaniciId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yorums", "kullaniciId", c => c.Int(nullable: false));
            DropColumn("dbo.Yorums", "kullanici");
        }
    }
}
