namespace RoomyLeRetour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoom2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Capacity = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.String(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UserId", "dbo.Users");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            DropTable("dbo.Rooms");
        }
    }
}
