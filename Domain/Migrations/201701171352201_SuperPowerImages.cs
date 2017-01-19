namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperPowerImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperPowers", "ImageData", c => c.Binary());
            AddColumn("dbo.SuperPowers", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuperPowers", "ImageMimeType");
            DropColumn("dbo.SuperPowers", "ImageData");
        }
    }
}
