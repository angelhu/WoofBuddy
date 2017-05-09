namespace WoofBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addprofilephoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        FileDetailID = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        ProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileDetailID)
                .ForeignKey("dbo.Profiles", t => t.ProfileID, cascadeDelete: true)
                .Index(t => t.ProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDetails", "ProfileID", "dbo.Profiles");
            DropIndex("dbo.FileDetails", new[] { "ProfileID" });
            DropTable("dbo.FileDetails");
        }
    }
}
