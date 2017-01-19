namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperPowerValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SuperPowers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SuperPowers", "Description", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuperPowers", "Description", c => c.String());
            AlterColumn("dbo.SuperPowers", "Name", c => c.String());
        }
    }
}
