namespace DotNet.MyProject.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleCodeFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderStatus", t => t.Status, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.Status);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.Order", "Status", "dbo.OrderStatus");
            DropIndex("dbo.Order", new[] { "Status" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Order");
        }
    }
}
