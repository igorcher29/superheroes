namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperHeroNameValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SuperHeroes", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuperHeroes", "Name", c => c.String());
        }
    }
}
