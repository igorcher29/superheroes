namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperHeroImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperHeroes", "ImageData", c => c.Binary());
            AddColumn("dbo.SuperHeroes", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuperHeroes", "ImageMimeType");
            DropColumn("dbo.SuperHeroes", "ImageData");
        }
    }
}
