namespace WoofBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedzipcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "ZipCode");
        }
    }
}
