namespace calisartik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _as : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.iceriks", "slider_sliderID", "dbo.sliders");
            DropIndex("dbo.iceriks", new[] { "slider_sliderID" });
            AddColumn("dbo.sliders", "sliderFoto", c => c.String());
            AddColumn("dbo.sliders", "OlusturmaTarihi", c => c.DateTime(nullable: false));
            DropColumn("dbo.iceriks", "slider_sliderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.iceriks", "slider_sliderID", c => c.Int());
            DropColumn("dbo.sliders", "OlusturmaTarihi");
            DropColumn("dbo.sliders", "sliderFoto");
            CreateIndex("dbo.iceriks", "slider_sliderID");
            AddForeignKey("dbo.iceriks", "slider_sliderID", "dbo.sliders", "sliderID");
        }
    }
}
