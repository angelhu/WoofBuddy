namespace WoofBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        ToUserID = c.String(maxLength: 128),
                        FromUserID = c.String(maxLength: 128),
                        Body = c.String(),
                        SentTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.FromUserID)
                .ForeignKey("dbo.AspNetUsers", t => t.ToUserID)
                .Index(t => t.ToUserID)
                .Index(t => t.FromUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ToUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "FromUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "FromUserID" });
            DropIndex("dbo.Messages", new[] { "ToUserID" });
            DropTable("dbo.Messages");
        }
    }
}
