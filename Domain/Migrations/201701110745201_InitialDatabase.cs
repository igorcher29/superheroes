namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperHeroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String()                        
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuperPowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Rating = c.Int(nullable: false),
                        SuperHeroId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SuperHeroes", t => t.SuperHeroId)
                .Index(t => t.SuperHeroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuperPowers", "SuperHeroId", "dbo.SuperHeroes");
            DropIndex("dbo.SuperPowers", new[] { "SuperHeroId" });
            DropTable("dbo.SuperPowers");
            DropTable("dbo.SuperHeroes");
        }
    }
}
