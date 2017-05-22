namespace WoofBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdresponseclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileLikes",
                c => new
                    {
                        ProfileLikeID = c.Int(nullable: false, identity: true),
                        LookerUserID = c.String(maxLength: 128),
                        ViewedUserID = c.String(maxLength: 128),
                        Liked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileLikeID)
                .ForeignKey("dbo.AspNetUsers", t => t.LookerUserID)
                .ForeignKey("dbo.AspNetUsers", t => t.ViewedUserID)
                .Index(t => t.LookerUserID)
                .Index(t => t.ViewedUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileLikes", "ViewedUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProfileLikes", "LookerUserID", "dbo.AspNetUsers");
            DropIndex("dbo.ProfileLikes", new[] { "ViewedUserID" });
            DropIndex("dbo.ProfileLikes", new[] { "LookerUserID" });
            DropTable("dbo.ProfileLikes");
        }
    }
}
