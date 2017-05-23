namespace WoofBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedBreedproperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Profiles", "Breed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Breed", c => c.String());
        }
    }
}
