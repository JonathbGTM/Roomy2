namespace RoomyLeRetour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Rooms", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "CategoryId");
            AddForeignKey("dbo.Rooms", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Rooms", new[] { "CategoryId" });
            DropColumn("dbo.Rooms", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
