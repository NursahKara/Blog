namespace calisartik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Admin = c.Int(nullable: false),
                        Kullanici = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        kullaniciId = c.Int(nullable: false),
                        icerikID = c.Int(nullable: false),
                        YapilanYorum = c.String(),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.YorumID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yorums");
            DropTable("dbo.Roles");
        }
    }
}
