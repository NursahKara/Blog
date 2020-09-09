namespace calisartik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Roles");
        }
        
        public override void Down()
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
            
        }
    }
}
